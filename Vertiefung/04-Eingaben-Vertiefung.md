---
title: 04 - Vertiefung Benutzereingaben
parent: 04 - Benutzereingaben
nav_order: 1
---
# Kapitel 4 – Eingaben (Vertiefung)

[← Zurück zu Kapitel 4](../Kapitel/04-Eingaben.md) | [Übersicht](../README.md) | [Weiter: Verzweigungen Vertiefung →](05-Verzweigungen-Vertiefung.md)

Die Interaktion mit dem Nutzer über `Console.ReadLine()` bringt eine fundamentale Neuerung: Das Programm verhält sich plötzlich dynamisch und reagiert auf Tastatureingaben. Hier erfährst du, was dabei im Hintergrund passiert.

---

## 1. Wie `Console.ReadLine()` funktioniert

Wenn das Programm die Zeile:
```csharp
string eingabe = Console.ReadLine();
```
erreicht, friert die Programmausführung ein und wartet.
- Der Nutzer tippt Zeichen in die Konsole (diese landen im sogenannten **Eingabepuffer**).
- Erst wenn der Nutzer **Enter** drückt, liest `Console.ReadLine()` den gesamten Text bis zum Zeilenumbruch aus.
- **Wichtig:** Das Ergebnis ist **immer ein `string`** – selbst wenn der Nutzer nur Zahlen wie `42` eingetippt hat!

### Warum `string` + `string` nicht rechnet:
```csharp
string a = "10";
string b = "20";
Console.WriteLine(a + b); // Ausgabe: 1020 (Textverkettung!)
```
Das Pluszeichen `+` klebt Texte zusammen. Damit gerechnet werden kann, müssen die Zeichenketten in echte Zahlen umgewandelt werden.

---

## 2. Was bedeutet "Parsen" (`int.Parse`)?

Das englische Wort *to parse* bedeutet „eine Struktur analysieren und zerlegen“.
Wenn du `int.Parse("123")` aufrufst:
1. Prüft C# Zeichen für Zeichen: `'1'`, `'2'`, `'3'`.
2. Wandelt es die Zeichen in den binären Integer-Wert `123` um.
3. **Problem:** Wenn im Text ein Buchstabe steht (`"12a"`), weiß C# nicht weiter und das Programm **stürzt mit einem Fehler ab** (`FormatException`). Wie man das elegant verhindert, lernst du in Kapitel 10.

---

## 3. Die Tücke mit Kommazahlen: Punkt vs. Komma

In C# gibt es einen wichtigen Kultur-Unterschied:
- **Im Code** schreibst du immer den englischen Punkt: `double d = 1.5;`
- **Bei der Konsoleneingabe** über `double.Parse(Console.ReadLine())` musst du ebenfalls einen Punkt `1.5` schreiben

---

## 4. Die grüne Wellenlinie: `string?` und Nullable

Vielleicht hast du in Visual Studio eine grüne oder gelbe Warnlinie bei `Console.ReadLine()` bemerkt:
```text
CS8600: Das NULL-Literal oder ein möglicher NULL-Wert wird in einen Non-Nullable-Typ konvertiert.
```
*Was bedeutet das?*
`Console.ReadLine()` kann theoretisch `null` zurückgeben (wenn der Eingabestrom geschlossen wird). Wenn du die Warnung loswerden willst, kannst du entweder:
```csharp
string? eingabe = Console.ReadLine(); // Das Fragezeichen erlaubt "null"
```
oder
```csharp
string eingabe = Console.ReadLine()!; // Das Ausrufezeichen sagt: "Ich garantiere, dass hier Text kommt!"
```
schreiben. Für deine ersten Schritte kannst du die Warnung aber auch einfach ignorieren.

---

## 5. Vertiefungsaufgaben mit Tipps

### Aufgabe 4.1: Der Rabatt-Rechner
Schreibe ein Konsolenprogramm, das:
1. Den Originalpreis eines Produkts abfragt (z. B. `50`).
2. Den Rabatt in Prozent abfragt (z. B. `20`).
3. Den errechneten Sparbetrag und den neuen Endpreis ausgibt:
```text
Originalpreis: 50.00 €
Rabatt (20%):  10.00 €
Endpreis:      40.00 €
```

{% capture tipp %}
**Lösung / Tipp zu 4.1:**

Denke daran, beide Eingaben in `double` umzuwandeln und die Prozentrechnung durchzuführen:

```csharp
Console.Write("Gib den Originalpreis ein: ");
double preis = double.Parse(Console.ReadLine()!);

Console.Write("Gib den Rabatt in Prozent ein (z. B. 20): ");
double rabattProzent = double.Parse(Console.ReadLine()!);

double ersparnis = preis * (rabattProzent / 100.0);
double endpreis = preis - ersparnis;

Console.WriteLine();
Console.WriteLine($"Originalpreis: {preis:F2} €");
Console.WriteLine($"Rabatt ({rabattProzent}%):  {ersparnis:F2} €");
Console.WriteLine($"Endpreis:      {endpreis:F2} €");
```
*Tipp:* `{preis:F2}` formatiert die Kommazahl auf genau 2 Nachkommastellen!
{% endcapture %}
{% include tipp.html inhalt=tipp %}

---

### Aufgabe 4.2: Namens-Kombinierer
Frage den Nutzer nach:
1. Vorname
2. Nachname
3. Geburtsjahr

Gib anschließend einen automatisch generierten Benutzernamen aus, der aus dem ersten Buchstaben des Vornamens, dem vollen Nachnamen und den letzten beiden Ziffern des Geburtsjahres besteht:
*Beispiel:* `Max`, `Mustermann`, `1998` -> `mmustermann98`

{% capture tipp %}
**Lösung / Tipp zu 4.2:**

Du kannst mit `ToLower()` alles kleinschreiben und mit Modulo `% 100` die letzten beiden Ziffern des Jahres herausfiltern:

```csharp
Console.Write("Vorname: ");
string vorname = Console.ReadLine()!;

Console.Write("Nachname: ");
string nachname = Console.ReadLine()!;

Console.Write("Geburtsjahr: ");
int jahr = int.Parse(Console.ReadLine()!);

// Erster Buchstabe des Vornamens (Index 0)
char vornameInitial = vorname[0];

// Letzte zwei Ziffern des Jahres (z. B. 1998 % 100 = 98)
int kurzJahr = jahr % 100;

string benutzername = $"{vornameInitial}{nachname}{kurzJahr}".ToLower();

Console.WriteLine($"Dein generierter Benutzername: {benutzername}");
```
{% endcapture %}
{% include tipp.html inhalt=tipp %}
