---
title: 03 - Rechnen und Vergleichen
parent: Kapitel
has_children: true
has_toc: false
nav_order: 3
---
# Kapitel 3 – Rechnen und Vergleichen

[← Variablen](02-Variablen.md) | [Übersicht](../README.md) | [Weiter: Benutzereingaben →](04-Eingaben.md)

## Ziel

Nach diesem Kapitel kannst du:

- mit Variablen rechnen (inklusive Modulo `%`)
- erklären, warum `10 / 3` in C# manchmal `3` ergibt
- Werte vergleichen und Bedingungen mit `&&`, `||` und `!` verknüpfen

---

## Erklärung

### Rechenoperatoren

```csharp
int a = 10;
int b = 3;

Console.WriteLine(a + b);   // Addition
Console.WriteLine(a - b);   // Subtraktion
Console.WriteLine(a * b);   // Multiplikation
Console.WriteLine(a / b);   // Division
Console.WriteLine(a % b);   // Modulo: der REST einer Division
```

**Modulo** `%` gibt den Rest einer Division zurück: `10 % 3` ist `1`, denn 10 = 3 · 3 + **1**.
Das ist sehr praktisch, z. B. um herauszufinden, ob eine Zahl **gerade** ist (`zahl % 2` ergibt dann `0`).

Wie in Mathe gilt **Punkt vor Strich**. Mit Klammern `( )` legst du die Reihenfolge selbst fest.

### Kurzschreibweisen

```csharp
int punkte = 0;
punkte = punkte + 5;  // Erhöht punkte um 5
punkte += 5;          // Genau dasselbe, nur kürzer
punkte++;             // Erhöht punkte um 1
punkte--;             // Verringert punkte um 1
// Genauso gibt es: -=   *=   /=
```

### Vergleichsoperatoren

Vergleiche liefern **immer** `true` (wahr) oder `false` (falsch).

| Operator | Bedeutung | Beispiel (`a = 10`, `b = 3`) | Ergebnis |
|---|---|---|---|
| `==` | gleich | `a == b` | `false` |
| `!=` | ungleich | `a != b` | `true` |
| `>` | größer | `a > b` | `true` |
| `<` | kleiner | `a < b` | `false` |
| `>=` | größer oder gleich | `a >= 10` | `true` |
| `<=` | kleiner oder gleich | `b <= 2` | `false` |

{% capture notiz %}
`=` und `==` sind **nicht** dasselbe!
`=` **weist zu** („speichere den Wert“), `==` **vergleicht** („sind beide gleich?“).
{% endcapture %}
{%include notiz.html typ="warning" titel="Achtung" offen=true inhalt=notiz %}


### Logikoperatoren

Mit Logikoperatoren verknüpfst du mehrere Aussagen:

| Operator | Name | Ergebnis ist `true`, wenn … |
|---|---|---|
| `&&` | UND | **beide** Aussagen wahr sind |
| <code>&#124;&#124;</code> | ODER | **mindestens eine** Aussage wahr ist |
| `!` | NICHT | die Aussage **falsch** ist (dreht `true`/`false` um) |

```csharp
int alter = 15;
bool istTeenager = alter >= 13 && alter < 20;   // true
bool darfAutofahren = alter >= 18;              // false
bool istKeinTeenager = !istTeenager;            // false

Console.WriteLine($"Teenager: {istTeenager}");
```

---

{% capture notiz %}
| Fehler | Was passiert |
|---|---|
| `if (a = 5)` statt `if (a == 5)` | Fehler – `=` ist eine Zuweisung, kein Vergleich |
| Zwei ganze Zahlen teilen | `7 / 2` ergibt `3`, nicht `3.5` (siehe Aufgabe 3.2) |
| Klammern vergessen | `2 + 3 * 4` ergibt `14`, nicht `20` |
{% endcapture %}
{% include notiz.html typ="warning" titel="Typische Fehler" offen=false inhalt=notiz %}

---

## Aufgaben

### Aufgabe 3.1 – Erst denken, dann starten

Schreib **zuerst** einen Kommentar über den Code, welche fünf Zahlen der Code unter „Rechenoperatoren“ ausgibt. Starte ihn dann und vergleiche.
Lagst du überall richtig?

### Aufgabe 3.2 – Das Rätsel von `10 / 3`

1. Warum gibt `Console.WriteLine(a / b);` den Wert `3` aus und nicht `3.333...`?
   Denke daran, welchen Datentyp `a` und `b` haben.
2. Ändere den Code so, dass `3.333...` ausgegeben wird. Findest du **zwei** verschiedene Wege?

{% capture tipp %}
Kann ein `int` überhaupt Nachkommastellen speichern?
Weg 1: Ändere den Typ der Variablen. Weg 2: Schreibe `(double)` vor `a` – damit wandelst du `a` für diese Rechnung in eine Kommazahl um.
{% endcapture %}
{% include tipp.html inhalt=tipp %}

### Aufgabe 3.3 – Zeit umrechnen

Lege eine Variable `int sekundenGesamt = 3725;` an. Rechne aus, wie viele Stunden, Minuten und Sekunden das sind, und gib das Ergebnis aus:

```
3725 Sekunden sind 1 Stunde(n), 2 Minute(n) und 5 Sekunde(n).
```

Teste dein Programm auch mit `86399` (Ergebnis: 23 Stunden, 59 Minuten, 59 Sekunden).

{% capture tipp %}
Eine Stunde hat 3600 Sekunden, eine Minute 60.
Mit `/` bekommst du, wie oft etwas **ganz** hineinpasst, mit `%` den **Rest**, der übrig bleibt.
{% endcapture %}
{% include tipp.html inhalt=tipp %}

### Aufgabe 3.4 – Wahr oder falsch?

Gegeben ist `int x = 7;` und `int y = 12;`. Notiere für jede Zeile, ob `true` oder `false` herauskommt. Prüfe danach mit `Console.WriteLine(...)`.

```csharp
x < y
x == 7 && y == 10
x > 10 || y > 10
!(x == 7)
x % 2 == 1
```

---

## Checkliste

- [ ] Ich kann mit `+`, `-`, `*`, `/` und `%` rechnen und weiß, was Modulo macht.
- [ ] Ich weiß, warum `10 / 3` bei `int` den Wert `3` ergibt, und wie ich `3.333...` bekomme.
- [ ] Ich kenne den Unterschied zwischen `=` und `==`.
- [ ] Ich kann Bedingungen mit `&&`, `||` und `!` verknüpfen.

---

Hast du noch weitere Fragen, bist bei einzelnen Themen noch unsicher oder möchtest einfach mehr Aufgaben zu diesem Kapitel bearbeiten? Schau dir gerne das Vertiefungskapitel an: \
[Klicke hier, um zur Vertiefung zu gelangen](../Vertiefung/03-Rechnen-und-Vergleichen-Vertiefung.md)

---

[← Variablen](02-Variablen.md) | [Übersicht](../README.md) | [Weiter: Benutzereingaben →](04-Eingaben.md)
