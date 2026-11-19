---
title: 06 - Vertiefung Schleifen
parent: 06 - Schleifen
nav_order: 1
---
# Kapitel 6 – Schleifen (Vertiefung)

[← Zurück zu Kapitel 6](../Kapitel/06-Schleifen.md) | [Übersicht](../README.md) | [Weiter: Collections Vertiefung →](07-Collections-Vertiefung.md)

Schleifen automatisieren Wiederholungen. Sie sind eines der mächtigsten Werkzeuge in der Programmierung, führen aber oft zu "Off-by-One"-Fehlern (Einer zu viel / Einer zu wenig) oder Endlosschleifen.

---

## 1. Die `for`-Schleife in Einzelschritten verstehen

Schau dir diesen Kopf ganz genau an:
```csharp
for (int i = 0; i < 3; i++)
{
    Console.WriteLine($"Runde: {i}");
}
```

Hier ist die **exakte Chronologie**, wie C# das ausführt:

| Schritt | Was passiert? | Zustand von `i` | Wird der Schleifenkörper ausgeführt? |
|---|---|---|---|
| **1. Start** | `int i = 0` wird **einmalig** ausgeführt. | `i = 0` | - |
| **2. Test** | Prüfung: `i < 3`? `0 < 3` ist `true`! | `i = 0` | **Ja!** Gibt "Runde: 0" aus. |
| **3. Schritt** | `i++` zählt um 1 hoch. | `i = 1` | - |
| **4. Test** | Prüfung: `i < 3`? `1 < 3` ist `true`! | `i = 1` | **Ja!** Gibt "Runde: 1" aus. |
| **5. Schritt** | `i++` zählt um 1 hoch. | `i = 2` | - |
| **6. Test** | Prüfung: `i < 3`? `2 < 3` ist `true`! | `i = 2` | **Ja!** Gibt "Runde: 2" aus. |
| **7. Schritt** | `i++` zählt um 1 hoch. | `i = 3` | - |
| **8. Test** | Prüfung: `i < 3`? `3 < 3` ist **`false`**! | `i = 3` | **Abbruch!** Die Schleife stoppt. |

### Off-by-One: `<` vs. `<=`
- `i < 5` (startend bei 0) läuft für: `0, 1, 2, 3, 4` -> **5 Durchläufe**.
- `i <= 5` (startend bei 0) läuft für: `0, 1, 2, 3, 4, 5` -> **6 Durchläufe**.

---

## 2. Kopfgesteuert vs. Fußgesteuert: `while` vs. `do-while`

- **`while (bedingung)` (Kopfgesteuert):** Prüft **vor** dem ersten Durchlauf. Wenn die Bedingung schon am Anfang falsch ist, läuft die Schleife **0 Mal**!
- **`do { ... } while (bedingung);` (Fußgesteuert):** Läuft **garantiert mindestens einmal**, weil die Prüfung erst ganz am Ende am "Fuß" steht. Ideal für Menüabfragen: Erst anzeigen und nachfragen, dann prüfen, ob wiederholt werden soll!

---

## 3. Die Steuerungs-Befehle: `break` und `continue`

- **`break` (Notbremse):** Bricht die Schleife **sofort komplett ab** und springt hinter die schließende geschweifte Klammer `}`.
- **`continue` (Runde überspringen):** Bricht nur den **aktuellen Durchlauf** ab und springt direkt zur nächsten Runde (zum nächsten Schritt/Test).

---

## 4. Vertiefungsaufgaben mit Tipps

### Aufgabe 6.1: Das kleine 1x1 einer Zahl
Frage den Nutzer nach einer Zahl (z. B. `7`). Gib dann mit einer `for`-Schleife die Multiplikationstabelle von 1 bis 10 aus:
```text
1 x 7 = 7
2 x 7 = 14
...
10 x 7 = 70
```

{% capture tipp %}
**Lösung / Tipp zu 6.1:**

Starte die Zählschleife bei 1 und lasse sie bis einschließlich 10 laufen:

```csharp
Console.Write("Welche Zahl soll multipliziert werden? ");
int zahl = int.Parse(Console.ReadLine()!);

for (int i = 1; i <= 10; i++)
{
    int ergebnis = i * zahl;
    Console.WriteLine($"{i} x {zahl} = {ergebnis}");
}
```
{% endcapture %}
{% include tipp.html inhalt=tipp %}

---

### Aufgabe 6.2: Geheimzahl erraten mit `while`
Lege eine feste Geheimzahl fest (z. B. `42`).
Lasse den Nutzer in einer `while`-Schleife so lange Zahlen raten, bis er die richtige Zahl trifft.
Gib nach jedem falschen Versuch aus: "Leider falsch, versuche es noch einmal!"
Gib bei Erfolg aus: "Glückwunsch, du hast die Zahl erraten!"

{% capture tipp %}
**Lösung / Tipp zu 6.2:**

Hier ist eine saubere Umsetzung mit `while`:

```csharp
const int geheimzahl = 42;
int tipp = 0;

Console.WriteLine("Errate die Geheimzahl zwischen 1 und 100!");

while (tipp != geheimzahl)
{
    Console.Write("Dein Tipp: ");
    tipp = int.Parse(Console.ReadLine()!);

    if (tipp != geheimzahl)
    {
        Console.WriteLine("Leider falsch, versuche es noch einmal!\n");
    }
}

Console.WriteLine("Glückwunsch, du hast die Zahl erraten!");
```
*Tipp:* Achte darauf, `tipp` vor der Schleife mit einem Wert zu initialisieren, der garantiert ungleich der Geheimzahl ist (z. B. `0`), damit die Schleife überhaupt erst startet!
{% endcapture %}
{% include tipp.html inhalt=tipp %}
