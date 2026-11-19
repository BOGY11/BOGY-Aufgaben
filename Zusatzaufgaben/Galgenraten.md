---
title: 1 - Galgenraten
parent: Zusatzaufgaben
nav_order: 1
---
# Zusatzaufgabe 1 – Galgenraten

**Schwierigkeit:** Leicht (Niveau Abschlussprojekt) · **Dauer:** ca. 1–1,5 Stunden

[← Abschlussprojekt](../Kapitel/11-Abschlussprojekt.md) | [Übersicht](../README.md) | [Weiter: Zusatzaufgabe 2 – Snackautomat →](Snackautomat.md)

## Ziel

Du programmierst den Klassiker **Galgenraten** (auch „Hangman“ genannt):
Der Computer wählt ein geheimes Wort aus, und du errätst es Buchstabe für Buchstabe.
Bei zu vielen falschen Buchstaben hast du verloren.

Wie beim Abschlussprojekt arbeitest du in **Stufen**. Bring zuerst eine Stufe zum Laufen, bevor du mit der nächsten beginnst.

---

## Was du brauchst

| Thema | Kapitel |
|---|---|
| Variablen, Eingaben, `if`, Schleifen | [2](../Kapitel/02-Variablen.md) – [6](../Kapitel/06-Schleifen.md) |
| Arrays und Listen | [7](../Kapitel/07-Collections.md) |
| Methoden | [8](../Kapitel/08-Methoden.md) |

---

## Neu: Einzelne Zeichen (`char`)

Ein `string` besteht aus vielen einzelnen **Zeichen**. Ein einzelnes Zeichen hat den Datentyp `char`
und steht in **einfachen** Anführungszeichen: `'A'`. Text steht weiterhin in doppelten: `"A"`.

```csharp
string wort = "KATZE";

char erster = wort[0];             // 'K' – wie bei einem Array: Index 0 ist das erste Zeichen
Console.WriteLine(wort.Length);    // 5

foreach (char zeichen in wort)     // geht jedes Zeichen einzeln durch
{
    Console.Write(zeichen + " ");  // K A T Z E
}

bool drin = wort.Contains('T');    // true – ist das Zeichen im Wort?
```

Ein paar weitere Helfer, die du brauchst:

| Befehl | Was er macht |
|---|---|
| `text.ToUpper()` | Macht alles groß: `"katze"` → `"KATZE"` |
| `char.IsLetter(zeichen)` | `true`, wenn das Zeichen ein Buchstabe ist (keine Ziffer, kein Leerzeichen …) |
| `Random.Shared.Next(5)` | Zufallszahl von **0 bis 4** – perfekt für einen zufälligen Array-Index |

So wählst du ein zufälliges Wort aus einem Array:

```csharp
string[] woerter = { "KATZE", "COMPUTER", "PIZZA" };
string geheim = woerter[Random.Shared.Next(woerter.Length)];
```


{% capture notiz %}
`'A'` und `'a'` sind für den Computer **verschiedene** Zeichen. Wandle deshalb Wort **und** Eingabe in Großbuchstaben um.
{% endcapture %}
{%include notiz.html typ="important" titel="Wichtig" offen=true inhalt=notiz %}

---

## Die Stufen

### Stufe 1 – Das Grundspiel

- Lege ein Array mit mindestens **8 Wörtern** an (alle in Großbuchstaben). Der Computer wählt zufällig eins aus.
- Speichere alle geratenen Buchstaben in einer `List<char>`.
- Zeige das Wort verdeckt an: Erratene Buchstaben sind sichtbar, alle anderen sind `_`.
- Ist ein Buchstabe **nicht** im Wort, zählt das als Fehler. Nach **8 Fehlern** ist das Spiel verloren.
- Am Ende gibt das Programm aus, ob du gewonnen oder verloren hast – und wie das Wort lautete.

```
Neues Spiel! Errate das Wort.

Wort: _ _ _ _ _
Fehler: 0 von 8
Dein Buchstabe: a
Treffer!

Wort: _ A _ _ _
Fehler: 0 von 8
Dein Buchstabe: o
Leider nicht drin.

Wort: _ A _ _ _
Fehler: 1 von 8
Dein Buchstabe: t
Treffer!
...
Gewonnen! Das Wort war KATZE. Du hattest 2 Fehler.
```

Schreibe für diese Stufe mindestens diese zwei **Methoden**:

| Methode | Aufgabe |
|---|---|
| `string VerdecktesWort(string wort, List<char> geraten)` | Gibt z. B. `"_ A T _ _ "` zurück |
| `bool IstGeloest(string wort, List<char> geraten)` | `true`, wenn **jeder** Buchstabe des Worts schon geraten wurde |

