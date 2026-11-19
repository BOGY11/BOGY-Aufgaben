---
title: 01 - Vertiefung Erste Schritte
parent: 01 - Erste Schritte
nav_order: 1
---
# Kapitel 1 – Erste Schritte (Vertiefung)

[← Zurück zu Kapitel 1](../Kapitel/01-Erste-Schritte.md) | [Übersicht](../README.md) | [Weiter: Variablen Vertiefung →](02-Variablen-Vertiefung.md)

Dieses Dokument ist für dich gedacht, wenn nach Kapitel 1 noch Fragezeichen geblieben sind oder du genau verstehen möchtest, was der Computer im Hintergrund eigentlich tut.

---

## 1. Das mentale Modell: Wie der Computer deinen Code liest

Stell dir den **Compiler** (das Programm, das deinen C#-Code in Maschinensprache übersetzt) wie einen extrem sturen Roboter vor:
- Er liest deinen Code **streng von oben nach unten** und **Zeile für Zeile**.
- Er errät **nichts**. Wenn du ein Zeichen vergisst oder falsch schreibst, bricht er sofort ab.
- Er unterscheidet penibel zwischen Groß- und Kleinschreibung (`Console` ist für ihn völlig anders als `console`).

### Der Aufbau der Standardzeile

```csharp
Console.WriteLine("Hallo Welt!");
```

1. **`Console` (Wo?):** Die Konsole bzw. das Ausgabefenster.
2. **`.` (Zugriff):** Der Punkt bedeutet: „Gehe in diesen Bereich und hole mir dort etwas heraus“.
3. **`WriteLine` (Was tun?):** Die Methode / der Befehl, der Text schreibt und die Schreibmarke in die nächste Zeile setzt.
4. **`("Hallo Welt!")` (Womit?):** Die sogenannten **Parameter** bzw. Argumente. In den runden Klammern übergibst du die Information, die verarbeitet werden soll.
5. **`;` (Stop/Ende):** Das Semikolon ist der Punkt am Satzende. Ohne Semikolon weiß C# nicht, wo der Befehl aufhört.

---

## 2. `Write` vs. `WriteLine` im Detail

Viele verwechseln anfangs, **wann** der Zeilenumbruch passiert.

- **`Console.WriteLine(...)`:** Schreibt den Text und drückt danach gedanklich die **Enter-Taste**. Die nächste Ausgabe landet in einer neuen Zeile.
- **`Console.Write(...)`:** Schreibt den Text und lässt die Schreibmarke **direkt hinter dem letzten Buchstaben** stehen.

### Visueller Vergleich:

```csharp
Console.Write("A");
Console.Write("B");
Console.WriteLine("C");
Console.Write("D");
```

**Ausgabe:**
```text
ABC
D
```

*Erklärung:* "A" wird geschrieben, "B" direkt dahinter, "C" direkt dahinter. Erst *nach* dem "C" sorgt `WriteLine` für den Zeilensprung. "D" beginnt daher in Zeile 2.

---

## 3. Typische Stolpersteine

### A. Der Backslash `\` in Texten (Escape-Sequenzen)
In C# kündigt ein Backslash `\` ein Sonderzeichen an:
- `\n` = Neuer Zeilenumbruch (Linebreak)
- `\t` = Tabulator (Einrückung)
- `\"` = Ein echtes Anführungszeichen innerhalb des Textes
- `\\` = Ein einzelner Backslash

Wenn du ein ASCII-Bild malen willst, z. B. ein Dach `/\`, meckert C# bei `Console.WriteLine("/\");`, weil er denkt, `\"` maskiert das Anführungszeichen.
**Lösung:** Entweder verdoppeln `"/\\"` oder ein `@` voranstellen (Verbatim String): `@"/\".`

### B. Die Fehlermeldung richtig entschlüsseln
Schau dir die Fehlermeldung genau an:
```text
Program.cs(5,21): error CS1002: ; erwartet.
```
- `Program.cs`: Die Datei, in der der Fehler liegt.
- `(5,21)`: **Zeile 5**, Zeichenspalte 21. Klicke in Visual Studio doppelt auf die Zeile in der Fehlerliste, um direkt zur Stelle zu springen!

---

## 4. Vertiefungsaufgaben mit Tipps

### Aufgabe 1.1: Visitenkarte im Terminal
Schreibe ein Konsolenprogramm, das eine kleine Visitenkarte formatiert ausgibt:
```text
==============================
Name:     Max Mustermann
Rolle:    C# Lernender
Ort:      Karlsruhe
==============================
```
Nutze dafür gezielt `Console.WriteLine`.

{% capture tipp %}
**Lösung / Tipp zu V1.1:**

Hier ist ein sauberer Lösungsweg:
```csharp
Console.WriteLine("==============================");
Console.WriteLine("Name:     Max Mustermann");
Console.WriteLine("Rolle:    C# Lernender");
Console.WriteLine("Ort:      Karlsruhe");
Console.WriteLine("==============================");
```
*Tipp:* Du kannst die Abstände entweder mit normalen Leerzeichen ausrichten oder die Escape-Sequenz `\t` (Tabulator) ausprobieren:
`Console.WriteLine("Name:\tMax Mustermann");`
{% endcapture %}
{% include tipp.html inhalt=tipp %}

---

### Aufgabe 1.2: Satzpuzzle mit `Write`
Setze folgenden Satz mit genau drei `Console.Write` und einem abschließenden `Console.WriteLine` zusammen, sodass er in **einer einzigen Zeile** steht:
- Wort 1: "C#"
- Wort 2: "macht"
- Wort 3: "richtig"
- Wort 4: "Spaß!"

Achte darauf, wo Leerzeichen stehen müssen!

{% capture tipp %}
**Lösung / Tipp zu V1.2:**

Wenn du `Console.Write` benutzt, werden keine Leerzeichen automatisch eingefügt. Du musst sie selbst in den Text schreiben:

```csharp
Console.Write("C# ");
Console.Write("macht ");
Console.Write("richtig ");
Console.WriteLine("Spaß!");
```
*Wichtig:* Vergiss nicht das Leerzeichen nach jedem Wort (oder vor dem nächsten Wort), sonst kleben die Wörter zusammen: `"C#machtrichtigSpaß!"`.
{% endcapture %}
{% include tipp.html inhalt=tipp %}
