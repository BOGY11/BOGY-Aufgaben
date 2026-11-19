---
title: 02 - Variablen und Datentypen
parent: Kapitel
has_children: true
has_toc: false
nav_order: 2
---
# Kapitel 2 – Variablen und Datentypen

[← Erste Schritte](01-Erste-Schritte.md) | [Übersicht](../README.md) | [Weiter: Rechnen und Vergleichen →](03-Rechnen-und-Vergleichen.md)

## Ziel

Nach diesem Kapitel kannst du:

- Variablen anlegen, ändern und ausgeben
- den passenden Datentyp für einen Wert auswählen
- Variablen mit `$"..."` in einen Text einbauen

---

## Erklärung

### Was ist eine Variable?

Stell dir eine Variable wie eine **beschriftete Box** vor: Sie hat einen **Namen**, einen **Typ** (was darf hinein?) und einen **Wert** (was liegt gerade drin?).

```csharp
// Typ   Name     Wert
int      alter  = 25;
```

### Die wichtigsten Datentypen

| Typ | Wofür? | Beispiel |
|---|---|---|
| `string` | Text | `string name = "Anna";` |
| `int` | Ganze Zahlen | `int alter = 25;` |
| `double` | Kommazahlen | `double groesse = 1.72;` |
| `bool` | Wahr oder falsch | `bool istSchueler = true;` |
| `char` | Genau **ein** Zeichen | `char note = 'A';` |


{% capture notiz %}
- Im Code schreibst du Kommazahlen immer mit **Punkt**: `1.72` (nicht `1,72`).
- Text (`string`) steht in **doppelten** Anführungszeichen `"..."`, ein einzelnes Zeichen (`char`) in **einfachen** `'...'`.
{% endcapture %}
{%include notiz.html typ="important" titel="Wichtig" offen=true inhalt=notiz %}

### Werte ändern

Den Typ schreibst du nur **einmal** beim Anlegen. Danach änderst du den Wert nur noch über den Namen:

```csharp
int alter = 25;
alter = 26;   // Kein "int" mehr davor!
```

Jedes mal, wenn man nach dem Anlegen einer Variable einen Wert zuweisen will, wird der alte Wert überschrieben.
Es gibt also immer nur eine alter-Variable mit dem Wert 26 und der alte Wert, welcher bei der Erstellung zugewiesen wurde, ist nach neuer Zuweisung weg.

### Variablen ausgeben

```csharp
string name = "Anna";
int alter = 25;

Console.WriteLine($"Mein Name ist {name} und ich bin {alter} Jahre alt.");
Console.WriteLine("Mein Name ist " + name + " und ich bin " + alter + " Jahre alt.");
```

Beide Zeilen geben **dasselbe** aus.
Mit `$"..."` kannst du Variablen direkt in einen Text schreiben, indem du ihren Namen in **geschweifte Klammern** `{ }` setzt. Diese Variante ist meistens übersichtlicher.

### `var` und `const`

```csharp
var stadt = "Berlin";        // C# erkennt den Typ selbst → stadt ist ein string
const double Pi = 3.14159;   // const: Dieser Wert kann sich NIE ändern
```

### Regeln für Variablennamen

- Keine Leerzeichen, nicht mit einer Zahl beginnen: ~~`2tePunkte`~~, ~~`mein alter`~~
- Umlaute (ä, ö, ü, ß) sind erlaubt, aber unüblich. Schreib lieber `groesse` statt `größe`.
- Üblich ist **camelCase**: erstes Wort klein, jedes weitere groß → `anzahlSpieler`, `istVerfuegbar`
- Variablennamen müssen einzigartig sein. Es darf immer nur eine Variable des Typs int mit dem Namen "alter" geben (auch mit unterschiedlichen Datentypen).
- Strings müssen immer in doppelten Anführungszeichen ("...") angegeben werden.
- Wähle **aussagekräftige** Namen: `preis` statt `p`
- Die Benennung von Variablen ist sehr wichtig! Nur mit aussagekräftigen Namen kann jemand der den Code und Kontext nicht kennt den Code trotzdem verstehen

