---
title: 10 - Vertiefung Fehler abfangen
parent: 10 - Fehler abfangen
nav_order: 1
---
# Kapitel 10 – Fehler abfangen (Vertiefung)

[← Zurück zu Kapitel 10](../Kapitel/10-Fehler-abfangen.md) | [Übersicht](../README.md) | [Weiter: Abschlussprojekt Vertiefung →](11-Abschlussprojekt-Vertiefung.md)

Ein Programm, das bei der kleinsten Fehleingabe sofort abstürzt, frustriert Nutzer. In diesem Kapitel lernst du, wie du dein Programm wie eine gepanzerte Festung baust.

---

## 1. Was ist eine "Exception" eigentlich?

Eine **Exception** (Ausnahme) ist die Notbremse des Computers:
Wenn C# an eine Stelle kommt, die es unmöglich ausführen kann (z. B. Teilen durch 0, Umwandeln von Buchstaben in Zahlen, Zugriff auf Datei die nicht existiert), ruft es:
> „Halt! Ich weiß nicht weiter! Entweder fängt jemand diesen Fehler auf, oder ich beende das Programm sofort!“

---

## 2. `try-catch` vs. `int.TryParse`: Wann nutzt man was?

Das ist einer der wichtigsten Architektur-Unterschiede in C#:

### A. `try-catch` (Das Rettungsnetz)
```csharp
try
{
    // Gefährlicher Code
    int zahl = int.Parse(Console.ReadLine()!);
}
catch (FormatException)
{
    // Was tun, wenn es schiefgeht
    Console.WriteLine("Das war keine Zahl!");
}
```
- **Wann nutzen?** Für unvorhersehbare Fehler, die von außen kommen (z. B. Netzwerk bricht ab, Festplatte voll, Datei gesperrt).
- **Nachteil:** `try-catch` ist relativ langsam, wenn der Fehler tatsächlich auftritt, und unterbricht den normalen Kontrollfluss.

---

### B. `int.TryParse` (Die vorausschauende Ampel)
```csharp
Console.Write("Zahl eingeben: ");
string eingabe = Console.ReadLine()!;

bool klappte = int.TryParse(eingabe, out int zahl);
```
- **Wann nutzen?** Immer bei **Nutzereingaben in der Konsole**!
- `TryParse` wirft **niemals** eine Exception und bringt das Programm **niemals** zum Absturz.
- Es gibt einfach `true` zurück, wenn es geklappt hat, und `false`, wenn die Eingabe ungültig war.

---

## 3. Das Geheimnis des `out`-Schlüsselworts

Normalerweise kann eine C#-Methode mit `return` nur **einen einzigen Wert** zurückgeben.
`int.TryParse` muss uns aber **zwei Dinge gleichzeitig** mitteilen:
1. Hat es geklappt? (`bool`)
2. Was ist die umgewandelte Zahl? (`int`)

Dafür gibt es das Schlüsselwort **`out`**:
```csharp
if (int.TryParse(eingabe, out int zahl))
{
    // "zahl" ist jetzt mit dem fertigen Wert befüllt!
    Console.WriteLine($"Erfolg: {zahl * 2}");
}
```
Das `out` bedeutet: „Liebe Methode, schreibe dein zweites Ergebnis direkt in diese Variable hinein!“

---

## 4. Die "unzerstörbare" Eingabeschleife

Das Standardmuster für saubere Programme:
```csharp
int alter;

while (true)
{
    Console.Write("Bitte gib dein Alter ein (0-120): ");
    string eingabe = Console.ReadLine()!;

    if (int.TryParse(eingabe, out alter) && alter >= 0 && alter <= 120)
    {
        break; // Gültige Zahl im richtigen Bereich -> Schleife verlassen!
    }

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Ungültige Eingabe! Bitte eine Zahl zwischen 0 und 120 eingeben.");
    Console.ResetColor();
}

Console.WriteLine($"Eingabe akzeptiert: {alter} Jahre.");
```

---

## 5. Vertiefungsaufgaben mit Tipps

### Aufgabe 10.1: Sichere Division
Schreibe ein Programm, das zwei Zahlen abfragt: `zaehler` und `nenner`.
Berechne das Ergebnis der Division `zaehler / nenner`.
Fange mit `TryParse` ab:
- Falls keine Zahl eingegeben wurde.
- Falls der `nenner == 0` ist (Division durch 0 verhindern!).

{% capture tipp %}
**Lösung / Tipp zu 10.1:**

Prüfe sowohl die Zahlengültigkeit als auch die Null-Division:

```csharp
Console.Write("Zähler eingeben: ");
if (!double.TryParse(Console.ReadLine(), out double zaehler))
{
    Console.WriteLine("Fehler: Ungültiger Zähler!");
    return;
}

Console.Write("Nenner eingeben: ");
if (!double.TryParse(Console.ReadLine(), out double nenner))
{
    Console.WriteLine("Fehler: Ungültiger Nenner!");
    return;
}

if (nenner == 0)
{
    Console.WriteLine("Fehler: Durch 0 kann nicht geteilt werden!");
}
else
{
    double ergebnis = zaehler / nenner;
    Console.WriteLine($"Ergebnis: {zaehler} / {nenner} = {ergebnis:F2}");
}
```
{% endcapture %}
{% include tipp.html inhalt=tipp %}

---

### Aufgabe 10.2: Robuster Menüwähler
Erstelle ein Konsolenmenü:
```text
1. Spiel starten
2. Highscore ansehen
3. Beenden
```
Frage den Nutzer nach seiner Wahl.
Lass den Nutzer bei Fehleingaben (Buchstaben, Zahlen außer 1–3) nicht weiter, sondern zeige eine Fehlermeldung und frage erneut, bis eine gültige Auswahl getroffen wurde.

{% capture tipp %}
**Lösung / Tipp zu 10.2:**

Kombiniere eine `while(true)`-Schleife mit `int.TryParse`:

```csharp
int auswahl;

while (true)
{
    Console.WriteLine("=== HAUPTMENÜ ===");
    Console.WriteLine("1. Spiel starten");
    Console.WriteLine("2. Highscore ansehen");
    Console.WriteLine("3. Beenden");
    Console.Write("Deine Wahl (1-3): ");

    string eingabe = Console.ReadLine()!;

    if (int.TryParse(eingabe, out auswahl) && auswahl >= 1 && auswahl <= 3)
    {
        break; // Gültige Auswahl!
    }

    Console.Clear();
    Console.WriteLine(">>> Ungültige Auswahl! Bitte nur 1, 2 oder 3 wählen. <<<\n");
}

Console.WriteLine($"Du hast Menüpunkt {auswahl} gewählt!");
```
{% endcapture %}
{% include tipp.html inhalt=tipp %}

