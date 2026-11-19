---
title: 6 - Tic-Tac-Toe mit Computergegner
parent: Zusatzaufgaben
nav_order: 6
---
# Zusatzaufgabe 6 – Tic-Tac-Toe mit Computergegner

**Schwierigkeit:** Schwer · **Dauer:** ca. 3 Stunden

[← Zusatzaufgabe 2 – Snackautomat](Snackautomat.md) | [Übersicht](../README.md)

## Ziel

Du programmierst **Tic-Tac-Toe** – zuerst für zwei Spieler, danach gegen den Computer.
Am Ende baust du dem Computer ein bisschen **künstliche Intelligenz** ein, damit er nicht mehr so leicht zu schlagen ist.

Das Schwierige an dieser Aufgabe ist nicht ein einzelner Befehl, sondern die **Planung**:
Welche Klasse ist wofür zuständig? Wie prüft man, ob jemand gewonnen hat? Wie „denkt“ ein Computer?

---

## Was du brauchst

Eigentlich **alles** aus dem Tutorial – besonders:

| Thema | Kapitel |
|---|---|
| Arrays und Listen | [7](../Kapitel/07-Collections.md) |
| Methoden mit Rückgabewert | [8](../Kapitel/08-Methoden.md) |
| Klassen | [9](../Kapitel/09-Klassen.md) |
| Sichere Eingaben | [10](../Kapitel/10-Fehler-abfangen.md) |
| `char` | [Zusatzaufgabe 1](Galgenraten.md) |

---

## Neu: Das Spielfeld als Array

Das Spielfeld hat 9 Felder. Für den Spieler sind sie von **1 bis 9** nummeriert, im Array von **0 bis 8**:

```
 Spieler sieht:        Im Array:
  1 | 2 | 3            [0] [1] [2]
 ---+---+---
  4 | 5 | 6            [3] [4] [5]
 ---+---+---
  7 | 8 | 9            [6] [7] [8]
```

Jedes Feld speichert einen `char`: `'X'`, `'O'` oder `' '` (Leerzeichen = frei).

### Neu: Private Variablen in einer Klasse

Bisher hatten deine Klassen nur **Eigenschaften** (`{ get; set; }`). Eine Klasse kann sich aber auch Dinge **intern** merken, die von außen niemand sehen soll:

```csharp
public class Spielfeld
{
    private char[] felder = new char[9];   // nur die Klasse selbst kommt da ran

    public void Setzen(int feld, char zeichen)
    {
        felder[feld - 1] = zeichen;        // Spieler zählt ab 1, das Array ab 0
    }
}
```

Von außen kann man das Spielfeld also **nur über die Methoden** verändern. So kann niemand aus Versehen ein Feld überschreiben.

{% capture notiz %}
Überlege dir **vor** dem Programmieren auf Papier, welche Methoden dein Spielfeld braucht. Die Tabelle in Stufe 1 hilft dir dabei.
{% endcapture %}
{%include notiz.html typ="note" titel="Ansatz" offen=true inhalt=notiz %}

---

## Die Stufen

### Stufe 1 – Spielfeld und Züge

Lege eine Klasse `Spielfeld` in einer eigenen Datei an:

| Methode | Aufgabe |
|---|---|
| Konstruktor | Füllt alle 9 Felder mit `' '` |
| `void Leeren()` | Setzt alle Felder wieder auf `' '` (für eine neue Runde) |
| `void Anzeigen()` | Zeichnet das Spielfeld. **Freie** Felder zeigen ihre Nummer, damit der Spieler weiß, was er eingeben muss. |
| `bool IstFrei(int feld)` | `true`, wenn das Feld zwischen 1 und 9 liegt **und** noch frei ist |
| `void Setzen(int feld, char zeichen)` | Setzt `'X'` oder `'O'` auf das Feld |
| `bool IstVoll()` | `true`, wenn kein Feld mehr frei ist |

In `Program.cs` setzen die Spieler `X` und `O` **abwechselnd**, bis das Feld voll ist.
Ist ein Feld belegt oder die Eingabe ungültig, wird erneut gefragt.

```
 1 | 2 | 3
---+---+---
 4 | X | 6
---+---+---
 O | 8 | 9

Spieler X, wähle ein Feld (1-9): 5
Dieses Feld geht nicht. Bitte ein freies Feld wählen: 3
```

{% capture tipp %}
Eine Zeile des Spielfelds besteht aus den Feldern `start`, `start + 1` und `start + 2`. Für die drei Zeilen ist `start` = 0, 3 und 6.
Eine kleine private Hilfsmethode `string Zeichen(int index)` macht den Code übersichtlicher: Sie gibt entweder `"X"`/`"O"` zurück oder die Feldnummer `(index + 1).ToString()`.
{% endcapture %}
{% include tipp.html inhalt=tipp %}

{% capture tipp %}
Merke dir den aktuellen Spieler in einer Variablen `char aktuell = 'X';`. Nach jedem Zug wechselst du:
Ist `aktuell` gleich `'X'`, wird es `'O'` – sonst wird es `'X'`.
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Stufe 2 – Wer hat gewonnen?

Ergänze im `Spielfeld` eine Methode `bool HatGewonnen(char zeichen)`.
Es gibt **8 Gewinnlinien**: 3 Zeilen, 3 Spalten und 2 Diagonalen.

