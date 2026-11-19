---
title: 05 - Verzweigungen
parent: Kapitel
has_children: true
has_toc: false
nav_order: 5
---
# Kapitel 5 – Verzweigungen

[← Benutzereingaben](04-Eingaben.md) | [Übersicht](../README.md) | [Weiter: Schleifen →](06-Schleifen.md)

## Ziel

Nach diesem Kapitel kannst du:

- dein Programm mit `if`, `else if` und `else` Entscheidungen treffen lassen
- mehrere Bedingungen kombinieren
- einen Wert mit `switch` gegen viele Möglichkeiten prüfen

---

## Erklärung

Bisher lief dein Programm immer von oben nach unten durch. Mit einer **Verzweigung** entscheidet es selbst, welcher Code ausgeführt wird.

### `if` / `else if` / `else` („falls / sonst falls / sonst“)

```csharp
Console.Write("Gib dein Alter ein: ");
int alter = int.Parse(Console.ReadLine());

if (alter >= 18)
{
    Console.WriteLine("Du bist erwachsen.");
}
else if (alter >= 13)
{
    Console.WriteLine("Du bist ein Teenager.");
}
else
{
    Console.WriteLine("Du bist ein Kind.");
}
```

**So läuft das ab:**

1. Die Bedingungen werden **von oben nach unten** geprüft.
2. Der Block der **ersten** wahren Bedingung wird ausgeführt.
3. Danach springt das Programm **hinter** die gesamte Verzweigung – alle weiteren `else if`/`else` werden übersprungen.
4. Ist keine Bedingung wahr, wird der `else`-Block ausgeführt (falls es einen gibt).

### Mehrere Bedingungen kombinieren

```csharp
if (alter >= 13 && alter <= 19)
{
    Console.WriteLine("Du bist zwischen 13 und 19.");
}
```

### `switch` – ein Wert, viele Möglichkeiten

Ein `switch` ist praktisch, wenn du **einen** Wert mit **vielen festen** Möglichkeiten vergleichst:

```csharp
Console.Write("Welcher Tag ist heute? ");
string tag = Console.ReadLine();

switch (tag)
{
    case "Montag":
        Console.WriteLine("Oh nein, es ist Montag! Komm gut durch die Woche.");
        break;
    case "Mittwoch":
        Console.WriteLine("Bergfest! Die halbe Woche ist geschafft.");
        break;
    case "Freitag":
        Console.WriteLine("Fast geschafft! Bald ist Wochenende!");
        break;
    case "Samstag":
    case "Sonntag":                    // Mehrere Fälle können sich einen Code teilen
        Console.WriteLine("Yippie, Wochenende!");
        break;
    default:                           // Wird ausgeführt, wenn KEIN case passt
        Console.WriteLine("Ein ganz normaler Tag.");
        break;
}
```

- Jeder `case` endet mit `break;` – damit wird der `switch` verlassen.
- `default` fängt alle Werte ab, für die es keinen `case` gibt.

{% capture tipp %}
`switch` unterscheidet Groß- und Kleinschreibung: `"montag"` passt **nicht** zu `"Montag"`.
Mit `tag.ToLower()` machst du die Eingabe komplett klein – dann musst du die `case`-Werte natürlich auch kleinschreiben.
{% endcapture %}
{% include tipp.html inhalt=tipp %}

---

{% capture notiz %}
| Fehler | Was passiert |
|---|---|
| `if (alter >= 18);` – Semikolon nach der Klammer | Der Block darunter wird **immer** ausgeführt, egal ob die Bedingung stimmt! |
| `if (zahl = 0)` | Fehler – zum Vergleichen brauchst du `==` |
| `break;` im `switch` vergessen | Fehler: Das Programm darf nicht einfach in den nächsten `case` „durchfallen“ |
| Ungerade Zahl mit `zahl % 2 == 1` prüfen | Funktioniert bei **negativen** Zahlen nicht: `-3 % 2` ergibt `-1`! Prüfe lieber `zahl % 2 != 0`. |
{% endcapture %}
{%include notiz.html typ="warning" titel="Typische Fehler" offen=false inhalt=notiz %}

---

## Aufgaben

### Aufgabe 5.1 – Denkfrage: Warum `else if`?

Im Alters-Beispiel steht `else if (alter >= 13)`. Was würde passieren, wenn dort nur `if (alter >= 13)` stünde?
Probiere es mit dem Alter `20` aus und erkläre, was passiert.

### Aufgabe 5.2 – Zahlen-Check

Frage den Benutzer nach einer ganzen Zahl. Das Programm soll ausgeben, ob die Zahl **positiv, negativ oder null** ist und ob sie **gerade oder ungerade** ist.

```
Gib eine Zahl ein: 0
Die Zahl 0 ist weder positiv noch negativ, aber trotzdem gerade.

Gib eine Zahl ein: -7
Die Zahl -7 ist eine ungerade negative Zahl.
```

{% capture tipp %}
Kümmere dich zuerst um den Sonderfall `0`. Für alle anderen Zahlen kannst du die Wörter („positive“/„negative“, „gerade“/„ungerade“) in zwei `string`-Variablen speichern und am Ende einen Satz daraus bauen.
Gerade heißt: `zahl % 2 == 0`.
{% endcapture %}
{% include tipp.html inhalt=tipp %}

### Bonus-Aufgabe 5.3 – Kinokasse

Frage nach **Alter** und **Wochentag** und berechne den Eintrittspreis:

- Kinder unter 12 Jahren: 6 €
- Jugendliche von 12 bis 17: 8 €
- Erwachsene: 10 €
- Am **Dienstag** (Kinotag) ist **jeder** Preis 2 € günstiger.

---

## Checkliste

- [ ] Ich kann `if`, `else if` und `else` richtig einsetzen.
- [ ] Ich weiß, dass nur der **erste** passende Block ausgeführt wird.
- [ ] Ich kann Bedingungen mit `&&` und `||` kombinieren.
- [ ] Ich kann einen `switch` mit `case`, `break` und `default` schreiben.

---

Hast du noch weitere Fragen, bist bei einzelnen Themen noch unsicher oder möchtest einfach mehr Aufgaben zu diesem Kapitel bearbeiten? Schau dir gerne das Vertiefungskapitel an: \
[Klicke hier, um zur Vertiefung zu gelangen](../Vertiefung/05-Verzweigungen-Vertiefung.md)

---

[← Benutzereingaben](04-Eingaben.md) | [Übersicht](../README.md) | [Weiter: Schleifen →](06-Schleifen.md)
