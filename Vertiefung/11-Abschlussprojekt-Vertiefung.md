---
title: 11 - Vertiefung Abschlussprojekt
parent: 11 - Abschlussprojekt
nav_order: 1
---
# Kapitel 11 – Abschlussprojekt (Vertiefung & Architektur)

[← Zurück zu Kapitel 11](../Kapitel/11-Abschlussprojekt.md) | [Übersicht](../README.md)

Das Abschlussprojekt kombiniert alles, was du gelernt hast: Variablen, Schleifen, Bedingungen, Eingaben, Methoden und Fehlerbehandlung. In diesem Vertiefungsdokument lernst du, wie man ein solches Projekt strukturiert plant, ohne sich im Code zu verlieren.

---

## 1. Die größte Falle: "Alles auf einmal schreiben"

Wenn du ein Programm von 100 Zeilen schreibst und es erst dann zum ersten Mal startest, hast du mit 99%iger Wahrscheinlichkeit 10 Fehler gleichzeitig und weißt nicht, wo du suchen sollst.

### Die goldene Vorgehensweise: "Schicht für Schicht"
1. **Schritt 1 (Das Grundgerüst):** Eine Zufallszahl generieren und fest ausgeben. Läuft das Programm?
2. **Schritt 2 (Die Eingabe):** Eine einzelne Zahl einlesen und anzeigen. Läuft es?
3. **Schritt 3 (Der Vergleich):** Prüfen: Zu groß, zu klein oder Treffer?
4. **Schritt 4 (Die Schleife):** Das Ganze in eine `while`-Schleife packen, bis der Treffer da ist.
5. **Schritt 5 (Politur & Absicherung):** Eingabe mit `int.TryParse` absichern, Versuche zählen, Farben einbauen.

---

## 2. Der "Game-Loop" (Das Spiel-Muster)

Fast jedes Spiel der Welt (von Tic-Tac-Toe bis zu 3D-Blockbustern) folgt demselben Ablauf:

```text
[Start/Initialisierung] -> Geheimzahl wählen, Punktestand = 0
       │
       ▼
   ┌──► [Eingabe lesen]    -> Spieler tippt Zahl ein
   │    [Logik prüfen]     -> Ist die Zahl richtig? Leben abziehen
   │    [Ausgabe/Feedback] -> "Zu hoch!", "Zu niedrig!"
   │   
   └─── Ist das Spiel vorbei? (Nein -> Wiederholen)
       │
       ▼ (Ja)
[Spielende / Highscore anzeigen]
```

---

## 3. Die Tücke mit Zufallszahlen (`Random`)

```csharp
int zufall = Random.Shared.Next(1, 101);
```
- Die Methode `.Next(min, max)` ist **inklusiv beim Minimum**, aber **exklusiv beim Maximum**!
- `Next(1, 100)` erzeugt nur Zahlen von `1` bis `99`!
- Wenn du Zahlen von 1 bis einschließlich 100 haben willst, musst du `Next(1, 101)` schreiben!

---

## 4. Debugging in Visual Studio: Der Röntgenblick

Wenn dein Programm etwas Unerwartetes tut, nutze den **Debugger**:
1. Klicke ganz links neben eine Codezeile (in den grauen Rand) oder drücke **F9**. Es erscheint ein roter Punkt (ein **Breakpoint / Haltepunkt**).
2. Starte mit **F5**. Das Programm hält an dieser Zeile an und wird gelb markiert.
3. Fahre mit der Maus über deine Variablen: Du siehst live, welcher Wert gerade darin gespeichert ist!
4. Drücke **F10**, um genau eine Zeile weiterzuspringen. So kannst du deinem Code beim Denken zusehen.

---

## 5. Vollständige Referenz-Architektur mit Tipps

Hier ist eine saubere, modulare Struktur für das Zahlenratespiel, die Methoden zur sauberen Trennung nutzt.

{% capture tipp %}
**Lösung / Tipp zum Abschlussprojekt:**

Hier ist eine vorbildlich strukturierte Lösung mit ausgelagerten Methoden für Eingabe und Spielablauf:

```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Zahlenratespiel Deluxe";
        bool weiterspielen = true;

        while (weiterspielen)
        {
            SpieleEineRunde();
            weiterspielen = FrageNachNeustart();
        }

        Console.WriteLine("\nVielen Dank fürs Spielen! Bis zum nächsten Mal.");
    }

    static void SpieleEineRunde()
    {
        Console.Clear();
        Console.WriteLine("=====================================");
        Console.WriteLine("  WILLKOMMEN ZUM ZAHLENRATESPIEL!   ");
        Console.WriteLine("  Ich suche eine Zahl von 1 bis 100 ");
        Console.WriteLine("=====================================\n");

        int geheimzahl = Random.Shared.Next(1, 101);
        int versuche = 0;
        bool erraten = false;

        while (!erraten)
        {
            int tipp = LeseGueltigeZahl("Dein Tipp (1-100): ", 1, 100);
            versuche++;

            if (tipp == geheimzahl)
            {
                erraten = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n🎉 Volltreffer! Du hast die Zahl {geheimzahl} in {versuche} Versuchen erraten!");
                Console.ResetColor();
            }
            else if (tipp < geheimzahl)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Zu niedrig! Versuch es höher.\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Zu hoch! Versuch es niedriger.\n");
                Console.ResetColor();
            }
        }
    }

    static int LeseGueltigeZahl(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string eingabe = Console.ReadLine()!;

            if (int.TryParse(eingabe, out int zahl) && zahl >= min && zahl <= max)
            {
                return zahl;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ungültig! Bitte eine ganze Zahl zwischen {min} und {max} eingeben.");
            Console.ResetColor();
        }
    }

    static bool FrageNachNeustart()
    {
        Console.Write("\nMöchtest du noch eine Runde spielen? (j/n): ");
        string antwort = Console.ReadLine()!.Trim().ToLower();
        return antwort == "j" || antwort == "ja";
    }
}
```
*Tipp zur Struktur:* Durch die Aufteilung in `Main`, `SpieleEineRunde`, `LeseGueltigeZahl` und `FrageNachNeustart` bleibt der Code extrem übersichtlich und lässt sich jederzeit erweitern (z. B. um Schwierigkeitsgrade oder Highscores)!
{% endcapture %}
{% include tipp.html inhalt=tipp %}

