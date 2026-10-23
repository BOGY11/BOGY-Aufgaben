# Schleifen

Schleifen (auf Englisch "loops") werden genutzt um den Code in einer Schleife mehrfach auszuführen. \
Dies vereinfacht den Code, da man etwas nur einmal in eine Schleife schreiben muss anstatt den ganzen Code mehrfach hintereinander zu schreiben. 

## for-Schleife
Eine for-Schleife wird genutzt wenn man weiß wie oft man etwas wiederholen möchte. \
Aufbau einer for-Schleife: 
```csharp
for(int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Zähler: {i}");
}
```

### Step-By-Step: Funktionsweise einer for-Schleife
Beim ersten Aufrufen einer for-Schleife wird eine Variable (Beispiel: `int i = 1`) initialisiert. \
Was bei jedem Durchgang passiert: 
1. Es wird überprüft, ob die Aussage wahr ist. Beispiel: `i <= 5`. 
2. Wenn die Aussage wahr ist: Der Code in der Schleife wird ausgeführt. Wenn die Aussage falsch ist: Schleife wird beendet
3. Nachdem der Code in der Schleife ausgeführt wurde wird der letzte Teil der Klammer ausgeführt. Beispiel: `i++`
4. Nachdem das ausgeführt wurde springt die Schleife wieder zurück zu Schritt 1 und überprüft erneut.


## while-Schleife:
Eine while-Schleife wiederholt sich so lange die Bedingung in der Klammer wahr ist. 
```csharp
int nummer = 10;
while (nummer > 0)
{
    Console.WriteLine(nummer);
    nummer -= 3;
}
```
Was ist der Vorteil einer while-Schleife im Gegensatz zu einer for-Schleife. Wann benutzt man for-Schleifen, wann ist eine while-Schleife sinnvoller?

### do-while
Do-while ist eine Variation einer while-Schleife. Eine do-while Schleife wird immer mindestens einmal ausgeführt, da die Überprüfung der Bedingung am Ende der Schleife stattfindet. 
```csharp
string input;
do
{
    Console.Write("Schreibe 'ende' um zu beenden: ");
    input = Console.ReadLine();
} while (input != "ende");
```
Was passiert wenn man diese do-while Schleife ausführt? Wann wird sie beendet? 

## foreach
Eine foreach Schleife wird genutzt, um Werte aus Listen abzufragen. \
Dies wird beim nächsten Schritt "Arrays und Listen" interessant. 
```csharp
foreach ("VariablenTyp" "Variable" in "NameDerListe")
{
    //Auszuführender Code.
}
```

# Zusatzinfo Schleifen
Innerhalb jeder Schleife kann man mehrere Commands verbauen, die den Ablauf der Schleife verändern: \
`break;`, welchen wir schon aus switches kennen, verlässt eine Schleife sofort. \
`continue` überspringt den Rest der Schleife und geht sofort in die nächste Wiederholung.

