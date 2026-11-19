---
title: 05 - Vertiefung Verzweigungen
parent: 05 - Verzweigungen
nav_order: 1
---
# Kapitel 5 – Verzweigungen (Vertiefung)

[← Zurück zu Kapitel 5](../Kapitel/05-Verzweigungen.md) | [Übersicht](../README.md) | [Weiter: Schleifen Vertiefung →](06-Schleifen-Vertiefung.md)

Mit Verzweigungen triffst du Entscheidungen im Code. Manchmal verhalten sich `if`-Anweisungen jedoch ganz anders als erwartet – vor allem, wenn man mehrere Bedingungen hintereinander hängt.

---

## 1. Die Kaskaden-Falle: Mehrere `if` vs. `if - else if`

Das ist einer der häufigsten logischen Fehler bei Programmieranfängern:

### Fall A: Viele unabhängige `if`s
```csharp
int alter = 20;

if (alter >= 12)
{
    Console.WriteLine("Du darfst Jugendfilme sehen.");
}
if (alter >= 18)
{
    Console.WriteLine("Du bist volljährig.");
}
```
**Ausgabe:**
```text
Du darfst Jugendfilme sehen.
Du bist volljährig.
```
*Warum?* Der Computer prüft **jedes** `if` einzeln! Da `20 >= 12` wahr ist und `20 >= 18` auch wahr ist, werden **beide** Blöcke ausgeführt.

---

### Fall B: Geschlossene Kette mit `else if`
```csharp
int alter = 20;

if (alter >= 18)
{
    Console.WriteLine("Erwachsener");
}
else if (alter >= 12)
{
    Console.WriteLine("Jugendlicher");
}
else
{
    Console.WriteLine("Kind");
}
```
**Ausgabe:**
```text
Erwachsener
```
*Warum?* Sobald eine Bedingung in einer `if - else if`-Kette wahr ist, führt C# **nur diesen einen Block** aus und überspringt den Rest der Kette komplett!

---

## 2. Der unsichtbare Killer: Das Semikolon hinter dem `if`

Siehst du den Fehler in diesem Code?
```csharp
int note = 5;

if (note == 1);
{
    Console.WriteLine("Hervorragend! Du hast eine 1!");
}
```
Wenn du das ausführst, gibt das Programm den Text aus, obwohl `note == 5` ist!

**Warum passiert das?**
Das Semikolon hinter `if (note == 1);` beendet die `if`-Anweisung sofort mit einem leeren Befehl. Die geschweiften Klammern `{ ... }` darunter gelten für C# als eigenständiger Codeblock, der **immer** ausgeführt wird.
**Regel:** Hinter runde Klammern bei `if (...)` gehört **niemals** ein Semikolon!

---

## 3. Wann `switch` und wann `if`?

- Nimm **`switch`**, wenn du **eine einzige Variable** auf feste, konkrete Werte vergleichst (z. B. Wochentage 1–7, Menüauswahl `'A'`, `'B'`, `'C'`).
- Nimm **`if`**, wenn du **Bereiche** prüfst (`groesse > 140 && groesse < 190`) oder **unterschiedliche Variablen** miteinander verknüpfst.

---

## 4. Vertiefungsaufgaben mit Tipps

### Aufgabe 5.1: Noten-Bewerter
Schreibe ein Programm, das eine Schulnote (1 bis 6) abfragt und eine passende Rückmeldung gibt:
- 1: "Sehr gut"
- 2: "Gut"
- 3: "Befriedigend"
- 4: "Ausreichend"
- 5: "Mangelhaft"
- 6: "Ungenügend"
- Alle anderen Zahlen: "Ungültige Note!"

Löse die Aufgabe einmal mit `switch` und überlege, warum `switch` hier besonders übersichtlich ist.

{% capture tipp %}
**Lösung / Tipp zu 5.1:**

Mit `switch` sieht die Lösung extrem aufgeräumt aus:

```csharp
Console.Write("Gib eine Schulnote (1-6) ein: ");
int note = int.Parse(Console.ReadLine()!);

switch (note)
{
    case 1:
        Console.WriteLine("Sehr gut");
        break;
    case 2:
        Console.WriteLine("Gut");
        break;
    case 3:
        Console.WriteLine("Befriedigend");
        break;
    case 4:
        Console.WriteLine("Ausreichend");
        break;
    case 5:
        Console.WriteLine("Mangelhaft");
        break;
    case 6:
        Console.WriteLine("Ungenügend");
        break;
    default:
        Console.WriteLine("Ungültige Note!");
        break;
}
```
*Tipp:* Vergiss nach jedem `case` das `break;` nicht, sonst beschwert sich der C#-Compiler!
{% endcapture %}
{% include tipp.html inhalt=tipp %}

---

### Aufgabe 5.2: Ampel-Schaltung
Programmiere eine Ampel-Logik:
Der Nutzer gibt die Farbe der Ampel ein (`"rot"`, `"gelb"`, `"grün"`).
- Bei `"rot"`: "Stehen bleiben!"
- Bei `"gelb"`: "Bremsbereit machen!"
- Bei `"grün"`: "Fahren!"
- Bei jeder anderen Eingabe: "Ampel ist defekt!"

Sorge dafür, dass die Eingabe auch funktioniert, wenn der Nutzer `"ROT"` oder `"Grün"` mit Großbuchstaben schreibt.

{% capture tipp %}
**Lösung / Tipp zu 5.2:**

Nutze `.ToLower()`, um die Eingabe vor der Prüfung in Kleinbuchstaben umzuwandeln:

```csharp
Console.Write("Welche Farbe zeigt die Ampel? ");
string farbe = Console.ReadLine()!.ToLower().Trim();

if (farbe == "rot")
{
    Console.WriteLine("Stehen bleiben!");
}
else if (farbe == "gelb")
{
    Console.WriteLine("Bremsbereit machen!");
}
else if (farbe == "grün")
{
    Console.WriteLine("Fahren!");
}
else
{
    Console.WriteLine("Ampel ist defekt!");
}
```
*Tipp:* `.Trim()` entfernt zusätzlich versehentliche Leerzeichen am Anfang oder Ende der Eingabe.
{% endcapture %}
{% include tipp.html inhalt=tipp %}
