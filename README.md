# Windows client for OpenAI APIs
Access to the REST API of "Chat" (GPT-3, GPT-4) / "Completion" (multiple models text-davinci-003, Codex) / "Images" (e.g. GPT-3 Turbo)

## Installation
The .NET Framework 7.x is required. [Download]https://dotnet.microsoft.com/en-us/download/dotnet/7.0.

## For service
Get your own OpenAI API key for free to use the software. You will be asked for this key right when you start the software and there is a clickable link. You need a login to the OpenAI platform, e.g. for the public chat function.

### Settings and Limits
Watch out for "." and "," when entering numbers.
- You can set "Random" from 0.0 to 1.0.
- You can set "UserID" to any value, so far it should correspond to "New Chat" with no strange previous context.
- Max Tokens is equal to length and used for billing OpenAI paid (you need billing account for paid mode). Max tokens can be 1-2048 and 4000 tokens, which corresponds to the text length.
- You can change the "Model" text-davinci 001 - 003 are the most popular ones besides Chat GPT-3, GPT-4.
- In order to generate images with Dalle-2 you have to switch the "Mode" to "IMAGES". You will get a URL to the picture which you have to copy out.

--------------

# Windows Client für OpenAI API's
Zugriff auf die REST API von "Chat" (GPT-3, GPT-4) / "Completition" (mehrere Modelle text-davinci-003, Codex) / "Bilder" (z.B. GPT-3 Turbo)

## Installation
Es wird das .NET Framework 7.x benötigt. [Zum Download]https://dotnet.microsoft.com/en-us/download/dotnet/7.0.

## Zur Bedienung
Holen Sie sich kostenlos einen eigenen OpenAI API-Schlüssel um die Software zu verwenden. Sie werden direkt beim Starten der Software nach diesem Schlüssel gefragt und dort ist ein anclickbarer Link. Sie benötigten einen Login bei der OpenAI Plattform z.B. für die öffentliche Chat-Funktion.

### Einstellungen und Limits
Achten Sie auf "." und "," bei den Zahleneingaben.
- Sie können "Zufall" auf 0.0 bis 1.0 einstellen. 
- Sie können "UserID" auf einen beliebigen Wert einstellen, sollte soweit einem "Neuen Chat" entsprechen ohne merkwürdige vorherrigen Kontext.
- Max Tokens entsprecht der Länge und wird für die kostenpflichtige OpenAI zur Abrechnung verwendet (Sie benötigten für den Kostenpflichtigen Modus ein Abrechnungskonto). Max Tokens kann 1-2048 und 4000 Tokens, das entsprecht der Textlänge.
- Sie können das "Model" ändern text-davinci 001 - 003 sind neben Chat GPT-3, GPT-4 die populärsten.
- Um Bilder mit Dalle-2 zu erzeugen müssen Sie den "Modus" auf "BILDER" umstellen. Sie erhalten eine URL zu dem Bild welches Sie rauskopieren müssen.