{% capture tipp %}
Starte mit einem leeren Text `string anzeige = "";`.
Geh mit `foreach` durch jedes Zeichen des Worts. Ist das Zeichen in der Liste `geraten`, hänge es an `anzeige` an – sonst ein `_`.
Vergiss das Leerzeichen dahinter nicht, sonst sieht man nicht, wie viele Striche es sind.
{% endcapture %}
{% include tipp.html inhalt=tipp %}


{% capture tipp %}
Geh wieder durch jedes Zeichen des Worts. Findest du **ein** Zeichen, das noch **nicht** geraten wurde, kannst du sofort `return false;` machen.
Kommst du am Ende der Schleife an, waren alle geraten → `return true;`
{% endcapture %}
{% include tipp.html inhalt=tipp %}


{% capture tipp %}
Das Spiel läuft, **solange** noch nicht 8 Fehler gemacht wurden **und** das Wort noch nicht gelöst ist:

```csharp
while (fehler < 8 && !IstGeloest(wort, geraten))
{
    // ...
}
```
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Stufe 2 – Keine Abstürze, keine Doppelten

- Gibt der Spieler **nichts**, **mehrere Zeichen** oder **keinen Buchstaben** ein (z. B. `7`), kommt ein Hinweis und er wird erneut gefragt.
  Schreibe dafür eine Methode `char LiesBuchstabe(string frage)` – ähnlich wie deine `LiesZahl`-Methode aus Kapitel 10.
- Wurde ein Buchstabe **schon einmal** geraten, gibt es einen Hinweis. Das zählt **nicht** als Fehler.
- Zeige bei jeder Runde an, welche Buchstaben schon geraten wurden.

```
Wort: _ A _ _ _
Fehler: 1 von 8
Bereits geraten: A, O
Dein Buchstabe: ab
Bitte genau einen Buchstaben eingeben: a
A hast du schon geraten!
```

{% capture tipp %}
- Probiere zuerst aus, was in Stufe 1 passiert, wenn du einfach **Enter** drückst. Welche Exception bekommst du – und warum?
- Die Bedingung für „Eingabe ungültig“ lautet: Länge ist **nicht** 1 **oder** das Zeichen ist **kein** Buchstabe.
  Achte auf die Reihenfolge: Prüfe die Länge **zuerst**!
- Für die Anzeige der geratenen Buchstaben hilft `string.Join(", ", geraten)`. Das verbindet alle Elemente einer Liste zu einem Text.
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Stufe 3 – Mehrere Runden mit Statistik

- Verschiebe eine komplette Spielrunde in eine Methode `bool SpieleRunde(string[] woerter)`. Sie gibt `true` zurück, wenn gewonnen wurde.
- Nach jeder Runde fragt das Spiel: `Nochmal spielen? (j/n)`
- Zähle mit, wie viele Runden gewonnen und verloren wurden, und gib das nach jeder Runde aus:

```
Statistik: 2 gewonnen, 1 verloren
Nochmal spielen? (j/n):
```

---

## Typische Fehler

| Fehler | Was passiert |
|---|---|
| `"A"` statt `'A'` | Fehler: Ein `string` ist kein `char` |
| Eingabe nicht mit `ToUpper()` umgewandelt | `a` wird nie gefunden, weil im Wort nur `A` vorkommt |
| `eingabe[0]` bei leerer Eingabe | Absturz: `IndexOutOfRangeException` |
| Doppelte Buchstaben im Wort (z. B. `PIZZA`) | Kein Problem, wenn du mit `Contains` arbeitest – teste es trotzdem! |

---

## Extras

Such dir aus, was dir gefällt:

- **Der Galgen:** Zeichne den Galgen mit `Console.WriteLine`. Je mehr Fehler, desto mehr Teile kommen dazu. Speichere die 9 Bilder (0–8 Fehler) als `string`-Array.
- **Zwei Spieler:** Spieler 1 gibt das geheime Wort ein. Danach wird der Bildschirm mit `Console.Clear();` gelöscht und Spieler 2 rät.
- **Kategorien:** Am Anfang wählt der Spieler mit `switch` eine Kategorie (Tiere, Essen, Sport …). Jede Kategorie hat ein eigenes Wort-Array.
- **Ganzes Wort raten:** Gibt der Spieler mehr als einen Buchstaben ein, ist das ein Versuch, das **ganze Wort** zu raten. Falsch geraten kostet 2 Fehler.

---

## Checkliste

- [ ] Ich weiß, was ein `char` ist und wie er sich von einem `string` unterscheidet.
- [ ] Ich kann mit `foreach` durch alle Zeichen eines Worts gehen.
- [ ] Mein Spiel stürzt bei keiner Eingabe ab.
- [ ] Ich habe mindestens drei eigene Methoden geschrieben.

[← Abschlussprojekt](../Kapitel/11-Abschlussprojekt.md) | [Übersicht](../README.md) | [Weiter: Schere-Stein-Papier →](Schere-Stein-Papier.md)
