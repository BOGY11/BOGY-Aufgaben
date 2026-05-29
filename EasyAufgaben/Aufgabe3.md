# Programmieraufgabe: Schere, Stein, Papier in C#

## Ziel der Aufgabe
In dieser Aufgabe sollst du ein einfaches Konsolenprogramm in C# entwickeln, das das Spiel **Schere, Stein, Papier** umsetzt.  
Der Fokus liegt darauf, grundlegende Programmierkonzepte zu verstehen und anzuwenden.

---

## Schritt 1: Neues Projekt erstellen

### Mit Visual Studio:
- Öffne Visual Studio
- Klicke auf **"Neues Projekt erstellen"**
- Wähle **"Konsolenanwendung (.NET)"**
- Vergib einen Projektnamen (z. B. `SchereSteinPapier`)
- Klicke auf **"Erstellen"**

---

## Schritt 2: Projektvorbereitung

### Eine typische C#-Konsolenanwendung sieht so aus:

using System;

class Program
{
    static void Main(string[] args)
    {
        // Hier beginnt dein Programm
    }
}

Alles, was dein Programm tun soll, passiert innerhalb der Main-Methode.

### Überlege dir zuerst die Logik, bevor du mit dem Coden beginnst:

Der Spieler wählt:
- Schere
- Stein
- Papier

Der Computer wählt zufällig eine Option

Das Programm vergleicht beide Entscheidungen

Das Ergebnis wird ausgegeben:
- Sieg
- Niederlage
- Unentschieden

---

## Schritt 3: Wichtige Bausteine

Das Programm soll eine Konsoleneingabe erfordern. Das heißt der Spieler muss mithilfe von Console.Readline() das Programm steuern können.\
Neben der Auswahl der "Handgeste", soll der Spieler das Spiel starten, wiederholen als auch beenden können.

Mit der Klasse "Random" kann man eine Zufallszahl generieren. Das kann bei der Auswahl des Computers aushelfen.\
Weise jeder Handgeste eine Zahl zu, und der Zahlengenerator wählt für den Gegner eine Aktion.

Am Ende der Auswahlsphase sollen die gewählten Handgesten der Spieler verglichen werden. \
Mithilfe einer Logik, die du in einem "Dictionary" festlegst, kannst du alle Kombinationen und Gewinnsituationen zusammenfassen.

Am Ende einer Runde, soll der Spieler gefragt werden, ob er eine neue Runde starten oder das Spiel beenden möchte.

---

## Schritt 4: Bearbeitungsschritte der Aufgabe

Arbeite die Aufgabe Schritt für Schritt ab:

 Eingabe vom Spieler erfordern (und diese Eingabe abspeichern)\
 Zufällige Auswahl vom Gegner einbauen\
 Die Auswahl abgleichen (und Gewinner bestimmen)\
 Start- und Endmenü einbauen, die eine Eingabe des Spielers erfordern
 
Optional:
 Angehende Streak anzeigen\
 Punktestand hinzufügen\
 Echse und Spock hinzufügen

---
 
## Tipps

Teste deine Fortschritte immer wieder mithilfe eines Testdurchlaufs. Wenn es dabei Probleme gibt kann man diese früher beheben, bevor sie gegen Ende aus dem Nichts kommen.

Versuche den Code simple und übersichtlich zu halten. So kann man bei eventuellen Problemen leichter die Ursache finden.

Wenn du nicht weiterkommst, kannst du im Internet recherchieren ("C# Random", "C# if else") oder die Kollegen um dich herum fragen. Wir helfen dir immer gerne.

Zeige deinen Kollegen um dich herum gerne deine Fortschritte, so können sie dir auch Verbesserungsvorschläge geben oder andere Hilfe anbieten.
