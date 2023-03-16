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
