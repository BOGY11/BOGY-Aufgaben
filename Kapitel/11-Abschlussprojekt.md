---
title: 11 - Abschlussprojekt
parent: Kapitel
has_children: true
has_toc: false
nav_order: 11
---
# Kapitel 11 – Abschlussprojekt: Zahlenraten

[← Fehler abfangen](10-Fehler-abfangen.md) | [Übersicht](../README.md) | [Weiter: Galgenraten →](../Zusatzaufgaben/Galgenraten.md)

## Ziel

Jetzt setzt du alles zusammen, was du gelernt hast, und baust ein **komplettes Spiel**.
Das Projekt ist in **Stufen** aufgeteilt. Bring zuerst eine Stufe zum Laufen, bevor du mit der nächsten beginnst – so hast du immer ein funktionierendes Spiel.

---

Wenn du dir bei den Aufgaben unsicher bist oder nicht weißt, wo du anfangen sollst, schau dir die Vertiefung für eine detailliertere Erklärung an: \
[Klicke hier, um zur Vertiefung zu gelangen](../Vertiefung/11-Abschlussprojekt-Vertiefung.md)

---

## Neu: Zufallszahlen

```csharp
int geheimeZahl = Random.Shared.Next(1, 101);   // Zufallszahl von 1 bis 100
```

{% capture notiz %}
Die **zweite** Zahl ist **nicht** mehr dabei! `Next(1, 101)` liefert Zahlen von 1 bis **100**.
{% endcapture %}
{%include notiz.html typ="important" titel="Wichtig" offen=true inhalt=notiz %}

---

## Die Stufen

### Stufe 1 – Das Grundspiel

- Der Computer denkt sich eine Zahl zwischen 1 und 100 aus.
- Der Spieler rät. Nach jedem Tipp sagt der Computer `Größer!` oder `Kleiner!`.
- Bei der richtigen Zahl gibt er aus, wie viele Versuche gebraucht wurden.

```
Ich denke mir eine Zahl zwischen 1 und 100 aus. Rate mal!
Dein Tipp: 50
Größer!
Dein Tipp: 75
Kleiner!
Dein Tipp: 63
Richtig! Die Zahl war 63. Du hast 3 Versuche gebraucht.
```

*Du brauchst: Variablen, Eingaben, Verzweigungen, Schleifen (Kapitel 2–6)*

{% capture tipp %}
Welche Schleife passt am besten? Der Spieler muss **mindestens einmal** raten …
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Stufe 2 – Absturzsicher und mit Neustart

- Benutze deine absturzsichere `LiesZahl`-Methode aus Kapitel 10.
- Tipps außerhalb von 1–100 werden nicht gezählt (gib einen Hinweis aus).
- Nach einer Runde fragt das Spiel: `Nochmal spielen? (j/n)`

*Du brauchst: Methoden, Fehler abfangen (Kapitel 8 + 10)*

### Stufe 3 – Schwierigkeitsgrade

Der Spieler wählt am Anfang einen Schwierigkeitsgrad aus (mit `switch`):

| Stufe | Zahlenbereich | Maximale Versuche |
|---|---|---|
| Leicht | 1–50 | unbegrenzt |
| Mittel | 1–100 | 10 |
| Schwer | 1–1000 | 10 |

Sind alle Versuche aufgebraucht, hat der Spieler verloren und erfährt die geheime Zahl.

### Bonus Stufe 4 – Highscore und Extras

Such dir aus, was dir gefällt:

- **Highscore:** Lege eine Klasse `Spieler` an (`Name`, `BesteVersuche`). Speichere alle Spieler in einer Liste und zeige am Ende eine Bestenliste.
- **Heiß oder kalt:** Ist der Tipp weniger als 5 von der Zahl entfernt, gib `Sehr heiß!` aus, bei weniger als 15 `Warm`, sonst `Kalt`.
- **Tauschen:** Jetzt denkst **du** dir eine Zahl aus und der Computer rät! Du antwortest mit `g` (größer), `k` (kleiner) oder `r` (richtig). Wie schafft es der Computer mit möglichst wenigen Versuchen?

---


## Was du in diesem Projekt alles benutzt

- [ ] Variablen und Datentypen (Kapitel 2)
- [ ] Rechnen und Vergleichen (Kapitel 3)
- [ ] Benutzereingaben (Kapitel 4)
- [ ] Verzweigungen mit `if` und `switch` (Kapitel 5)
- [ ] Schleifen (Kapitel 6)
- [ ] Listen (Kapitel 7, Stufe 4)
- [ ] Eigene Methoden (Kapitel 8)
- [ ] Eigene Klassen (Kapitel 9, Stufe 4)
- [ ] Fehler abfangen (Kapitel 10)

---

## Geschafft!

Herzlichen Glückwunsch – du hast die Grundlagen der Programmierung mit C# gelernt!
Zeig dein Spiel ruhig den anderen Praktikant*innen oder deiner Betreuungsperson.

**Wie geht es weiter?**
Wenn du zu Hause weitermachen möchtest: Die offizielle C#-Dokumentation von Microsoft gibt es auch auf Deutsch – mit vielen Tutorials für Einsteiger: [learn.microsoft.com/de-de/dotnet/csharp](https://learn.microsoft.com/de-de/dotnet/csharp)

[← Fehler abfangen](10-Fehler-abfangen.md) | [Übersicht](../README.md) | [Weiter: Galgenraten →](../Zusatzaufgaben/Galgenraten.md)