---

{% capture notiz %}
| Fehler | Beispiel | Was passiert |
|---|---|---|
| Typ passt nicht zum Wert | `int alter = "25";` | Fehler: `string` lässt sich nicht in `int` umwandeln |
| Kommazahl in `int` | `int preis = 19.99;` | Fehler: `double` lässt sich nicht in `int` umwandeln |
| Variable doppelt angelegt | `int a = 1;` … `int a = 2;` | Fehler: Der Name `a` ist schon vergeben |
| `{ }` ohne `$` | `"Hallo {name}"` | Es wird wirklich `{name}` ausgegeben statt des Namens |
{% endcapture %}
{%include notiz.html typ="warning" titel="Typische Fehler" offen=false inhalt=notiz %}

---

## Aufgaben

### Aufgabe 2.1 – Produktbeschreibung

Lege drei Variablen an: `produktName`, `preis` und `verfuegbar`.
Überlege dir **vorher**, welchen Datentyp du jeweils brauchst.
Gib dann einen Satz aus, in dem alle drei Variablen vorkommen.

Beispielausgabe:
```
Das Produkt Kopfhörer kostet 19,99 € und ist verfügbar: True
```

**Denkfrage:** Welchen Datentyp brauchst du, wenn ein Produkt `19.99` € kostet? Welcher würde bei `42` € reichen?


{% capture tipp %}
Hat der Wert Nachkommastellen? Dann reicht `int` nicht.
Ob etwas verfügbar ist, kann nur **ja** oder **nein** sein – welcher Typ passt dazu?
{% endcapture %}
{% include tipp.html inhalt=tipp %}

{% capture notiz %}
Wundere dich nicht: Auf einem deutschen Windows wird `19.99` als `19,99` ausgegeben. Im Code schreibst du trotzdem den Punkt.
{% endcapture %}
{%include notiz.html typ="note" titel="Hinweis" offen=true inhalt=notiz %}

### Aufgabe 2.2 – Sonderangebot

1. Erweitere dein Programm aus 2.1: Ändere nach der ersten Ausgabe den Preis (z. B. auf `14.99`) und gib den Satz **noch einmal** aus.
2. Lege eine Konstante an: `const double Mehrwertsteuer = 0.19;`
   Versuche danach, ihren Wert zu ändern. Was passiert?

   Schreibe das Ergebnis wieder als Kommentar in den Code

### Bonus-Aufgabe 2.3 – Steckbrief

Schreibe einen Steckbrief über dich (oder eine erfundene Person), in dem **jeder Datentyp aus der Tabelle** mindestens einmal vorkommt – auch `char` (z. B. dein Anfangsbuchstabe).
Gib ihn einmal mit `$"..."` und einmal mit `+` aus.


---

## Checkliste

- [ ] Ich kann eine Variable anlegen und ihren Wert ändern.
- [ ] Ich kenne `string`, `int`, `double`, `bool` und `char` und weiß, wann ich welchen Typ nutze.
- [ ] Ich kann Variablen mit `$"... {variable} ..."` ausgeben.
- [ ] Ich weiß, was `var` und `const` bedeuten.

---


Hast du noch weitere Fragen, bist bei einzelnen Themen noch unsicher oder möchtest einfach mehr Aufgaben zu diesem Kapitel bearbeiten? Schau dir gerne das Vertiefungskapitel an: \
[Klicke hier, um zur Vertiefung zu gelangen](../Vertiefung/02-Variablen-Vertiefung.md)

---

[← Erste Schritte](01-Erste-Schritte.md) | [Übersicht](../README.md) | [Weiter: Rechnen und Vergleichen →](03-Rechnen-und-Vergleichen.md)
