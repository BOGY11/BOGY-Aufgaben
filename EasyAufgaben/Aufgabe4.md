# Einarmiger Bandit
Du programmierst eine Slot-Maschine als Konsolenanwendung in C#. Der Spieler startet mit einem Startguthaben und kann pro Runde einen Betrag setzen. Nach jedem Drehen werden drei zufällig gezogene Symbole angezeigt — je nach Kombination gewinnt oder verliert der Spieler Credits. Das Spiel läuft so lange, bis das Guthaben aufgebraucht ist oder der Spieler aufhört.

Die verfügbaren Symbole sind 🍒, 🍋, 🍊, 🍇 und 💎, wobei 🍒 am häufigsten vorkommt und 💎 am seltensten. Seltenere Symbole bringen entsprechend höhere Gewinne. Drei gleiche Symbole ergeben einen Jackpot, zwei gleiche Symbole einen kleinen Gewinn, und bei keiner Übereinstimmung ist der Einsatz verloren.

Am Ende sieht eine Spielrunde in der Konsole so aus:
```
Guthaben: 100 Credits
Einsatz: 5 Credits

Drehen...
[🍇|🍊|🍊]

2× Orange → Gewinn: 10 Credits
Guthaben: 105 Credits
```
## Schritt 1 (Projekt Erstellen):
Erstelle ein [neues Projekt](../Tutorials/NewProject.md) als Konsolenanwendung und nenne es 'EinarmigerBandit'.

## Schritt 2 (Die Symbole):
Erstelle eine neue Statische Klasse 'Symbole' und speichere dort die Symbole 🍒, 🍋, 🍊, 🍇, 💎 als `const string`:\
`public const string Kirche = "🍒";`

Erweitere die Klasse um eine `Get`-Methode, welche ein `int` als Symbolindex übergeben bekommt und das entsprechende Symbol zurückgibt.

## Schritt 3 (Der Automat):
Erstelle eine neue Klasse Automat.

Diese Klasse soll für diese Ausgabe: `[🍇|🍊|🍊]` zuständig sein.

## Schritt 3.1 (SetRandomSymbol):
Erstelle in der Automat-Klasse eine neue Methode 'SetRandomSymbol'.

Die übergabeparameter sind: `string[] symbole, int anzahl`\
Der rückgabewert ist: `string[]`.

## Schritt 3.2 (Drehen):
Erstelle eine neue Methode Drehen in der Automat-Klasse.

Die Methode hat keinen Übergabeparameter und gibt ein `Task<int[]>` zurück (sie ist async), wobei `int[]` das ergebnis repräsentiert.

Die Methode simuliert die Slot-Maschinen-Animation über 3 Sekunden:\
Die Walzen kommen nacheinander zum Stillstand — zuerst drehen sich alle drei, dann nur noch zwei, dann nur noch eine.\
Dazu wird eine Stopwatch gestartet und in einer Schleife läuft die Animation, solange die vergangene Zeit unter 3 Sekunden liegt:

0–1 Sekunde: Alle 3 Symbole werden zufällig neu gesetzt → SetRandomSymbole(symbole, 3)\
1–2 Sekunden: Nur noch 2 Symbole ändern sich → SetRandomSymbole(symbole, 2)\
2–3 Sekunden: Nur noch 1 Symbol ändert sich → SetRandomSymbole(symbole, 1)

Nach jedem Durchlauf wird die aktuelle Konsolenzeile überschrieben (Console.ClearLine(), dafür musst du deiner solution die [ConsoleExtension](code/EasyAufgabe4/ConsoleExtensions.cs)) und die drei Symbole im Format [🍇|🍊|🍊] ausgegeben.\
Danach wartet die Methode 100 Millisekunden (await Task.Delay(100)), bevor der nächste Frame gezeichnet wird.

[Tipp](tipps/EasyAufgabe4/tippDrehen.md)

Teste dein code in Program.cs:
```
Console.OutputEncoding = System.Text.Encoding.UTF8;

var automat = new Automat();
while (true)
{
	int[] ergebnis = await automat.Drehen();
	Console.ReadLine();
	Console.Clear();
}
```
## Schritt 4 (Die Gewichtung):
Die Symbole sollen verschiedene Gewichtungen haben:\
🍒: 40%,\
🍋: 30%,\
🍊: 18%,\
🍇: 9%,\
💎: 3%

Implementiere diese in der SetRandomSymbole Methode.

## Schritt 5 (Ergebnis Berechnung):
Erstelle eine neue statische Klasse ErgebnissBerechnung.\
Diese Klasse ist dafür zuständig, das Ergebnis einer Drehung auszuwerten und den entsprechenden Gewinnmultiplikator zurückzugeben.

Füge eine statische Methode Berechne hinzu, die ein int[] (die Symbolindizes der drei Walzen) entgegennimmt und ein double zurückgibt.

Die Methode prüft zunächst, ob alle drei Symbole identisch sind — also ein Jackpot vorliegt. Dazu wird das erste Symbol mit allen weiteren verglichen. Sobald ein abweichendes Symbol gefunden wird, bricht die Schleife ab.\
Sind alle gleich, wird anhand des Symbolindex der Gewinnmultiplikator bestimmt:

| Index | Symbol | Multiplikator |
|-------|--------|---------------|
| 0 | 🍒 | x3 |
| 1 | 🍋 | x5 |
| 2 | 🍊 | x20 |
| 3 | 🍇 | x40 |
| 4 | 💎 | x500 |

falls zwei symbole gleich sind gibt die methode 0.5 zurück (man behält den Einsatz).

**Hinweis**: Der Rückgabewert ist ein Multiplikator, kein absoluter Gewinn. Der tatsächliche Gewinn ergibt sich erst durch die Multiplikation mit dem gesetzten Einsatz.

Teste dein code in Program.cs:
```
Console.OutputEncoding = System.Text.Encoding.UTF8;

var automat = new Automat();
for (int i = 0; i < 5; i++)
{
	Console.WriteLine($"[{Symbole.GetSymbol(i)}|{Symbole.GetSymbol(i)}|{Symbole.GetSymbol(i)}]");
	var ergebnis = ErgebnissBerechnung.Berechne([i,i,i]);
	Console.WriteLine(ergebnis);
	Console.ReadLine();
	Console.Clear();
}
Console.WriteLine($"[{Symbole.GetSymbol(0)}|{Symbole.GetSymbol(1)}|{Symbole.GetSymbol(1)}]");
var ergebnis2 = ErgebnissBerechnung.Berechne([0,1,1]);
Console.WriteLine(ergebnis2);
```

## Schritt 6 (Credits und Implementation)
Am Anfang hat der Spieler 100 Credits.

Wenn der Spieler das spiel startet wird er gefragt wie viel er pro runde einsetzen will:
Konsole:
```
Credits: 100
Aktueller Einsatz: 0 Credit
Bitte eingeben wie viel du einsetzen willst:
```
und die Eingabe wird als int gespeichert.

Das spiel geht erst los wenn der Einsatz > 0 ist.

Danach wird `Console.Clear();` und `ConsoleWriter.WriteStartScreen(credits, einsatz);` ausgeführt.

Füge eine statische Klasse `ConsoleWriter` hinzu mit der statischen Methode `WriteStartScreen`, welche den den Startscreen mit den aktuellen Credits und den aktuellen Einsatz in der Konsole anzeigt.

Startscreen:
```
Credits: 100
Aktueller Einsatz: 1 Credit
Das Spiel endet, wenn du keine Credits mehr hast oder 'ende' eingibst.
Gebe ein neuen einsatz ein falls du ihn ändern willst.
Enter -> neue runde.

```