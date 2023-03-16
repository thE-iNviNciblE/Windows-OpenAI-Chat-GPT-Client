Imports System.Net
Imports System.IO
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Speech.Synthesis
Imports System.Speech.Recognition
Imports System.Runtime.Remoting.Messaging
Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Runtime.InteropServices.JavaScript.JSType
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Net.Mime.MediaTypeNames

Public Class Application
    Public Property application_id As String
    Public Property application_package As String
End Class


Public Class frmGPTChat

    Dim OPENAI_API_KEY As String = "" 'https://beta.openai.com/account/api-keys
    Dim oSpeechRecognitionEngine As SpeechRecognitionEngine = Nothing
    Dim oSpeechSynthesizer As System.Speech.Synthesis.SpeechSynthesizer = Nothing

    Private Sub frmGPTChat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  Dim oAppSettingsReader As New AppSettingsReader()
        '  Dim sApiKey As String = oAppSettingsReader.GetValue("OPENAI_API_KEY", GetType(String)) & ""

        'If My.Settings.openai_api_key = "" Or My.Settings.openai_api_key = "openai_api_key" Then
        '    Dim frmapi As New frmAPIKEY
        '    frmapi.ShowDialog(Me)
        '    End
        'Else
        OPENAI_API_KEY = "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"

        Call getOpenAIModels2Combobox()
            cbModel.SelectedIndex = 0

            cbVoice.Items.Clear()
            Dim synth As New SpeechSynthesizer()
            For Each voice In synth.GetInstalledVoices()
                cbVoice.Items.Add(voice.VoiceInfo.Name)
            Next
            cbVoice.SelectedIndex = 0
        'End If



    End Sub

    Private Sub chkListen_CheckedChanged(sender As Object, e As EventArgs) Handles chkListen.CheckedChanged
        If chkListen.Checked Then
            lblSpeech.Text = ""
            lblSpeech.Visible = True
            SpeechToText()
        Else
            oSpeechRecognitionEngine.RecognizeAsyncStop()
            lblSpeech.Visible = False
        End If
    End Sub
    Private Sub chkMute_CheckedChanged(sender As Object, e As EventArgs) Handles chkMute.CheckedChanged

        If chkMute.Checked Then
            lblVoice.Visible = False
            cbVoice.Visible = False
        Else
            lblVoice.Visible = True
            cbVoice.Visible = True
        End If

    End Sub

    Private Sub SpeechToText()

        If oSpeechRecognitionEngine IsNot Nothing Then
            oSpeechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple)
            Exit Sub
        End If

        oSpeechRecognitionEngine = New SpeechRecognitionEngine(New Globalization.CultureInfo("de-DE"))
        oSpeechRecognitionEngine.LoadGrammar(New DictationGrammar())
        AddHandler oSpeechRecognitionEngine.SpeechRecognized, AddressOf OnSpeechRecognized
        AddHandler oSpeechRecognitionEngine.SpeechHypothesized, AddressOf OnSpeechHypothesized
        oSpeechRecognitionEngine.SetInputToDefaultAudioDevice()
        oSpeechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple)
    End Sub

    Private Sub OnSpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs)
        lblSpeech.Text = "" 'Reset Hypothesized text

        If txtQuestion.Text <> "" Then
            txtQuestion.Text += vbCrLf
        End If

        Dim text As String = e.Result.Text
        txtQuestion.Text += text
    End Sub

    Private Sub OnSpeechHypothesized(sender As Object, e As SpeechHypothesizedEventArgs)
        Dim text As String = e.Result.Text
        lblSpeech.Text = text
    End Sub

    Private Async Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click

        Dim sQuestion As String = txtQuestion.Text
        If sQuestion = "" Then
            MessageBox.Show("Stelle eine Frage!")
            txtQuestion.Focus()
            Exit Sub
        End If

        If txtAnswer.Text <> "" Then
            txtAnswer.AppendText(vbCrLf)
        End If

        txtAnswer.AppendText("Me: " & sQuestion & vbCrLf)
        txtQuestion.Text = ""

        Try
            Dim sAnswer As String

            Select Case cbModus.Text

                Case "CHAT"
                    sAnswer = Await SendMsg2Chat(sQuestion)
                Case "BILDER"
                    sAnswer = Await SendMsg2Picture(sQuestion)
                Case "COMPLETION"
                    sAnswer = Await SendMsg(sQuestion)
            End Select

            txtAnswer.AppendText("Chat GPT: " & Replace(sAnswer, vbLf, vbCrLf))
            SpeechToText(sAnswer)
        Catch ex As Exception
            txtAnswer.AppendText("Error: " & ex.Message)
        End Try

    End Sub

    Private Async Function SendMsg(sQuestion As String) As Task(Of String)
        Dim iMaxTokens As Integer = txtMaxTokens.Text '2048
        Dim sUserId As String = txtUserID.Text '1
        Dim sModel As String = cbModel.Text 'text-davinci-002, text-davinci-003
        Dim json As String = ""
        Dim dTemperature As Double = Convert.ToDouble(txtTemperature.Text) '0.5
        Dim sResponse As String = ""
        If dTemperature < 0 Or dTemperature > 1 Then
            MessageBox.Show("Zwischen 0 und 1")
            Return ""
        End If

        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls13 Or System.Net.SecurityProtocolType.Tls12 Or System.Net.SecurityProtocolType.Tls11 Or System.Net.SecurityProtocolType.Tls

        Using client As New HttpClient()

            Dim sCleanModel() As String = sModel.Split(" ")
            json = "{"
            json += " ""model"":""" & sCleanModel(0) & ""","
            json += " ""prompt"": """ & Await setQuoates(sQuestion) & ""","
            json += " ""max_tokens"": " & iMaxTokens & ","
            json += " ""user"": """ & sUserId & """, "
            json += " ""temperature"": " & dTemperature & ", "
            json += " ""frequency_penalty"": 0.0" & ", " 'Number between -2.0 and 2.0  Positive value decrease the model's likelihood to repeat the same line verbatim.
            json += " ""presence_penalty"": 0.0" & ", " ' Number between -2.0 and 2.0. Positive values increase the model's likelihood to talk about new topics.
            json += " ""stop"": [""#"", "";""]" 'Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.
            json += "}"

            Dim content As New StringContent(json, Encoding.UTF8, "application/json")
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " & OPENAI_API_KEY)

            Dim response As HttpResponseMessage = Await client.PostAsync("https://api.openai.com/v1/completions", content)
            response.EnsureSuccessStatusCode()
            json = Await response.Content.ReadAsStringAsync()
        End Using

        'Dim sResponse As String = oJson("choices")(0)("message")("content")
        'Dim result = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(json)
        Dim myObj = JsonConvert.DeserializeObject(Of TextCompletion)(json)
        If myObj.error IsNot Nothing Then
            Dim strMsg As String = ""
            For i As Integer = 0 To myObj.Choices.Count - 1
                Dim firstModel = myObj.Choices(i)
                strMsg += firstModel.Text + " "
            Next
            Return strMsg
        Else
            Try
                Return myObj.error.message
            Catch ex As Exception
                Return ex.Message.ToString
            End Try

        End If

    End Function

    Sub SpeechToText(ByVal s As String)

        If chkMute.Checked Then
            Exit Sub
        End If

        If oSpeechSynthesizer Is Nothing Then
            oSpeechSynthesizer = New System.Speech.Synthesis.SpeechSynthesizer()
            oSpeechSynthesizer.SetOutputToDefaultAudioDevice()
        End If

        If cbVoice.Text <> "" Then
            oSpeechSynthesizer.SelectVoice(cbVoice.Text)
        End If

        oSpeechSynthesizer.Speak(s)

    End Sub

    Private Async Function SendMsg2Picture(ByVal sQuestion As String) As Task(Of String)
        Dim iMaxTokens As Integer = txtMaxTokens.Text '2048
        Dim sUserId As String = txtUserID.Text '1
        Dim sModel As String = cbModel.Text 'text-davinci-002, text-davinci-003
        Dim json As String
        Dim dTemperature As Double = Convert.ToDouble(txtTemperature.Text) '0.5

        If dTemperature < 0 Or dTemperature > 1 Then
            MessageBox.Show("Zwischen 0 und 1")
            Return ""
        End If

        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls13 Or System.Net.SecurityProtocolType.Tls12 Or System.Net.SecurityProtocolType.Tls11 Or System.Net.SecurityProtocolType.Tls

        Using client As New HttpClient()

            Dim data As String = "{"
            data += " ""prompt"": "" " + sQuestion + " "",
  ""n"": 2,
  ""size"": ""1024x1024"""
            data += "}"

            Dim content As New StringContent(data, Encoding.UTF8, "application/json")
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " & OPENAI_API_KEY)

            Dim response As HttpResponseMessage = Await client.PostAsync("https://api.openai.com/v1/images/generations", content)
            response.EnsureSuccessStatusCode()
            json = Await response.Content.ReadAsStringAsync()
        End Using

        Dim Dalle2 As Dalle2 = JsonConvert.DeserializeObject(Of Dalle2)(json)
        If Dalle2.error Is Nothing Then
            Dim strMsg As String = ""
            For i As Integer = 0 To Dalle2.data.Count - 1
                strMsg += Dalle2.data(i).url + vbCrLf & vbCrLf
            Next
            Return strMsg
        Else
            Return Dalle2.error.message
        End If

    End Function

    Private Async Function SendMsg2Chat(ByVal sQuestion As String) As Task(Of String)

        Dim iMaxTokens As Integer = txtMaxTokens.Text '2048
        Dim sUserId As String = txtUserID.Text '1
        Dim sModel As String = cbModel.Text 'text-davinci-002, text-davinci-003
        Dim json As String
        Dim dTemperature As Double = Convert.ToDouble(txtTemperature.Text) '0.5
        If dTemperature < 0 Or dTemperature > 1 Then
            MessageBox.Show("Zwischen 0 und 1")
            Return ""
        End If

        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls13 Or System.Net.SecurityProtocolType.Tls12 Or System.Net.SecurityProtocolType.Tls11 Or System.Net.SecurityProtocolType.Tls

        Using client As New HttpClient()
            Dim sModel_split() As String = sModel.Split(" ")
            json = "{"
            json += " ""model"":""" & sModel_split(0) & ""","
            json += " ""messages"" :[{""role"": ""user"", ""content"": """ + Await setQuoates(sQuestion) + """}],"
            json += " ""max_tokens"": " & iMaxTokens & ","
            json += " ""user"": """ & sUserId & """, "
            json += " ""temperature"": " & dTemperature & ", "
            json += " ""frequency_penalty"": 0.0" & ", "
            json += " ""presence_penalty"": 0.0" & ", "
            json += " ""stop"": [""#"", "";""]"
            json += "}"

            Dim content As New StringContent(json, Encoding.UTF8, "application/json")
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " & OPENAI_API_KEY)

            Dim response As HttpResponseMessage = Await client.PostAsync("https://api.openai.com/v1/chat/completions", content)
            response.EnsureSuccessStatusCode()
            json = Await response.Content.ReadAsStringAsync()
        End Using

        'Dim sResponse As String = oJson("choices")(0)("message")("content")
        Dim ChatObject As ChatObject = JsonConvert.DeserializeObject(Of ChatObject)(json)

        Dim myObj = JsonConvert.DeserializeObject(Of TextCompletion)(json)
        If ChatObject.error Is Nothing Then
            Dim strMsg As String = ""
            For i As Integer = 0 To ChatObject.choices.Count - 1
                Dim firstModel = ChatObject.choices(i)
                strMsg += firstModel.text + " "
            Next
            Return strMsg
        Else
            Return ChatObject.error.message
        End If

    End Function
    Private Async Function getOpenAIModels2Combobox() As Task(Of Boolean)
        'https://beta.openai.com/docs/models/gpt-3
        Dim json As String
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls13 Or System.Net.SecurityProtocolType.Tls12 Or System.Net.SecurityProtocolType.Tls11 Or System.Net.SecurityProtocolType.Tls

        Using client As New HttpClient()
            'Dim content As New StringContent(json, Encoding.UTF8, "application/json")
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " & OPENAI_API_KEY)

            Dim response As HttpResponseMessage = Await client.GetAsync("https://api.openai.com/v1/models")
            response.EnsureSuccessStatusCode()
            json = Await response.Content.ReadAsStringAsync()
        End Using

        'Dim oList As Object() = oJson("data")
        'Dim applications As List(Of Application) = JsonConvert.DeserializeObject(Of List(Of Application))(Json)
        Dim myObj As myModelsofGTP = JsonConvert.DeserializeObject(Of myModelsofGTP)(json)

        If myObj.error Is Nothing Then
            cbModel.Items.Clear()

            Dim oSortedList As SortedList = New SortedList()

            For i As Integer = 0 To myObj.Data.Count - 1

                Dim firstModel = myObj.Data(i)

                'Dim oPermission As Hashtable = oList(i)("permission")(0)
                'If sIds <> "" Then sIds += vbCrLf
                'sIds += sCreated & vbTab & sId
                oSortedList.Add(firstModel.Id + " - " + UnixToTime(firstModel.Created) + " by " + firstModel.Owned_by, firstModel.Id)
            Next

            For Each oItem As DictionaryEntry In oSortedList
                cbModel.Items.Add(oItem.Key)
            Next
            Return True
        Else
            txtAnswer.AppendText("Chat GPT: " & Replace(myObj.error.message, vbLf, vbCrLf))
            SpeechToText(myObj.error.message)

            Return False
        End If

    End Function

    Private Async Function setQuoates(ByVal s As String) As Task(Of String)

        If s.IndexOf("\") <> -1 Then
            s = Replace(s, "\", "\\")
        End If

        If s.IndexOf(vbCrLf) <> -1 Then
            s = Replace(s, vbCrLf, "\n")
        End If

        If s.IndexOf(vbCr) <> -1 Then
            s = Replace(s, vbCr, "\r")
        End If

        If s.IndexOf(vbLf) <> -1 Then
            s = Replace(s, vbLf, "\f")
        End If

        If s.IndexOf(vbTab) <> -1 Then
            s = Replace(s, vbTab, "\t")
        End If

        If s.IndexOf("""") = -1 Then
            Return s
        Else
            Return Replace(s, """", "\""")
        End If
    End Function

    Private Sub cbModeleLaden_CheckedChanged(sender As Object, e As EventArgs)
        cbModel.Enabled = False

        Call getOpenAIModels2Combobox()

        cbModel.Enabled = True
    End Sub

    Private Sub BeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeendenToolStripMenuItem.Click
        End
    End Sub

    Private Sub APIKEYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles APIKEYToolStripMenuItem.Click
        Dim frmapi As New frmAPIKEY
        frmapi.ShowDialog(Me)
    End Sub
End Class
Public Class Dalle2_url
    Public Property url As String
End Class

Public Class Dalle2
    Public Property created As Integer
    Public Property data As List(Of Dalle2_url)

    Public Property [error] As ResponseError
End Class

Public Class ChatChoice
    Public Property text As String
    Public Property index As Integer
    Public Property logprobs As Object
    Public Property finish_reason As String
End Class

Public Class ChatUsage
    Public Property prompt_tokens As Integer
    Public Property completion_tokens As Integer
    Public Property total_tokens As Integer
End Class

Public Class ChatObject
    Public Property id As String
    Public Property [object] As String
    Public Property created As Integer
    Public Property model As String
    Public Property choices As List(Of ChatChoice)
    Public Property usage As ChatUsage
    Public Property [error] As ResponseError
End Class

Public Class ResponseError
    <JsonProperty("message")>
    Public Property message As String
    <JsonProperty("type")>
    Public Property type As String
    <JsonProperty("param")>
    Public Property param As Object
    <JsonProperty("code")>
    Public Property code As Object
End Class
Public Class ResponseError_modelgpt
    <JsonProperty("message")>
    Public Property message As String
    <JsonProperty("type")>
    Public Property type As String
    <JsonProperty("param")>
    Public Property param As Object
    <JsonProperty("code")>
    Public Property code As Object
End Class

Public Class TextCompletion

    <JsonProperty("id")>
    Public Property Id As String

    <JsonProperty("object")>
    Public Property [Object] As String

    <JsonProperty("created")>
    Public Property Created As Long

    <JsonProperty("model")>
    Public Property Model As String

    <JsonProperty("choices")>
    Public Property Choices As List(Of Choice)

    <JsonProperty("usage")>
    Public Property Usage As Usage
    <JsonProperty("[error]")>
    Public Property [error] As ResponseError
End Class
Public Class Choice
    <JsonProperty("text")>
    Public Property Text As String

    <JsonProperty("index")>
    Public Property Index As Integer

    <JsonProperty("logprobs")>
    Public Property Logprobs As Object

    <JsonProperty("finish_reason")>
    Public Property FinishReason As String
End Class
Public Class Usage
    <JsonProperty("prompt_tokens")>
    Public Property prompt_tokens As Integer
    <JsonProperty("finish_reason")>
    Public Property finish_reason As Integer
    <JsonProperty("total_tokens")>
    Public Property total_tokens As Integer
End Class
Public Class myModelsofGTP
    <JsonProperty("[Object]")>
    Public Property [Object] As String
    <JsonProperty("Data")>
    Public Property Data As List(Of gtpmodels)
    <JsonProperty("[error]")>
    Public Property [error] As ResponseError_modelgpt
End Class

Public Class gtpmodels
    Public Property Id As String
    Public Property [Object] As String
    Public Property Created As Long
    Public Property Owned_by As String
    Public Property Permission As List(Of ModelPermission)
    Public Property Root As String
    Public Property Parent As Object ' This can be a specific type if known.

End Class

Public Class ModelPermission
    Public Property Id As String
    Public Property [Object] As String
    Public Property Created As Long
    Public Property Allow_create_engine As Boolean
    Public Property Allow_sampling As Boolean
    Public Property Allow_logprobs As Boolean
    Public Property Allow_search_indices As Boolean
    Public Property Allow_view As Boolean
    Public Property Allow_fine_tuning As Boolean
    Public Property Organization As String
    Public Property Group As Object ' This can be a specific type if known.
    Public Property Is_blocking As Boolean
End Class

