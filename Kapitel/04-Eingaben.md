---
title: 04 - Benutzereingaben
parent: Kapitel
has_children: true
has_toc: false
nav_order: 4
---
# Kapitel 4 – Benutzereingaben

[← Rechnen und Vergleichen](03-Rechnen-und-Vergleichen.md) | [Übersicht](../README.md) | [Weiter: Verzweigungen →](05-Verzweigungen.md)

## Ziel

Nach diesem Kapitel kannst du:

- Eingaben des Benutzers mit `Console.ReadLine()` lesen
- Text in Zahlen umwandeln (`int.Parse`, `double.Parse`)
- dein erstes **wirklich nützliches** Programm schreiben

---

## Erklärung

### Eingaben lesen

```csharp
Console.Write("Wie heißt du? ");
string name = Console.ReadLine();

Console.Write("Wie alt bist du? ");
int alter = int.Parse(Console.ReadLine());

Console.WriteLine($"Hallo {name}! Nächstes Jahr wirst du {alter + 1}.");
```

`Console.ReadLine()` wartet, bis der Benutzer etwas eintippt und **Enter** drückt.
Das Ergebnis ist **immer** ein `string` – auch wenn jemand eine Zahl eintippt!

### Text in Zahlen umwandeln („Parsen“)

Mit einem `string` kannst du nicht rechnen. Deshalb wandelst du die Eingabe um:

| Du brauchst … | Schreibweise |
|---|---|
| eine ganze Zahl | `int zahl = int.Parse(Console.ReadLine());` |
| eine Kommazahl | `double zahl = double.Parse(Console.ReadLine());` |

Warum das nötig ist, siehst du hier:

```csharp
string text = "5";
int zahl = 5;
Console.WriteLine(text + 3);   // Ausgabe: 53  (Text wird aneinandergehängt!)
Console.WriteLine(zahl + 3);   // Ausgabe: 8   (es wird gerechnet)
```


{% capture notiz %}
Bei der **Eingabe** von Kommazahlen im Terminal gilt auf einem deutschen Windows das **Komma**: Tippe `1,5` statt `1.5`.
(Im **Code** schreibst du dagegen immer den Punkt.)
{% endcapture %}
{%include notiz.html typ="important" titel="Wichtig" offen=true inhalt=notiz %}


---

{% capture notiz %}
| Fehler | Was passiert |
|---|---|
| `int alter = Console.ReadLine();` | Fehler: Ein `string` ist kein `int` – du musst `int.Parse(...)` benutzen |
| Benutzer tippt `abc` statt einer Zahl | Das Programm **stürzt ab** (`FormatException`). Wie man das verhindert, lernst du in [Kapitel 10](10-Fehler-abfangen.md). |
| Grüne Wellenlinie unter `Console.ReadLine()` | Nur eine **Warnung**, kein Fehler. Du kannst sie vorerst ignorieren. |
{% endcapture %}
{%include notiz.html typ="warning" titel="Typische Fehler" offen=false inhalt=notiz %}

---

## Aufgaben

### Aufgabe 4.1 – Wie alt bist du dieses Jahr?

Frage den Benutzer nach seinem **Namen** und seinem **Geburtsjahr**. Rechne aus, wie alt er in diesem Jahr wird, und gib das aus:

```
Wie heißt du? Max
In welchem Jahr bist du geboren? 2010
Hallo Max, du wirst dieses Jahr 16 Jahre alt.
```

{% capture tipp %}
Du kannst das aktuelle Jahr erst einmal als Zahl in eine Variable schreiben.
Profis lassen es sich vom Computer geben: `int jahr = DateTime.Now.Year;`
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Aufgabe 4.2 – Temperatur-Umrechner

Frage den Benutzer nach einer Temperatur in **Celsius** und rechne sie in **Fahrenheit** um.

Formel: **Fahrenheit = Celsius · 9 / 5 + 32**

Beispielausgabe:
```
Temperatur in Celsius: 28
Die Temperatur 28° Celsius entspricht circa 82° Fahrenheit.
```

Danach: Was musst du ändern, damit das **genaue** Ergebnis (`82,4`) angezeigt wird?

{% capture tipp %}
Denk an Kapitel 3: Was passiert, wenn man zwei `int`-Werte teilt?
Probiere auch einmal `celsius * (9 / 5) + 32` aus. Warum kommt da etwas Falsches heraus?
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Aufgabe 4.3 – Mini-Rechner

Frage den Benutzer nach **zwei ganzen Zahlen** und gib alle fünf Rechenarten aus:

```
Erste Zahl: 17
Zweite Zahl: 5
17 + 5 = 22
17 - 5 = 12
17 * 5 = 85
17 / 5 = 3
17 % 5 = 2
```

### Bonus-Aufgabe 4.4 – Absturz-Detektiv

1. Starte deinen Mini-Rechner und gib statt einer Zahl `abc` ein. Was passiert? Wie heißt der Fehler in der Meldung?
2. Ändere den Temperatur-Umrechner auf `double.Parse` und gib einmal `1,5` und einmal `1.5` ein. Was fällt dir auf?

Merke dir die Ergebnisse – in [Kapitel 10](10-Fehler-abfangen.md) lösen wir das Problem.

---

## Checkliste

- [ ] Ich kann mit `Console.ReadLine()` eine Eingabe lesen.
- [ ] Ich weiß, dass `ReadLine()` immer einen `string` liefert.
- [ ] Ich kann Eingaben mit `int.Parse` und `double.Parse` in Zahlen umwandeln.
- [ ] Ich weiß, warum `celsius * 9 / 5` und `celsius * (9 / 5)` unterschiedliche Ergebnisse liefern.

---

Hast du noch weitere Fragen, bist bei einzelnen Themen noch unsicher oder möchtest einfach mehr Aufgaben zu diesem Kapitel bearbeiten? Schau dir gerne das Vertiefungskapitel an: \
[Klicke hier, um zur Vertiefung zu gelangen](../Vertiefung/04-Eingaben-Vertiefung.md)

---

[← Rechnen und Vergleichen](03-Rechnen-und-Vergleichen.md) | [Übersicht](../README.md) | [Weiter: Verzweigungen →](05-Verzweigungen.md)
