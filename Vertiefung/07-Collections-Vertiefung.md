---
title: 07 - Vertiefung Arrays und Listen
parent: 07 - Arrays und Listen
nav_order: 1
---
# Kapitel 7 – Collections (Vertiefung)

[← Zurück zu Kapitel 7](../Kapitel/07-Collections.md) | [Übersicht](../README.md) | [Weiter: Methoden Vertiefung →](08-Methoden-Vertiefung.md)

Eine Variable speichert genau einen Wert. Collections (Sammlungen) wie Arrays und Listen erlauben es dir, Dutzende oder Tausende Werte unter einem einzigen Namen zu verwalten.

---

## 1. Warum fängt der Index bei 0 an?

Die sogenannte **Nullbasierte Indizierung** (Zero-based Indexing) verwirrt fast jeden Einsteiger:
- Erstes Element: Index `0`
- Zweites Element: Index `1`
- Letztes Element bei 5 Elementen: Index `4`

### Der historische/technische Grund:
Stell dir den Arbeitsspeicher wie eine Straße vor. Ein Array liegt an einer bestimmten Startadresse (z. B. Hausnummer 100).
Der **Index ist der Abstand (Offset)** vom Startpunkt:
- `array[0]`: Gehe 0 Schritte vom Start weg -> Du stehst genau beim **ersten** Element.
- `array[1]`: Gehe 1 Schritt weiter -> Du stehst beim **zweiten** Element.

---

## 2. Array vs. List: Eierkarton vs. Notizzettel

| Eigenschaft | Array (`string[]`) | List (`List<string>`) |
|---|---|---|
| **Analogie** | Eierkarton: Feste Anzahl Mulden. Kann nicht vergrößert werden. | Notizzettel: Du kannst jederzeit Zeilen anhängen oder durchstreichen. |
| **Größe** | **Fest** (wird beim Erstellen definiert). | **Dynamisch** (wächst und schrumpft automatisch). |
| **Anzahl abfragen** | `.Length` | `.Count` |
| **Element hinzufügen** | Geht nicht direkt! | `liste.Add("Neues Element");` |
| **Element löschen** | Geht nicht direkt! | `liste.Remove("Element");` oder `liste.RemoveAt(0);` |

**Faustregel:** Nimm im Zweifelsfall fast immer `List<T>`, es sei denn, du weißt zu 100% im Voraus, dass sich die Anzahl niemals ändert (z. B. 7 Wochentage).

---

## 3. Die berüchtigte `IndexOutOfRangeException`

Dieser Fehler tritt auf, wenn du nach einem Index fragst, den es nicht gibt:
```csharp
string[] namen = { "Anna", "Ben", "Clara" }; // Länge = 3, Indizes: 0, 1, 2
Console.WriteLine(namen[3]); // BUMM! IndexOutOfRangeException!
```
*Warum?* Es gibt 3 Elemente, aber der höchste gültige Index ist `2`!
Die goldene Regel: **Der höchste Index ist immer `Länge - 1`!**

---

## 4. Die Kardinalsünde bei `foreach`

Verändere **niemals** eine Liste, während du mit `foreach` darüber iterierst:
```csharp
foreach (string name in namen)
{
    namen.Remove(name); // FEHLER! InvalidOperationException: Sammlung wurde geändert!
}
```
*Warum?* `foreach` führt Buch über den internen Zeiger. Wenn du währenddessen Elemente entfernst oder hinzufügst, gerät der Zeiger durcheinander.
*Lösung:* Wenn du filtern/löschen musst, nutze eine Rückwärts-`for`-Schleife oder erstelle eine neue Liste.

---

## 5. Vertiefungsaufgaben mit Tipps

### Aufgabe 7.1: Noten-Statistik mit `List<int>`
Erstelle eine `List<int>` mit Noten (z. B. `1, 2, 3, 2, 1, 4, 2`).
Berechne mithilfe einer Schleife:
1. Die Summe aller Noten
2. Den Notendurchschnitt (als Kommazahl `double`)
3. Wie oft die Note `1` vorkommt

{% capture tipp %}
**Lösung / Tipp zu 7.1:**

So kannst du die Liste mit einer `foreach`-Schleife analysieren:

```csharp
List<int> noten = new List<int> { 1, 2, 3, 2, 1, 4, 2 };

int summe = 0;
int anzahlEinsen = 0;

foreach (int note in noten)
{
    summe += note;
    if (note == 1)
    {
        anzahlEinsen++;
    }
}

double durchschnitt = (double)summe / noten.Count;

Console.WriteLine($"Anzahl Noten: {noten.Count}");
Console.WriteLine($"Durchschnitt: {durchschnitt:F2}");
Console.WriteLine($"Anzahl Einsen: {anzahlEinsen}");
```
*Tipp:* Achte auf `(double)summe / noten.Count`, damit die Ganzzahldivision verhindert wird!
{% endcapture %}
{% include tipp.html inhalt=tipp %}

---

### Aufgabe 7.2: Einkaufsliste interaktiv
Schreibe ein Programm mit einer `List<string> einkaufsliste`.
In einer Schleife kann der Nutzer:
- Einen Artikel eingeben (wird mit `.Add()` hinzugefügt).
- `"fertig"` eingeben, um die Eingabe zu beenden.

Gib am Ende alle Artikel nummeriert aus:
```text
Deine Einkaufsliste:
1. Milch
2. Brot
3. Äpfel
```

{% capture tipp %}
**Lösung / Tipp zu 7.2:**

Nutze eine `while(true)`-Schleife mit `break;` und gib die Liste danach mit einer `for`-Schleife aus:

```csharp
List<string> einkaufsliste = new List<string>();

while (true)
{
    Console.Write("Artikel hinzufügen (oder 'fertig'): ");
    string eingabe = Console.ReadLine()!.Trim();

    if (eingabe.ToLower() == "fertig")
    {
        break;
    }

    if (eingabe != "")
    {
        einkaufsliste.Add(eingabe);
    }
}

Console.WriteLine("\nDeine Einkaufsliste:");
for (int i = 0; i < einkaufsliste.Count; i++)
{
    Console.WriteLine($"{i + 1}. {einkaufsliste[i]}");
}
```
*Tipp:* Mit `${i + 1}` beginnt die Nummerierung für den Menschen bei 1, obwohl der Listen-Index bei 0 startet!
{% endcapture %}
{% include tipp.html inhalt=tipp %}
