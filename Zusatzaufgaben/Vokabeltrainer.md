---
title: "5 - Vokabeltrainer"
parent: Zusatzaufgaben
nav_order: 5
---

# Zusatzaufgabe 5 - Vokabeltrainer

| | |
|---|---|
| **Schwierigkeit** | Mittel |
| **Dauer** | ca. 2 Stunden |
| **Benötigte Kapitel** | 1–10 |

## Ziel

Du programmierst einen Vokabeltrainer für Deutsch und Englisch. Er fragt Vokabeln in zufälliger Reihenfolge ab, merkt sich, welche du falsch hattest, und wiederholt genau diese so lange, bis alle sitzen.

Dabei übst du:
- eine eigene Klasse mit Eigenschaften und Methoden
- `List<T>` mit Objekten
- Texte vergleichen (`Trim`, `ToLower`)
- Menüs mit Schleifen
- Zufällige Reihenfolge

---

## Was du dafür brauchst

**Texte vergleichbar machen**

```csharp
string antwort = "  House ";
string sauber = antwort.Trim().ToLower();   // "house"
```

- `Trim()` entfernt Leerzeichen am Anfang und Ende.
- `ToLower()` macht alles klein.

**Ein zufälliges Element aus einer Liste**

```csharp
Random zufall = new Random();
int index = zufall.Next(liste.Count);   // 0 bis Count - 1
var element = liste[index];
```

**Eine Liste kopieren**

```csharp
List<Vokabel> kopie = new List<Vokabel>(vokabeln);
```

So kannst du aus der Kopie Elemente entfernen, ohne die Originalliste zu verändern.

---

## Aufgaben

### Stufe 1: Feste Abfrage

Lege zwei Arrays an: eins mit 8 deutschen Wörtern, eins mit den passenden englischen Übersetzungen (gleicher Index = gleiches Wort). Frage alle Wörter der Reihe nach ab und zähle die richtigen Antworten.

```text
=== Vokabeltrainer ===
Haus = house
Richtig!
Hund = cat
Falsch. Richtig ist: dog
...
Ergebnis: 6 von 8 richtig
```

Groß- und Kleinschreibung sowie Leerzeichen sollen **keine** Rolle spielen: ` House ` ist auch richtig.

{% capture tipp %}
```csharp
string[] deutsch = { "Haus", "Hund", "Katze", "Baum" };
string[] englisch = { "house", "dog", "cat", "tree" };

for (int i = 0; i < deutsch.Length; i++)
{
    Console.Write($"{deutsch[i]} = ");
    string antwort = Console.ReadLine().Trim().ToLower();
    // vergleichen mit englisch[i]
}
```
{% endcapture %}
{% include tipp.html inhalt=tipp %}

### Stufe 2: Die Klasse `Vokabel`

Zwei getrennte Arrays werden schnell unübersichtlich. Erstelle deshalb eine Klasse `Vokabel` mit:

| Mitglied | Typ | Bedeutung |
|---|---|---|
| `Deutsch` | `string` | das deutsche Wort |
| `Englisch` | `string` | die Übersetzung |
| `Richtig` | `int` | wie oft richtig beantwortet |
| `Falsch` | `int` | wie oft falsch beantwortet |
| Konstruktor `Vokabel(string deutsch, string englisch)` | | setzt beide Wörter |
| `bool Pruefe(string antwort)` | | prüft die Antwort und zählt `Richtig` bzw. `Falsch` hoch |

Speichere die Vokabeln in einer `List<Vokabel>` und frage sie wie in Stufe 1 ab.

{% capture tipp %}
Die ganze Vergleichslogik gehört in `Pruefe`. Das Hauptprogramm muss dann nur noch fragen und das Ergebnis ausgeben:

```csharp
public bool Pruefe(string antwort)
{
    bool istRichtig = antwort.Trim().ToLower() == Englisch.ToLower();

    if (istRichtig)
    {
        Richtig++;
    }
    else
    {
        Falsch++;
    }
    return istRichtig;
}
```

Damit `Richtig` und `Falsch` nur von der Klasse selbst geändert werden können, schreib `public int Richtig { get; private set; }`.
{% endcapture %}
{% include tipp.html titel="Tipp zu Pruefe" inhalt=tipp %}

### Stufe 3: Menü, Zufall und Richtung

Baue ein Menü in einer Schleife:

```text
=== Vokabeltrainer ===
1) Abfragen (Deutsch → Englisch)
2) Abfragen (Englisch → Deutsch)
3) Neue Vokabel hinzufügen
4) Alle Vokabeln anzeigen
5) Beenden
```

- Die Vokabeln werden in **zufälliger Reihenfolge** abgefragt, und jede Vokabel kommt pro Durchgang genau **einmal** dran.
- Bei **2** wird das englische Wort angezeigt und das deutsche erwartet.
- Bei **3** darf kein Wort leer sein, und doppelte Vokabeln werden abgelehnt.
- Bei **4** werden alle Vokabeln als Tabelle angezeigt:

```text
Deutsch        Englisch      de   en
Haus           house          3    0
Hund           dog            1    2
```

