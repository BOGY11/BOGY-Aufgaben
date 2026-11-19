---
title: 06 - Schleifen
parent: Kapitel
has_children: true
has_toc: false
nav_order: 6
---
# Kapitel 6 – Schleifen

[← Verzweigungen](05-Verzweigungen.md) | [Übersicht](../README.md) | [Weiter: Arrays und Listen →](07-Collections.md)

## Ziel

Nach diesem Kapitel kannst du:

- Code mit `for`, `while` und `do-while` wiederholen
- entscheiden, welche Schleife für welche Aufgabe passt
- Schleifen mit `break` und `continue` steuern

---

## Erklärung

Schleifen (englisch *loops*) führen Code **mehrfach** aus. So musst du ihn nur einmal schreiben, statt ihn zehnmal zu kopieren.

### `for`-Schleife – wenn du weißt, wie oft

```csharp
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Zähler: {i}");
}
```

Die Klammer hat **drei Teile**, getrennt durch `;`:

| Teil | Beispiel | Wann? |
|---|---|---|
| Start | `int i = 1` | **einmal** ganz am Anfang |
| Bedingung | `i <= 5` | **vor jedem** Durchgang |
| Schritt | `i++` | **nach jedem** Durchgang |

**Schritt für Schritt:**

1. Die Variable `i` wird einmal angelegt (`i = 1`).
2. Die Bedingung wird geprüft (`i <= 5`).
   - Wahr → der Code in der Schleife läuft.
   - Falsch → die Schleife ist beendet.
3. Nach dem Code wird der Schritt ausgeführt (`i++`).
4. Zurück zu Schritt 2.

### `while`-Schleife – solange etwas gilt

```csharp
int nummer = 10;
while (nummer > 0)
{
    Console.WriteLine(nummer);
    nummer -= 3;
}
```

Die `while`-Schleife läuft, **solange** die Bedingung wahr ist. Sie ist praktisch, wenn du **vorher nicht weißt**, wie oft wiederholt wird.

### `do-while`-Schleife – mindestens einmal

```csharp
string eingabe;
do
{
    Console.Write("Schreibe 'ende', um zu beenden: ");
    eingabe = Console.ReadLine();
} while (eingabe != "ende");
```

Hier wird die Bedingung erst **am Ende** geprüft. Der Code läuft also **immer mindestens einmal** – perfekt für Abfragen wie „Wiederhole, bis die Eingabe stimmt“.

### `foreach`-Schleife – für Listen

Mit `foreach` gehst du alle Elemente einer Liste durch. Die lernst du im [nächsten Kapitel](07-Collections.md) richtig kennen.

### Welche Schleife wann?

| Situation | Schleife |
|---|---|
| Ich weiß genau, wie oft (z. B. 10-mal) | `for` |
| Wiederholen, solange eine Bedingung gilt | `while` |
| Mindestens einmal ausführen, dann prüfen | `do-while` |
| Alle Elemente einer Liste durchgehen | `foreach` |

### `break` und `continue`

```csharp
for (int i = 1; i <= 10; i++)
{
    if (i == 3)
    {
        continue;   // überspringt den Rest – weiter mit i = 4
    }
    if (i == 6)
    {
        break;      // beendet die Schleife sofort
    }
    Console.WriteLine(i);
}
// Ausgabe: 1, 2, 4, 5
```

---

{% capture notiz %}
| Fehler | Was passiert |
|---|---|
| In einer `while`-Schleife wird die Variable nie verändert | **Endlosschleife** – das Programm hört nie auf. Stoppen mit **Strg + C** oder durch Schließen des Fensters. |
| `<` und `<=` verwechselt | Die Schleife läuft einmal zu oft oder zu wenig |
| Semikolon nach der Klammer: `for (...);` | Der Block darunter läuft nur **einmal** |
{% endcapture %}
{%include notiz.html typ="warning" titel="Typische Fehler" offen=false inhalt=notiz %}

---

## Aufgaben

### Aufgabe 6.1 – Denkfragen

Beantworte die Fragen **zuerst im Kopf** und prüfe sie dann im Code.

1. Was passiert in der `for`-Schleife oben, wenn `i` mit `6` statt mit `1` startet? Wie oft läuft sie?
2. Was passiert bei dieser Schleife?
   ```csharp
   for (int i = 1; i > 0; i++)
   {
       Console.WriteLine($"Zähler: {i}");
   }
   ```
3. Welche Zahlen gibt das `while`-Beispiel aus? Warum nicht die `0`?
4. Wann endet das `do-while`-Beispiel? Was passiert, wenn du `Ende` (mit großem E) eintippst?

{% capture tipp %}
Wird `i` jemals kleiner als `0`? Lass die Schleife ruhig laufen (Abbruch mit **Strg + C**).
Spannend für Profis: Ein `int` kann höchstens `2147483647` speichern. Was passiert danach?
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Aufgabe 6.2 – Zählen

1. Gib die Zahlen von **1 bis 10** aus.
2. Gib nur die **geraden** Zahlen von 2 bis 20 aus. Schaffst du es auf **zwei** Arten? (Einmal mit `i += 2`, einmal mit `%`.)
3. Schreibe einen **Countdown** von 10 bis 1. Danach soll `Start!` erscheinen.

### Bonus-Aufgabe 6.3 – FizzBuzz

Ein Klassiker, der auch in echten Bewerbungsgesprächen gestellt wird: Gib die Zahlen von 1 bis 100 aus. Aber:

- Ist die Zahl durch 3 teilbar, gib `Fizz` aus.
- Ist sie durch 5 teilbar, gib `Buzz` aus.
- Ist sie durch 3 **und** 5 teilbar, gib `FizzBuzz` aus.

### Bonus-Aufgabe 6.4 – Sternen-Treppe

Frage nach einer Höhe und zeichne eine Treppe aus Sternen:

```
Höhe: 4
*
**
***
****
```

{% capture tipp %}
Du brauchst eine Schleife **in** einer Schleife: Die äußere zählt die Zeilen, die innere schreibt die Sterne mit `Console.Write("*")`.

{% endcapture %}
{% include tipp.html inhalt=tipp %}


---

## Checkliste

- [ ] Ich kann die drei Teile einer `for`-Schleife erklären.
- [ ] Ich kenne den Unterschied zwischen `while` und `do-while`.
- [ ] Ich weiß, wann ich welche Schleife nutze.
- [ ] Ich weiß, was `break` und `continue` machen.
- [ ] Ich kann eine Endlosschleife erkennen und stoppen.

---

Hast du noch weitere Fragen, bist bei einzelnen Themen noch unsicher oder möchtest einfach mehr Aufgaben zu diesem Kapitel bearbeiten? Schau dir gerne das Vertiefungskapitel an: \
[Klicke hier, um zur Vertiefung zu gelangen](../Vertiefung/06-Schleifen-Vertiefung.md)

---

[← Verzweigungen](05-Verzweigungen.md) | [Übersicht](../README.md) | [Weiter: Arrays und Listen →](07-Collections.md)
