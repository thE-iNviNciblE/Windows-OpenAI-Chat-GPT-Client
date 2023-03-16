<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGPTChat
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.txtQuestion = New System.Windows.Forms.TextBox()
        Me.txtAnswer = New System.Windows.Forms.TextBox()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTemperature = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMaxTokens = New System.Windows.Forms.TextBox()
        Me.cbModel = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbVoice = New System.Windows.Forms.ComboBox()
        Me.lblVoice = New System.Windows.Forms.Label()
        Me.chkListen = New System.Windows.Forms.CheckBox()
        Me.chkMute = New System.Windows.Forms.CheckBox()
        Me.lblSpeech = New System.Windows.Forms.Label()
        Me.cbModus = New System.Windows.Forms.ComboBox()
        Me.lblModus = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.APIKEYFestlegenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.APIKEYToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSend.Location = New System.Drawing.Point(2, 266)
        Me.btnSend.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(82, 36)
        Me.btnSend.TabIndex = 0
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'txtQuestion
        '
        Me.txtQuestion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuestion.Location = New System.Drawing.Point(2, 332)
        Me.txtQuestion.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtQuestion.Multiline = True
        Me.txtQuestion.Name = "txtQuestion"
        Me.txtQuestion.Size = New System.Drawing.Size(786, 86)
        Me.txtQuestion.TabIndex = 1
        '
        'txtAnswer
        '
        Me.txtAnswer.AcceptsReturn = True
        Me.txtAnswer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAnswer.Location = New System.Drawing.Point(2, 8)
        Me.txtAnswer.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtAnswer.Multiline = True
        Me.txtAnswer.Name = "txtAnswer"
        Me.txtAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAnswer.Size = New System.Drawing.Size(786, 256)
        Me.txtAnswer.TabIndex = 2
        '
        'txtUserID
        '
        Me.txtUserID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtUserID.Location = New System.Drawing.Point(313, 305)
        Me.txtUserID.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(68, 20)
        Me.txtUserID.TabIndex = 3
        Me.txtUserID.Text = "1"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(266, 308)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "User ID"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(276, 283)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Zufall"
        '
        'txtTemperature
        '
        Me.txtTemperature.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTemperature.Location = New System.Drawing.Point(313, 280)
        Me.txtTemperature.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtTemperature.Name = "txtTemperature"
        Me.txtTemperature.Size = New System.Drawing.Size(68, 20)
        Me.txtTemperature.TabIndex = 5
        Me.txtTemperature.Text = "0.5"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(401, 281)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Max tokens"
        '
        'txtMaxTokens
        '
        Me.txtMaxTokens.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMaxTokens.Location = New System.Drawing.Point(465, 280)
        Me.txtMaxTokens.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtMaxTokens.Name = "txtMaxTokens"
        Me.txtMaxTokens.Size = New System.Drawing.Size(68, 20)
        Me.txtMaxTokens.TabIndex = 7
        Me.txtMaxTokens.Text = "2048"
        '
        'cbModel
        '
        Me.cbModel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbModel.FormattingEnabled = True
        Me.cbModel.Items.AddRange(New Object() {"gpt-3.5-turbo-0301", "gpt-3.5-turbo", "text-davinci-003", "text-davinci-002", "code-davinci-002"})
        Me.cbModel.Location = New System.Drawing.Point(593, 276)
        Me.cbModel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbModel.Name = "cbModel"
        Me.cbModel.Size = New System.Drawing.Size(195, 21)
        Me.cbModel.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(555, 280)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Model"
        '
        'cbVoice
        '
        Me.cbVoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbVoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVoice.FormattingEnabled = True
        Me.cbVoice.Location = New System.Drawing.Point(593, 304)
        Me.cbVoice.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbVoice.Name = "cbVoice"
        Me.cbVoice.Size = New System.Drawing.Size(195, 21)
        Me.cbVoice.TabIndex = 11
        '
        'lblVoice
        '
        Me.lblVoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVoice.AutoSize = True
        Me.lblVoice.Location = New System.Drawing.Point(542, 309)
        Me.lblVoice.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVoice.Name = "lblVoice"
        Me.lblVoice.Size = New System.Drawing.Size(47, 13)
        Me.lblVoice.TabIndex = 12
        Me.lblVoice.Text = "Sprache"
        '
        'chkListen
        '
        Me.chkListen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkListen.AutoSize = True
        Me.chkListen.Location = New System.Drawing.Point(395, 304)
        Me.chkListen.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.chkListen.Name = "chkListen"
        Me.chkListen.Size = New System.Drawing.Size(66, 17)
        Me.chkListen.TabIndex = 13
        Me.chkListen.Text = "Zuhören"
        Me.chkListen.UseVisualStyleBackColor = True
        '
        'chkMute
        '
        Me.chkMute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkMute.AutoSize = True
        Me.chkMute.Checked = True
        Me.chkMute.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMute.Location = New System.Drawing.Point(465, 305)
        Me.chkMute.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.chkMute.Name = "chkMute"
        Me.chkMute.Size = New System.Drawing.Size(60, 17)
        Me.chkMute.TabIndex = 14
        Me.chkMute.Text = "Lautlos"
        Me.chkMute.UseVisualStyleBackColor = True
        '
        'lblSpeech
        '
        Me.lblSpeech.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSpeech.AutoSize = True
        Me.lblSpeech.Location = New System.Drawing.Point(8, 311)
        Me.lblSpeech.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSpeech.Name = "lblSpeech"
        Me.lblSpeech.Size = New System.Drawing.Size(51, 13)
        Me.lblSpeech.TabIndex = 15
        Me.lblSpeech.Text = "speech..."
        Me.lblSpeech.Visible = False
        '
        'cbModus
        '
        Me.cbModus.FormattingEnabled = True
        Me.cbModus.Items.AddRange(New Object() {"CHAT", "COMPLETION", "BILDER"})
        Me.cbModus.Location = New System.Drawing.Point(88, 295)
        Me.cbModus.Name = "cbModus"
        Me.cbModus.Size = New System.Drawing.Size(161, 21)
        Me.cbModus.TabIndex = 17
        '
        'lblModus
        '
        Me.lblModus.AutoSize = True
        Me.lblModus.Location = New System.Drawing.Point(89, 276)
        Me.lblModus.Name = "lblModus"
        Me.lblModus.Size = New System.Drawing.Size(39, 13)
        Me.lblModus.TabIndex = 18
        Me.lblModus.Text = "Modus"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.APIKEYFestlegenToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(795, 24)
        Me.MenuStrip1.TabIndex = 20
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeendenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.BeendenToolStripMenuItem.Text = "&Beenden"
        '
        'APIKEYFestlegenToolStripMenuItem
        '
        Me.APIKEYFestlegenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.APIKEYToolStripMenuItem})
        Me.APIKEYFestlegenToolStripMenuItem.Name = "APIKEYFestlegenToolStripMenuItem"
        Me.APIKEYFestlegenToolStripMenuItem.Size = New System.Drawing.Size(111, 20)
        Me.APIKEYFestlegenToolStripMenuItem.Text = "API KEY festlegen"
        '
        'APIKEYToolStripMenuItem
        '
        Me.APIKEYToolStripMenuItem.Name = "APIKEYToolStripMenuItem"
        Me.APIKEYToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.APIKEYToolStripMenuItem.Text = "API KEY..."
        '
        'frmGPTChat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 424)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.lblModus)
        Me.Controls.Add(Me.cbModus)
        Me.Controls.Add(Me.lblSpeech)
        Me.Controls.Add(Me.chkMute)
        Me.Controls.Add(Me.chkListen)
        Me.Controls.Add(Me.lblVoice)
        Me.Controls.Add(Me.cbVoice)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbModel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMaxTokens)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTemperature)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.txtAnswer)
        Me.Controls.Add(Me.txtQuestion)
        Me.Controls.Add(Me.btnSend)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmGPTChat"
        Me.Text = "GPT Chat"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSend As Button
    Friend WithEvents txtQuestion As TextBox
    Friend WithEvents txtAnswer As TextBox
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTemperature As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMaxTokens As TextBox
    Friend WithEvents cbModel As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbVoice As ComboBox
    Friend WithEvents lblVoice As Label
    Friend WithEvents chkListen As CheckBox
    Friend WithEvents chkMute As CheckBox
    Friend WithEvents lblSpeech As Label
    Friend WithEvents cbModus As ComboBox
    Friend WithEvents lblModus As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DateiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BeendenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents APIKEYFestlegenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents APIKEYToolStripMenuItem As ToolStripMenuItem
End Class
