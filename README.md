---
title: Start
nav_order: 1
permalink: /
---

# C#-Einstieg – BOGY-Tutorial

Willkommen! In diesem Tutorial lernst du Schritt für Schritt, wie man mit **C#** eigene Programme schreibt.
Du startest bei „Hallo Welt“ und baust am Ende dein **eigenes kleines Spiel**.

Du brauchst keine Vorkenntnisse. Wichtig sind nur zwei Dinge: **Ausprobieren** und **Spaß haben**.
 
---

## So funktioniert das Tutorial

Jedes Kapitel ist gleich aufgebaut:

| Abschnitt | Was dich erwartet |
|---|---|
| **Ziel** | Was du am Ende des Kapitels kannst |
| **Erklärung** | Das Wichtigste kurz erklärt – mit Beispielcode |
| **Typische Fehler** | Stolperfallen, in die fast jeder einmal tritt |
| **Aufgaben** | Pflichtaufgaben und Bonusaufgaben für Schnelle |
| **Checkliste** | Prüfe selbst, ob du bereit fürs nächste Kapitel bist |

**So arbeitest du am besten:**

1. Erstelle für jede Seite ein neues Projekt. So kannst du im Nachhinein immer wieder zurück gehen wenn du etwas nicht verstehst oder noch etwas ändern möchtest.
2. Lies die Erklärung.
3. **Tippe** den Beispielcode selbst ab (nicht kopieren – beim Tippen lernst du mehr!) und starte ihn.
4. Löse die Aufgaben. Bonusaufgaben sind freiwillig. 
5. Kommst du nicht weiter? Klappe zuerst den **Tipp** auf.
6. Hilft der Tipp nicht, frag einen anwesenden Azubi, Studenten oder deine Betreuungsperson. Das ist völlig normal!
7. Hake die Checkliste ab und geh zum nächsten Kapitel.
	
{% capture notiz %}
- Fehler sind beim Programmieren völlig normal – auch Profis bekommen jeden Tag Fehlermeldungen.
- Lies die Meldung in Ruhe durch: Sie verrät dir meistens, **in welcher Zeile** und **was** falsch ist.
{% endcapture %}
{% include notiz.html typ="important" inhalt=notiz %}

{% capture notiz %}
- Programmiert wird normalerweise auf **Englisch**. Damit du alles leichter verstehst, sind die Beispiele hier auf Deutsch.
- Ob du deine Variablen auf Deutsch oder Englisch benennst, entscheidest du selbst.
{% endcapture %}
{% include notiz.html typ="note" inhalt=notiz %}


---
## Dein Lernpfad

Der Kurs hat 5 Etappen. Jede Etappe baut auf der vorherigen auf. Arbeite sie deshalb der Reihe nach durch.

{% capture notiz %}
Du schreibst dein erstes Programm, speicherst Werte und rechnest damit.

| Kapitel | Das lernst du |
|---|---|
| [1 – Erste Schritte](Kapitel/01-Erste-Schritte.md) | Projekt anlegen, Text ausgeben |
| [2 – Variablen](Kapitel/02-Variablen.md) | Werte speichern, Datentypen |
| [3 – Rechnen & Vergleichen](Kapitel/03-Rechnen-und-Vergleichen.md) | Rechenzeichen, Vergleiche |
| [4 – Eingaben](Kapitel/04-Eingaben.md) | Benutzer fragen, Text in Zahlen umwandeln |

**Danach kannst du:** ein Programm schreiben, das Eingaben entgegennimmt und damit rechnet.
{% endcapture %}
{%include notiz.html typ="note" titel="Etappe 1: Die Grundlagen" offen=false inhalt=notiz %}

{% capture notiz %}
Dein Programm reagiert auf Eingaben und wiederholt Aufgaben.

| Kapitel | Das lernst du |
|---|---|
| [5 – Verzweigungen](Kapitel/05-Verzweigungen.md) | `if`, `else`, `switch` |
| [6 – Schleifen](Kapitel/06-Schleifen.md) | `for`, `while`, `do-while` |

**Danach kannst du:** Menüs bauen und Eingaben so lange abfragen, bis sie stimmen.
{% endcapture %}
{%include notiz.html typ="note" titel="Etappe 2: Das Programm entscheiden lassen" offen=false inhalt=notiz %}

{% capture notiz %}
Du speicherst viele Werte auf einmal und teilst deinen Code in sinnvolle Teile auf.

| Kapitel | Das lernst du |
|---|---|
| [7 – Collections](Kapitel/07-Collections.md) | Arrays und Listen |
| [8 – Methoden](Kapitel/08-Methoden.md) | eigene Methoden schreiben |
| [9 – Klassen](Kapitel/09-Klassen.md) | eigene Datentypen und Objekte |

**Danach kannst du:** größere Programme übersichtlich aufbauen.
{% endcapture %}
{%include notiz.html typ="note" titel="Etappe 3: Ordnung in den Code bringen" offen=false inhalt=notiz %}

{% capture notiz %}
Du fängst Fehler ab und setzt alles in einem eigenen Projekt zusammen.

| Kapitel | Das lernst du |
|---|---|
| [10 – Fehler abfangen](Kapitel/10-Fehler-abfangen.md) | `try`/`catch`, `TryParse` |
| [11 – Abschlussprojekt](Kapitel/11-Abschlussprojekt.md) | Zahlenraten in 4 Stufen |

**Danach kannst du:** ein komplettes kleines Spiel selbst programmieren.
{% endcapture %}
{%include notiz.html typ="note" titel="Etappe 4: Absturzsicher und fertigstellen" offen=false inhalt=notiz %}

{% capture notiz %}
Du willst mehr? In den [Zusatzaufgaben](Zusatzaufgaben/) warten sieben Projekte in drei Schwierigkeitsstufen:

- **Leicht:** Galgenraten, Schere-Stein-Papier, Taschenrechner
- **Mittel:** Snackautomat, Vokabeltrainer
- **Schwer:** Tic-Tac-Toe, Bankautomat
{% endcapture %}
{%include notiz.html typ="important" titel="Etappe 5: Zusatzaufgaben" offen=false inhalt=notiz %}


## Los geht's

Starte mit [Kapitel 1 – Erste Schritte](Kapitel/01-Erste-Schritte.md).