- Nach jedem Zug wird geprüft, ob der aktuelle Spieler gewonnen hat.
- Ist das Feld voll und niemand hat gewonnen, ist es **unentschieden**.
- Nach der Runde wird gefragt: `Nochmal? (j/n)`. Ein **Punktestand** zählt mit.

```
 X | O | 3
---+---+---
 4 | X | O
---+---+---
 7 | 8 | X

X hat gewonnen!
Punktestand – X: 1 | O: 0 | Unentschieden: 0
Nochmal? (j/n):
```

{% capture tipp %}
- Schreibe Gewinnlinien zuerst auf Papier auf. Zum Beispiel ist die erste Zeile `0, 1, 2` und die eine Diagonale `0, 4, 8`.
- Eine private Hilfsmethode `bool DreiGleich(int a, int b, int c, char zeichen)` prüft **eine** Linie.
  `HatGewonnen` verknüpft dann 8 Aufrufe mit `||`.
- Verschiebe eine ganze Runde in eine Methode `char SpieleRunde(...)`. Sie gibt den Sieger zurück (`'X'` oder `'O'`) oder `' '` bei unentschieden.
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Stufe 3 – Der Computer spielt mit

- Am Anfang wählt der Spieler: `1) Zwei Spieler` oder `2) Gegen den Computer`.
- Gegen den Computer bist du immer `X`, der Computer ist `O`.
- Der Computer wählt ein **zufälliges freies** Feld.

```
Der Computer setzt auf Feld 7.
```

{% capture tipp %}
Sammle alle freien Felder in einer `List<int>` und wähle daraus zufällig eins aus – genau wie beim zufälligen Wort im Galgenraten.

{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Stufe 4 – Ein schlauer Computer

Ein Computer, der zufällig spielt, ist langweilig. Bring ihm diese Strategie bei – **in genau dieser Reihenfolge**:

1. **Gewinnen:** Kann ich mit einem Zug gewinnen? Dann mache ich das.
2. **Blockieren:** Kann der Gegner mit seinem nächsten Zug gewinnen? Dann setze ich dorthin.
3. **Mitte:** Ist Feld 5 frei? Dann nehme ich es.
4. **Ecke:** Ist eine Ecke (1, 3, 7, 9) frei? Dann nehme ich sie.
5. **Sonst:** irgendein freies Feld.

Teste deinen Computer: Schaffst du es noch, ihn zu besiegen?

{% capture tipp %}
Der Trick: Der Computer **probiert einfach aus**!

Geh alle Felder von 1 bis 9 durch. Für jedes freie Feld:

1. Zeichen probeweise setzen
2. Prüfen, ob jetzt gewonnen ist (`HatGewonnen`)
3. Zeichen wieder entfernen (dafür brauchst du eine neue Methode `Entfernen(int feld)` im Spielfeld)
4. War es ein Gewinn? Dann ist das der richtige Zug.

Schreibe dafür eine Methode `int FindeGewinnzug(Spielfeld spielfeld, char zeichen)`, die das Feld zurückgibt – oder `0`, wenn es keinen Gewinnzug gibt.

Das Schöne: Dieselbe Methode funktioniert für **beide** Schritte.
Mit `'O'` findest du deinen eigenen Gewinnzug, mit `'X'` den Zug, den du blockieren musst.
{% endcapture %}
{% include tipp.html inhalt=tipp %}

---

## Typische Fehler

| Fehler | Was passiert |
|---|---|
| `felder[feld]` statt `felder[feld - 1]` | Der Zug landet im falschen Feld – Feld 9 führt zum Absturz |
| Sieg wird erst **nach** dem Spielerwechsel geprüft | Der falsche Spieler „gewinnt“ |
| Erst auf „voll“ und dann auf „gewonnen“ prüfen | Ein Sieg mit dem letzten Zug wird als Unentschieden gewertet |
| Beim Ausprobieren das Zeichen nicht wieder entfernt | Der Computer setzt plötzlich mehrere Zeichen auf einmal |

---

## Extras

- **Abwechselnd beginnen:** In jeder neuen Runde beginnt der andere Spieler.
- **Schwierigkeitsgrade:** Leicht = zufällig (Stufe 3), Mittel = nur gewinnen und blockieren, Schwer = komplette Strategie (Stufe 4).
- **Profi-Challenge – unbesiegbar:** Auch Stufe 4 lässt sich noch austricksen (probier mal, zwei Gewinnlinien gleichzeitig zu öffnen!).
  Ein wirklich unbesiegbarer Computer probiert **alle** möglichen Spielverläufe bis zum Ende durch. Das nennt man **Minimax-Algorithmus**.
  Frag deine Betreuungsperson danach – das ist echter Informatik-Stoff!
- **Größeres Feld:** 4×4 oder 5×5, und man braucht 4 in einer Reihe. Wie viel deines Codes musst du ändern?

---

## Checkliste

- [ ] Ich habe eine Klasse mit einer privaten Variablen geschrieben, die man nur über Methoden ändern kann.
- [ ] Ich kann zwischen „Spieler zählt ab 1“ und „Array zählt ab 0“ umrechnen.
- [ ] Mein Programm erkennt alle 8 Gewinnlinien und ein Unentschieden.
- [ ] Ich kann erklären, wie mein Computer seinen nächsten Zug auswählt.

[← Vokabeltrainer](Vokabeltrainer.md) | [Übersicht](../README.md) | [Bankautomat ->](Bankautomat.md)
