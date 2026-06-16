# Programmieraufgabe: Benutzerverwaltung in C#

## Ziel der Aufgabe

In dieser Aufgabe sollst du eine einfache Konsolenanwendung in C# entwickeln, mit der Benutzer erstellt und verwaltet werden können.

Der Fokus liegt darauf, grundlegende Programmierkonzepte wie Variablen, Klassen, Listen, Methoden und Menüsteuerung kennenzulernen und anzuwenden.

---

# Schritt 1: Neues Projekt erstellen

Erstelle ein neues Projekt und nenne es **Benutzerverwaltung**.

Tutorial neues Projekt erstellen

---

# Schritt 2: Projektvorbereitung

Eine typische C#-Konsolenanwendung sieht so aus:

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        // Hier beginnt dein Programm
    }
}
```

Alles, was dein Programm tun soll, passiert innerhalb der Main-Methode oder in den von dir erstellten Funktionen.

---

# Schritt 3: Erste Benutzererfassung

Erstelle zunächst ein Programm, das folgende Informationen vom Benutzer abfragt:

- Name
- Alter
- Lieblingsfarbe

Die eingegebenen Daten sollen gespeichert und anschließend wieder auf der Konsole ausgegeben werden.

Beispiel:

```text
Bitte gib deinen Namen ein:
Max

Bitte gib dein Alter ein:
25

Bitte gib deine Lieblingsfarbe ein:
Blau

--- Benutzerdaten ---
Name: Max
Alter: 25
Lieblingsfarbe: Blau
```

---

# Schritt 4: Datenstruktur erweitern

Da später beliebig viele Benutzer erstellt werden können, soll eine eigene Klasse angelegt werden.

Beispiel:

```csharp
class User
{
    public string Name { get; set; }
    public int Alter { get; set; }
    public string Lieblingsfarbe { get; set; }
}
```

Diese Klasse enthält alle Informationen, die bei der Erstellung eines Benutzers benötigt werden.

Speichere die erstellten Benutzer anschließend in einer Liste.

Tipp:

```csharp
List<User> users = new List<User>();
```

---

# Schritt 5: Funktionen auslagern

Teile dein Programm in mehrere Methoden auf.

Beispiele:

```csharp
CreateUser()
ShowUsers()
```

Dadurch bleibt der Code übersichtlich und einfacher erweiterbar.

---

# Schritt 6: Hauptmenü einbauen

Beim Start des Programms soll ein Menü erscheinen.

Beispiel:

```text
=== Benutzerverwaltung ===

1 - Benutzer erstellen
2 - Benutzer anzeigen
3 - Programm beenden
```

Der Benutzer soll durch Eingabe einer Zahl eine Aktion auswählen können.

---

# Schritt 7: Benutzer anzeigen

Wenn Benutzer angelegt wurden, sollen alle gespeicherten Benutzer ausgegeben werden.

Beispiel:

```text
--- Benutzerliste ---

Name: Max
Alter: 25
Lieblingsfarbe: Blau

Name: Anna
Alter: 31
Lieblingsfarbe: Grün
```

Falls noch keine Benutzer vorhanden sind, soll eine entsprechende Meldung erscheinen.

---

# Schritt 8: Programm dauerhaft ausführen

Das Menü soll nach jeder Aktion erneut angezeigt werden.

Der Benutzer kann:

- neue Benutzer anlegen
- vorhandene Benutzer anzeigen
- das Programm beenden

Das Programm endet erst, wenn die entsprechende Option ausgewählt wird.

---

# Bearbeitungsschritte der Aufgabe

Arbeite die Aufgabe Schritt für Schritt ab:

1. Benutzerdaten abfragen
2. Daten speichern
3. Daten anzeigen
4. User-Klasse erstellen
5. Benutzerliste einführen
6. Methoden erstellen
7. Hauptmenü einbauen
8. Programm dauerhaft ausführbar machen

---

# Optionale Erweiterungen

Wenn die Grundfunktionen fertig sind, können weitere Features ergänzt werden:

- Benutzer löschen
- Benutzer bearbeiten
- Nach Namen suchen
- Durchschnittsalter berechnen
- Lieblingsfarben zählen und auswerten
- Benutzer-ID vergeben
- Daten in einer Datei speichern
- Daten beim Programmstart wieder laden

---

# Tipps

Teste dein Programm nach jedem Schritt.

Versuche den Code übersichtlich zu halten und Funktionen sinnvoll aufzuteilen.

Wenn du nicht weiterkommst, kannst du im Internet recherchieren ("C# List", "C# Class", "C# Switch") oder deine Kollegen fragen.

Zeige deine Fortschritte regelmäßig einem Kollegen, damit mögliche Verbesserungen früh erkannt werden können.
