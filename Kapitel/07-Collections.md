---
title: 07 - Arrays und Listen
parent: Kapitel
has_children: true
has_toc: false
nav_order: 7
---
# Kapitel 7 – Arrays und Listen

[← Schleifen](06-Schleifen.md) | [Übersicht](../README.md) | [Weiter: Methoden →](08-Methoden.md)

## Ziel

Nach diesem Kapitel kannst du:

- viele Werte in einem **Array** oder einer **Liste** speichern
- über den **Index** auf einzelne Werte zugreifen
- mit `foreach` alle Werte durchgehen

---

## Erklärung

Eine Variable speichert **einen** Wert. Für viele Werte (z. B. 30 Punktzahlen) brauchst du eine **Collection**.
Wie eine Variable hat auch jede Collection einen festen **Typ** – ein `int`-Array speichert nur `int`-Werte.

### Arrays – feste Größe

```csharp
int[] punkte = new int[4];   // Array mit 4 Plätzen, alle haben am Anfang den Wert 0
punkte[0] = 90;              // Der ERSTE Platz hat den Index 0!
punkte[3] = 75;              // Der LETZTE Platz hat den Index 3 (nicht 4!)

Console.WriteLine(punkte[0]);       // 90
Console.WriteLine(punkte.Length);   // 4 – die Größe des Arrays

// Ein Array kann auch direkt mit Werten angelegt werden:
string[] farben = { "Rot", "Grün", "Blau" };
```

Arrays erkennst du an den **eckigen Klammern** `[ ]`. Ihre Größe kann sich **nicht mehr ändern**.

{% capture notiz %}
In der Informatik beginnt man beim Zählen mit **0**. Ein Array mit 4 Plätzen hat die Indizes `0, 1, 2, 3`.
{% endcapture %}
{%include notiz.html typ="important" titel="Wichtig" offen=true inhalt=notiz %}

### Listen – flexible Größe

Listen können **wachsen und schrumpfen**. Eine neue Liste ohne Werte ist leer.

```csharp
List<string> fruechte = new List<string> { "Apfel", "Banane" };
fruechte.Add("Kirsche");       // hinten anhängen
fruechte.Remove("Banane");     // entfernen

Console.WriteLine(fruechte[0]);      // Zugriff über den Index wie beim Array
Console.WriteLine(fruechte.Count);   // Anzahl der Elemente (bei Listen: Count statt Length)

foreach (string frucht in fruechte)
{
    Console.WriteLine(frucht);
}
```

### Nützliche Listen-Befehle

| Befehl | Was er macht |
|---|---|
| `liste.Add(x)` | Fügt `x` hinten an |
| `liste.Remove(x)` | Entfernt `x` |
| `liste.Count` | Anzahl der Elemente |
| `liste.Contains(x)` | `true`, wenn `x` in der Liste ist |
| `liste.Sort()` | Sortiert die Liste |
| `liste.Clear()` | Leert die Liste komplett |

### `foreach` – alle Elemente durchgehen

```csharp
foreach (Typ variable in sammlung)
{
    // variable ist in jedem Durchgang das nächste Element
}
```

### Array oder Liste?

| | Array | Liste |
|---|---|---|
| Größe | fest | veränderbar |
| Anzahl | `.Length` | `.Count` |
| Gut für … | feste Mengen (z. B. 7 Wochentage) | Mengen, die sich ändern (z. B. Einkaufsliste) |

---

{% capture notiz %}
| Fehler | Was passiert |
|---|---|
| Zugriff auf einen Index, den es nicht gibt (`punkte[4]`) | Absturz: `IndexOutOfRangeException` |
| `.Length` bei einer Liste / `.Count` bei einem Array | Fehler – die Eigenschaft gibt es dort nicht |
| In einer `foreach`-Schleife Elemente hinzufügen oder entfernen | Absturz: Die Liste darf sich während `foreach` nicht verändern |
{% endcapture %}
{%include notiz.html typ="warning" titel="Typische Fehler" offen=false inhalt=notiz %}

---

## Aufgaben

### Aufgabe 7.1 – Vorhersage

1. Welche Ausgabe erwartest du beim Listen-Beispiel oben? Schreib sie auf und starte dann das Programm.
2. Füge zwei weitere Früchte hinzu und gib danach aus, wie viele Früchte in der Liste sind.

### Aufgabe 7.2 – An der Grenze

1. Was passiert, wenn du bei einem Array mit 4 Plätzen `punkte[4]` aufrufst? Wie heißt der Fehler?
2. Lege ein Array mit 5 Zahlen an und gib alle Werte mit einer **`for`-Schleife** aus. Benutze `punkte.Length` in der Bedingung.

### Aufgabe 7.3 – Zahlenstatistik

Schreibe ein Programm, das den Benutzer nach **5 Zahlen** fragt und sie in einer `List<int>` speichert.
Danach gibt es aus:

- die **Summe** aller Zahlen
- den **Durchschnitt**
- die **größte** Zahl

```
Zahl 1: 4
Zahl 2: 10
Zahl 3: 7
Zahl 4: 2
Zahl 5: 8
Summe: 31
Durchschnitt: 6,2
Größte Zahl: 10
```

Programmiere Summe und Maximum **selbst** mit einer Schleife.
{% capture tipp %}
- Summe: Starte mit `int summe = 0;` und addiere in einer `foreach`-Schleife jede Zahl dazu.
- Maximum: Merke dir am Anfang die erste Zahl als größte (`zahlen[0]`) und vergleiche jede weitere Zahl damit.
- Durchschnitt: Achtung, Ganzzahl-Division (Kapitel 3)! `31 / 5` ergibt sonst `6`.
{% endcapture %}
{% include tipp.html inhalt=tipp %}


{% capture notiz %}
Wenn deine Lösung funktioniert: Vergleiche dein Ergebnis mit `zahlen.Sum()`, `zahlen.Max()` und `zahlen.Average()`. Diese Befehle hat C# schon eingebaut.
{% endcapture %}
{%include notiz.html typ="note" titel="Zusatz" offen=true inhalt=notiz %}

---

## Checkliste

- [ ] Ich weiß, dass der erste Index immer `0` ist.
- [ ] Ich kann ein Array und eine Liste anlegen und Werte hineinschreiben.
- [ ] Ich kenne den Unterschied zwischen Array und Liste (und zwischen `.Length` und `.Count`).
- [ ] Ich kann mit `foreach` alle Elemente durchgehen.

---

Hast du noch weitere Fragen, bist bei einzelnen Themen noch unsicher oder möchtest einfach mehr Aufgaben zu diesem Kapitel bearbeiten? Schau dir gerne das Vertiefungskapitel an: \
[Klicke hier, um zur Vertiefung zu gelangen](../Vertiefung/07-Collections-Vertiefung.md)

---

[← Schleifen](06-Schleifen.md) | [Übersicht](../README.md) | [Weiter: Methoden →](08-Methoden.md)
