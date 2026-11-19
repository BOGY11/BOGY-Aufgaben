---
title: 08 - Methoden
parent: Kapitel
has_children: true
has_toc: false
nav_order: 8
---
# Kapitel 8 – Methoden

[← Arrays und Listen](07-Collections.md) | [Übersicht](../README.md) | [Weiter: Klassen und Objekte →](09-Klassen.md)

## Ziel

Nach diesem Kapitel kannst du:

- eigene Methoden schreiben und aufrufen
- Werte als **Parameter** übergeben
- Ergebnisse mit `return` zurückgeben

---

## Erklärung

Eine **Methode** ist ein Stück Code mit einem Namen. Du schreibst ihn **einmal** und kannst ihn danach **beliebig oft** aufrufen.
Eine Methode sollte möglichst **genau eine Aufgabe** erledigen. `Console.WriteLine` ist übrigens auch eine Methode!

### Aufbau einer Methode

```
Rückgabetyp  Name     (Parameter)
    int      Addiere  (int x, int y)
{
    // Code
    return ergebnis;
}
```

| Teil | Bedeutung |
|---|---|
| **Rückgabetyp** | Welchen Typ das Ergebnis hat (`int`, `string`, `bool` …). `void` heißt: Die Methode gibt **nichts** zurück. |
| **Name** | Wird üblicherweise **großgeschrieben** und beschreibt eine Tätigkeit: `Addiere`, `Gruesse`, `IstGerade` |
| **Parameter** | Werte, die du der Methode mitgibst. Es können keine, einer oder mehrere sein. |
| **`return`** | Gibt das Ergebnis zurück und beendet die Methode |

### Beispiel

```csharp
// --- Hauptprogramm: Methoden aufrufen ---
Gruesse("Lea");

int ergebnis = Addiere(3, 4);
Console.WriteLine(ergebnis);   // 7

// --- Methoden: stehen UNTER dem Hauptprogramm ---
void Gruesse(string name)             // void = gibt nichts zurück
{
    Console.WriteLine($"Hallo, {name}!");
}

int Addiere(int x, int y)             // gibt einen int zurück
{
    int summe = x + y;
    return summe;
}
```


{% capture notiz %}
In `Program.cs` schreibst du deine Methoden einfach **unter** den restlichen Code. Du kannst sie trotzdem schon weiter oben aufrufen.
{% endcapture %}
{%include notiz.html typ="note" titel="Hinweis" offen=true inhalt=notiz %}

### Variablen leben nur in ihrer Methode

Eine Variable, die **in** einer Methode angelegt wird (wie `summe`), gibt es nur dort. Außerhalb kennt das Programm sie nicht. Deshalb gibst du Ergebnisse mit `return` zurück.

---

{% capture notiz %}
| Fehler | Was passiert |
|---|---|
| `return` vergessen (bei Rückgabetyp ≠ `void`) | Fehler: „Nicht alle Codepfade geben einen Wert zurück“ |
| Falscher Typ zurückgegeben | Fehler – eine `bool`-Methode darf keinen `string` zurückgeben |
| Klammern beim Aufruf vergessen: `Gruesse;` | Fehler – Methoden rufst du immer mit `( )` auf |
| Falsche Anzahl Parameter: `Addiere(3)` | Fehler – die Methode erwartet zwei Werte |
{% endcapture %}
{%include notiz.html typ="warning" titel="Typische Fehler" offen=false inhalt=notiz %}

---

## Aufgaben

### Aufgabe 8.1 – `IstGerade`

Schreibe eine Methode `IstGerade`, die eine ganze Zahl als Parameter bekommt und `true` oder `false` zurückgibt.
Benutze sie in einer Schleife von 1 bis 10:

```
1 ist ungerade.
2 ist gerade.
3 ist ungerade.
...
```
{% capture tipp %}
Der Rückgabetyp ist `bool`. Wie du prüfst, ob eine Zahl gerade ist, steht in Kapitel 3 und 5.
Wusstest du, dass du einen Vergleich direkt zurückgeben kannst? `return zahl % 2 == 0;`
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Aufgabe 8.2 – Temperaturtabelle

Schreibe eine Methode `double InFahrenheit(double celsius)` (die Formel kennst du aus Aufgabe 4.2).
Gib damit eine Tabelle von -10 °C bis 40 °C in 10er-Schritten aus:

```
-10 °C = 14 °F
0 °C = 32 °F
10 °C = 50 °F
...
```

### Aufgabe 8.3 – `LiesZahl`

In fast jedem Programm hast du diese zwei Zeilen geschrieben:

```csharp
Console.Write("Erste Zahl: ");
int a = int.Parse(Console.ReadLine());
```

Schreibe eine Methode `int LiesZahl(string frage)`, die diese Arbeit übernimmt. Danach reicht eine Zeile:

```csharp
int a = LiesZahl("Erste Zahl: ");
```

Baue deinen **Mini-Rechner** aus Aufgabe 4.3 damit um. Wie viel kürzer wird er?

{% capture notiz %}
Heb dir `LiesZahl` gut auf! In Kapitel 10 machst du die Methode absturzsicher und benutzt sie im Abschlussprojekt.
{% endcapture %}
{%include notiz.html typ="important" titel="Wichtig" offen=true inhalt=notiz %}

### Aufgabe 8.4 – Denkfrage

Warum ist eine Methode besser, als denselben Code mehrmals zu kopieren? Finde mindestens **zwei** Gründe.

{% capture tipp %}
Stell dir vor, du hast den Code 10-mal kopiert und findest dann einen Fehler darin …
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Bonus-Aufgabe 8.5 – Statistik aufräumen

Baue deine Zahlenstatistik aus Aufgabe 7.3 um: Schreibe die Methoden `int Summe(List<int> zahlen)`, `int Maximum(List<int> zahlen)` und `double Durchschnitt(List<int> zahlen)`.

---

## Checkliste

- [ ] Ich kann eine Methode mit und ohne Rückgabewert schreiben.
- [ ] Ich weiß, was `void` bedeutet.
- [ ] Ich kann einer Methode Parameter übergeben.
- [ ] Ich weiß, warum Variablen aus einer Methode außerhalb nicht sichtbar sind.

---

Hast du noch weitere Fragen, bist bei einzelnen Themen noch unsicher oder möchtest einfach mehr Aufgaben zu diesem Kapitel bearbeiten? Schau dir gerne das Vertiefungskapitel an: \
[Klicke hier, um zur Vertiefung zu gelangen](../Vertiefung/08-Methoden-Vertiefung.md)

---

[← Arrays und Listen](07-Collections.md) | [Übersicht](../README.md) | [Weiter: Klassen und Objekte →](09-Klassen.md)