{% capture tipp %}
**Zufällig und ohne Wiederholung:** Kopiere die Liste. Nimm dann so lange ein zufälliges Element aus der Kopie und entferne es, bis die Kopie leer ist:

```csharp
List<Vokabel> offen = new List<Vokabel>(vokabeln);

while (offen.Count > 0)
{
    int index = zufall.Next(offen.Count);
    Vokabel v = offen[index];
    offen.RemoveAt(index);
    // v abfragen
}
```

**Tabelle:** Mit `{wert,-15}` wird ein Text links ausgerichtet und auf 15 Zeichen aufgefüllt:

```csharp
Console.WriteLine($"{v.Deutsch,-15}{v.Englisch,-15}{v.Richtig,-5}{v.Falsch}");
```

**Richtung:** Gib `Pruefe` einen zweiten Parameter `bool deutschNachEnglisch` und vergleiche je nach Richtung mit `Englisch` oder `Deutsch`.
{% endcapture %}
{% include tipp.html inhalt=tipp %}

### Stufe 4: Fehler wiederholen und Statistik

1. Nach einem Durchgang werden alle **falsch** beantworteten Vokabeln sofort noch einmal abgefragt. Das geht so lange weiter, bis alle einmal richtig waren.
2. Am Ende erscheint eine Auswertung mit den **3 schwierigsten Vokabeln**, also denen mit den meisten Fehlern.

```text
Durchgang 1: 5 von 8 richtig
3 Vokabeln werden wiederholt ...

Durchgang 2: 2 von 3 richtig
1 Vokabel wird wiederholt ...

Durchgang 3: 1 von 1 richtig
Alle Vokabeln gelernt!

=== Deine schwierigsten Vokabeln ===
1. Schmetterling = butterfly (3 Fehler)
2. Eichhörnchen = squirrel (2 Fehler)
3. Hund = dog (1 Fehler)
```

{% capture tipp %}
Sammle die falschen Vokabeln eines Durchgangs in einer **neuen** Liste `falsche`. Nach dem Durchgang fragst du nur noch diese Liste ab. Das wiederholst du, bis `falsche.Count == 0` ist.

**Achtung:** Entferne keine Elemente aus einer Liste, über die du gerade mit `foreach` läufst. Das führt zu einer `InvalidOperationException`.

Für die schwierigsten Vokabeln suchst du dreimal hintereinander die Vokabel mit den meisten Fehlern aus einer Kopie der Liste und entfernst sie danach aus der Kopie.
{% endcapture %}
{% include tipp.html titel="Tipp zum Wiederholen" inhalt=tipp %}

---

## Typische Fehler

| Fehler | Was passiert | Lösung |
|---|---|---|
| `antwort == Englisch` ohne `ToLower()` | `House` wird als falsch gewertet | Beide Seiten mit `.Trim().ToLower()` vergleichen |
| Arrays unterschiedlich lang (Stufe 1) | `IndexOutOfRangeException` | Genau gleich viele Wörter in beide Arrays |
| `Remove` innerhalb von `foreach` | `InvalidOperationException` | Eine zweite Liste verwenden oder `while` + `RemoveAt` |
| `zufall.Next(offen.Count + 1)` | Absturz, weil der Index zu groß ist | `Next(offen.Count)`: die obere Grenze ist exklusiv |
| Die Originalliste wird beim Abfragen geleert | Beim zweiten Durchgang ist die Liste leer | Mit `new List<Vokabel>(vokabeln)` eine Kopie anlegen |

---

## Extras

1. **Mehrere richtige Antworten:** Erlaube Einträge wie `car/automobile`. Zerlege sie mit `Split('/')` und akzeptiere jede Variante.
2. **Tippfehler-Toleranz:** Wenn genau **ein** Buchstabe falsch ist (gleiche Länge), gilt die Antwort als „Fast richtig!“ und zählt halb.
3. **Speichern:** Speichere die Vokabeln beim Beenden in eine Datei (eine Zeile pro Vokabel, z. B. `Haus;house;3;0`) und lade sie beim Start wieder. Dafür brauchst du `File.WriteAllLines` und `File.ReadAllLines`.
4. **Themen:** Gib jeder Vokabel ein Thema wie „Tiere“ oder „Schule“ und frage nur Vokabeln eines Themas ab.

---

## Checkliste

- [ ] Groß- und Kleinschreibung und Leerzeichen spielen keine Rolle
- [ ] Die Klasse `Vokabel` enthält die Vergleichslogik in `Pruefe`
- [ ] Jede Vokabel kommt pro Durchgang genau einmal dran, in zufälliger Reihenfolge
- [ ] Beide Richtungen (DE → EN und EN → DE) funktionieren
- [ ] Leere oder doppelte Vokabeln werden abgelehnt
- [ ] Falsche Vokabeln werden wiederholt, bis alle richtig sind
- [ ] Die 3 schwierigsten Vokabeln werden angezeigt

---

[← Snackautomat](Snackautomat.md) · [Übersicht](index.md) · [Tic-Tac-Toe →](TicTacToe.md)
