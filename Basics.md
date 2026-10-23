# Basics
Ziel ist es den grundlegenden Aufbau von C# zu verstehen und interaktiv Lösungen für kleine Probleme zu erarbeiten. \
Dabei ist es immer wichtig dass du nicht verzweifelst und vor allem dass du Spaß daran hast was du machst. \
In der Informatik wird grundlegend auf Englisch programmiert. Zum besseren Verständnis sind alle Beispiele auf Deutsch. \
Ob du dein eigenes Programm wie ein professioneller Programmierer auf Englisch schreibst oder lieber auf Deutsch bleibt dir überlassen. \
Dieses Tutorial ist darauf ausgelegt möglichst viel alleine selbst zu erarbeiten. \
Versuche am besten immer selbst dir die nötigen Erklärungen durchzulesen und zu verstehen indem du die Aufgaben bearbeitest. \
Wenn du jedoch einmal nicht weiterkommst kannst du allerdings jederzeit einen anwesenden Azubi/ Studenten oder die für dich zuständige Person nach Hilfe fragen. 

## Schritt 1: Projekt erstellen
[Schrittweise anleitung](../Tutorials/NewProject.md)

Es öffnet sich eine Datei in der dieser Standart-Code steht:
```
Console.WriteLine("Hello, World!");
``` 
`Console` ist die voreingebaute Klasse um mit dem Terminal zu arbeiten. \
`WriteLine` schreibt Text in das Terminal und springt danach in die nächste Zeile. \
Jedes Statement endet mit einem Semikolon `;`.

Kommentare werden vom Programm ignoriert. Sie werden genutzt um Code zu erklären, übersichtlicher zu machen und die Funktionsweise bestimmter Funktionen grob zu erklären.
```
// Alles was in einer Zeile nach "//" geschrieben wird ist Kommentar.
``` 

### Dein erster eigener Code

Nutze dein neu gelerntes Wissen um im Terminal erst deinen Namen, und dann dein Lieblingshobby in eine neue Zeile zu schreiben. 

Probiere selbst aus: Was ist der Unterschied zwischen `Console.Write` und `Console.WriteLine`?


## Schritt 2: Variablen und Datentypen

Eine Variable ist ein benannter Platzhalter welcher unterschiedliche Werte speichert.
```
string name = "Anna";       // Text
int alter = 25;             // Ganze Zahlen
double höhe = 1.72;        // Dezimalzahlen
bool istSchüler = true;    // Wahr oder Falsch ( true oder false)
char note = 'A';            // Ein einziger Buchstabe

Console.WriteLine($"Mein Name ist {name} und ich bin {alter} Jahre alt.");
Console.WriteLine("Mein Name ist " + name + " und ich bin " + alter + " Jahre alt.");
```
Beide Console.WriteLines geben das gleiche aus. $"..." wird genutzt um die Werte von Variablen in einen Text zu schreiben indem man den Namen der Variable in geschweifte Klammern "{}" schreibt. 

Der Variablentyp "var" kann für jeden Variablentyp genutzt werden. Dabei ermittelt C# den Typ. 
Beispiel: `var stadt = "Berlin";` wird zu einem string. 

Mit dem Modifikator `const` wird eine Variable erstellt dessen Wert sich nicht ändern kann. \
`const double Pi = 3.14159;`

### Variablen erstellen und nutzen

Erstelle drei Variablen: `produktName`, `preis`, und `verfügbar`. Überlege dir zuerst welche Variablen Typen du dafür benötigst. \
Schreibe dann einen Satz in die Konsole in welchem alle drei Variablen genutzt werden. 

Überlege dir: Welchen Variablentypen muss man nutzen wenn ein Produkt `19.99`€ kostet? Welcher ergibt bei `42`€ Sinn? 

## Schritt 3: Mathematik und Operationen

### Mathematik
```
int a = 10;
int b = 3;

Console.WriteLine(a + b);   // Addition
Console.WriteLine(a - b);   // Subtraktion
Console.WriteLine(a * b);   // Multiplikation
Console.WriteLine(a / b);   // Division
Console.WriteLine(a % b);   // Modulo (Gibt den Rest der Division zurück)

int score = 0;
score = score + 5;  // Erhöht 'score' um 5
score += 5;         // Gleich wie score = score + 5
score++;            // Erhöht score um 1
```

#### Ausprobieren
Führe den oben zu sehenden Code aus. \
Warum gibt `10 / 3` 3 zurück und nicht 3.333...? Denke an die unterschiedlichen Variablen Typen und wie die Zahlen gespeichert werden. \
Wann würde `Console.WriteLine(a / b);` 3.333... ausgeben?

### Operatoren Information
Operatoren werden genutzt um zwei Aussagen oder Variablen zu vergleichen. \
Das Ergebnis eines Operators ist immer `true` oder `false`.

#### Vergleichsoperatoren
Um zwei Werte miteinander zu vergleichen nutzt man Vergleichsoperatoren.\
Folgende Operatoren stehen in C# zur Verfügung: \
`==` Gleich: Vergleicht ob zwei Werte exakt gleich sind. Gibt `true` zurück wenn beide gleich sind. \
`!=` Ungleich: Vergleicht ob sich zwei Werte unterscheiden. Gibt `true` zurück wenn es zwei unterschiedliche Werte sind. \
`>`  Größer: Vergleicht zwei Zahlen und gibt `true` zurück wenn Variable `a` größer als Variable `b` ist. \
`<`  Kleiner: Vergleicht zwei Zahlen und gibt `true` zurück wenn Variable `a` kleiner als Variable `b` ist. \
`>=` und `<=` Größer gleich und Kleiner gleich: Wie `Größer` und `Kleiner`, gibt allerdings auch `true` zurück wenn die Werte gleich sind. 

#### Logikoperatoren
Um zwei Aussagen miteinander zu vergleichen nutzt man Logikoperatoren. \
Es gibt drei Logikoperatoren in C#: \
`&&` Und: Gibt `true` zurück wenn beide Aussagen wahr sind.
`||` Oder: Gibt `true` zurück wenn mindestens eine der beiden Aussagen wahr ist.
`!`  Nicht: Wird vor eine Aussage geschrieben und kehrt den Wert um. `true` wird zu `false` und `false` wird zu `true`.



## Schritt 4: Benutzereingaben annehmen

Beispiel: 
```
Console.Write("Wie heißt du? ");
string name = Console.ReadLine();

Console.Write("Wie alt bist du? ");
int alter = int.Parse(Console.ReadLine());

Console.WriteLine($"Hallo {name}! Nächstes Jahr wirst du {alter + 1}.");
```
`Console.ReadLine` gibt immer einen `string` zurück. \
Um den `string` zu einer Nummer zu machen, konvertiert man die Eingabe mit `int.Parse(...)` oder `double.Parse(...)`. \
Was passiert wenn man bei einer Eingabe die eine Zahl erwartet einen Text eingibt behandeln wir bei Schritt 10: Fehlererkennung.

### Erstes nützliches Programm

Nun verbinden wir die letzten beiden Schritte um ein Programm zu schreiben welches tatsächlich einen Sinn erfüllt. \
Wir wollen vom Nutzer eine Temperatur in Celsius abfragen und diese in Fahrenheit umrechnen. \
Danach soll ein Text erscheinen in welchem sowohl der eingegebene Wert als auch der ausgerechnete Wert genutzt wird. \
Der Endtext kann am Ende zum Beispiel so aussehen: \
`Die Temperatur 28° Celsius entspricht circa 82° Fahrenheit` \
Überlege dir auch was man verändern muss um das genaue Ergebnis in Fahrenheit anzeigen zu können.


## Schritt 5: Entscheidungen treffen

Es gibt mehrere Möglichkeiten aufgrund einer Aussage eine Entscheidung zu treffen. \
Diese Entscheidung nennt man "Verzweigung" . \
Am leichtesten ist eine if/else Verzweigung (falls/ sonst). 
```
Console.Write("Gib dein Alter ein: ");
int alter = int.Parse(Console.ReadLine());

if(alter >= 18)
{
    Console.WriteLine("Du bist erwachsen.");
}
else if(alter >= 13)
{
    Console.WriteLine("Du bist ein Teenager.");
}
else
{
    Console.WriteLine("Du bist ein Kind.");
}
```
Denkanregung: Warum muss man `else if(alter >= 13)` schreiben? Was würde passieren wenn man nur `if(alter >= 13)` nutzt? \
Probiere diese Änderung gerne aus und versuche dir selbst zu erklären was nach Beenden einer if-Verzweigung passiert. 

Ein `switch` ist nützlich wenn man einen Wert mit mehreren Optionen auf einmal Vergleichen will: 
```
Console.Write("Welcher Tag ist heute? ");
string tag = Console.ReadLine();

switch(tag)
{
    case "Montag":
        Console.WriteLine("Oh nein es ist Montag! Komm gut durch die Woche.");
    break;
    case "Dienstag":
        Console.WriteLine("Heute ist der zweite Tag der Woche.");
    break;
    case "Mittwoch":
        Console.WriteLine("Du hast fast die Hälfte geschafft! Nur noch 2 Tage bis zum Wochenende!");
    break;
    case "Donnerstag":
        Console.WriteLine("Mathematisch ist heute die Mitte der Woche erreicht. Warum heißt es dann nicht Mittwoch?");
    break;
    case "Freitag":
        Console.WriteLine("Fast geschafft! Bald ist Wochenende!");
    break;
    case "Samstag":
    case "Sonntag":
        Console.WriteLine("Yippie, Wochenende!");
    break;
}
```
Wichtig: Am Ende von jedem `case` muss ein `break;` stehen um den Switch zu beenden. 

### Implementieren einer if-Verknüpfung
Erstelle ein Programm welches den Benutzer nach einer Nummer fragt. \
Daraufhin soll der Computer ausgeben ob die Zahl positiv, negativ oder null ist, und ob sie gerade oder ungerade ist. \
Beispielausgabe:
```
Wenn die Zahl 0 ist:
Die Zahl 0 ist weder positiv noch negativ, aber trotzdem gerade.

Jede andere Zahl:
Die Zahl "zufällige Zahl" ist eine gerade/ungerade positive/negative Zahl.  
```
Etwas fortgeschrittener: \
Die Ausgabe soll sich basierend auf dem Ergebnis positiv/negativ und gerade/ungerade verändern. \
'Die Zahl "zufällige Zahl" ist sowohl positiv als auch gerade.' \
'Die Zahl "zufällige Zahl" ist zwar positiv, aber nicht gerade.' \
Usw... 

## Schritt 6: Schleifen (Wiederholungen)
Schleifen (auf Englisch "loops") werden genutzt um den Code in einer Schleife mehrfach auszuführen. \
Dies vereinfacht den Code, da man etwas nur einmal in eine Schleife schreiben muss anstatt den ganzen Code mehrfach hintereinander zu schreiben. 

### for-Schleife
Eine for-Schleife wird genutzt wenn man weiß wie oft man etwas wiederholen möchte. \
Aufbau einer for-Schleife: 
```
for(int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Zähler: {i}");
}
```

#### Step-By-Step: Funktionsweise einer for-Schleife
Beim ersten Aufrufen einer for-Schleife wird eine Variable (Beispiel: `int i = 1`) initialisiert. \
Was bei jedem Durchgang passiert: 
1. Es wird überprüft, ob die Aussage wahr ist. Beispiel: `i <= 5`. 
2. Wenn die Aussage wahr ist: Der Code in der Schleife wird ausgeführt. Wenn die Aussage falsch ist: Schleife wird beendet
3. Nachdem der Code in der Schleife ausgeführt wurde wird der letzte Teil der Klammer ausgeführt. Beispiel: `i++`
4. Nachdem das ausgeführt wurde springt die Schleife wieder zurück zu Schritt 1 und überprüft erneut.

#### Denkaufgabe for-Schleife
Was passiert wenn die initialisierte Variable im Beispiel größer als 5 ist? Wird die Schleife ausgeführt? Wenn ja wie oft? \
Was würde beim ausführen folgender Schleife passieren? 
```
for(int i = 1; i>0; i++)
{
    Console.WriteLine($"Zähler: {i});
}
```

### while-Schleife:
Eine while-Schleife wiederholt sich so lange die Bedingung in der Klammer wahr ist. 
```
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
```
string input;
do
{
    Console.Write("Schreibe 'ende' um zu beenden: ");
    input = Console.ReadLine();
} while (input != "ende");
```
Was passiert wenn man diese do-while Schleife ausführt? Wann wird sie beendet? 

### foreach
Eine foreach Schleife wird genutzt, um Werte aus Listen abzufragen. \
Dies wird beim nächsten Schritt "Arrays und Listen" interessant. 
```
foreach ("VariablenTyp" "Variable" in "NameDerListe")
{
    //Auszuführender Code.
}
```

### Zusatzinfo Schleifen
Innerhalb einer Schleife kann man mehrere Commands verbauen, die den Ablauf der Schleife verändern: \
`break;`, welchen wir schon aus switches kennen, verlässt eine Schleife sofort. \
`continue` überspringt den Rest der Schleife und geht sofort in die nächste Wiederholung.

## Schritt 7: Arrays und Listen (Collections)
Arrays und Listen sind zwei Wege, Daten wie Variablen zu speichern. Dabei hat jede Liste und jedes Array einen festen Typ (genau wie eine Variable), und kann auch nur genau diese Art von Werten speichern.

### Arrays
Einem Array wird bei der implementierung eine feste Größe gegeben. Diese lässt sich im Nachhinein nicht mehr verändern. \
Arrays erkennt man an ihren Rechteckigen Klammern hinter dem Namen. \
Beispiel-Implementierung für ein Array mit 4 Speicherplätzen: 
```
int[] punkte = new int[4]; //Das Array wird mit einer Länge von 4 erstellt, jeder Wert ist dabei 0.
punkte[0] = 90; //Der "erste" Index ist in der Informatik immer "0". Das Array hat also nur 0, 1, 2, 3 als Index, NICHT 4!
Console.WriteLine(punkte[0]);
Console.WriteLine(Scores.Length); //Die Länge des Arrays ist die am Anfang definierte Anzahl.
```
Probiere aus: Was passiert wenn du versuchst bei einem Array der Länge 4 das 4. Element `punkte[4]` aufzurufen? 

### Listen
Listen können, anders als Arrays, ihre Länge verändern. Man kann also beliebig viele Werte hinzufügen und wieder entfernen. \
Wird eine Liste implementiert und ihr werden noch keine Werte zugewiesen, ist sie komplett leer. \
Beispiel einer Liste die sofort mit Werten implementiert wird: 
```
List<string> früchte = new List<string> {"Apfel", "Banane" };
früchte.Add("Kirsche");
früchte.Remove("Banane");

foreach(string frucht in früchte)
{
    Console.WriteLine(frucht);
}
```
Welche Ausgabe erwartest du in der Konsole wenn du dieses Programm ausführst? 

### Verknüpfung der gelernten Inhalte
Deine Aufgabe ist es, ein Programm zu schreiben, welches den Nutzer nach 5 Zahlen fragt. \
Die Zahlen sollen in einer Liste gespeichert werden. \
Nachdem der Nutzer alle Zahlen eingegeben hat soll das Programm die Summe aller Zahlen, den Durchschnitt und die größte Nummer zurückgeben. 

## Schritt 8: Methoden
Methoden sind eine Möglichkeit, einmal geschriebenen Code einfach wieder zu verwenden, ohne ihn jedes mal schreiben zu müssen. \
Eine Methode wird normalerweise genutzt, um genau eine Aufgabe auszuführen. \
Methoden können Rückgabewerte haben. Eine Methode wird wie folgt implementiert: 
```
void MethodenName(Parameter 1, Parameter 2, ...) // Beispiel einer Methode ohne Rückgabewert
{
    //Auszuführender Code...
}

int Addiere(int x, int y) // Methode gibt einen Wert int zurück
{
    int z = x + y
    return z;
}

void Grüße(string name)
{
    Console.WriteLine($"Hallo, {name}!");
}

Grüße("Dein Name");
int ergebnis = Addiere(3, 4);
Console.WriteLine(ergebnis);
```
Schreibe selbst eine Methode `IstGerade`, welche ein int als Parameter hat und ein boolean zurück gibt. \
Nutze diese Methode in einer Schleife von 1 bis 10 und gebe in jedem Durchgang aus ob die Zahl gerade ist. \
Tipp: Wenn du nicht weißt wie du es implementieren sollst schau bei den Schritten 4-6 nach. 

Warum ist eine Methode besser als denselben Code mehrmals zu kopieren?

## Schritt 9: Klasses und Objekte (Einführung zu Objektorientierter Programmierung)
Eine Klasse ist ein Entwurf. Jedes Objekt wird auf Grundlage von diesem Entwurf gebaut. \
Beispielklasse: 
```
class Hund
{
    public string Name { get; set; }
    public int Alter { get; set;}

    public Dog(string name, int alter) //Konstruktor
    {
        Name = name;
        Alter = alter;
    }

    public void Bellen()
    {
        Console.WriteLine($"{Name} sagt: Wuff!");
    }
}

// Die Klasse nutzen:
Hund meinHund = new Hund("Rex", 3);
meinHund.Bellen();
Console.WriteLine($"{meinHund.Name} ist {meinHund.Alter} Jahre alt.");
```
Ein Objekt wird immer mit `new 'KlassenName'()` erstellt. Dabei müssen alle im Konstruktor stehenden Parameter auf einen Wert gesetzt werden. Wenn man auf bestimmte Variablen innerhalb eines Objekts zugreifen will schreibt man `ObjektName.Variable`, damit auf die richtige Variable im richtigen Objekt verwiesen wird. 

### Erste Objektorientierte Programmierung
Erstelle eine `BankAccount` Klasse mit einem `Besitzer`, `Kontostand` und den Methoden `Einzahlen(menge)` und `Abheben(menge)`. \
`Abheben` darf `Kontostand` nicht unter 0 gehen lassen. 

## Schritt 10: Fehler abfangen
Mithilfe der `try` Methode kann man verhindern dass das Programm abstürzt. Dabei versucht das Programm zunächst den Code auszuführen, und bricht diesen ab wenn ein bestimmter Fehler im Programm auftritt. 
```
Console.Write("Gib eine Zahl ein: ");
try
{
    int nummer = int.Parse(Console.ReadLine());
    Console.WriteLine($"Du hast die Zahl {nummer} eingegeben!");
}
catch (FormatException)
{
    Console.WriteLine
}
```
Im Fall `int.Parse()` gibt es auch eine sicherere Variante, welche direkt in die Methode integriert ist. 
```
if(int.TryParse(Console.ReadLine(), out int value))
{
    Console.WriteLine($"Erlaubte: {value}");
}
else 
{  
    Console.WriteLine("Diese Eingabe ist nicht erlaubt.");
}
```
Die if-Methode überprüft in diesem Fall, ob `int.TryParse()` eine Variable `int value` ausgibt. Ist dies der Fall fährt der Code innerhalb der Verzweigung fort. \
Wenn `int.TryParse()` etwas anderes als einen int-Wert zurück gibt, fährt das Programm mit der `else` Verzweigung fort. \
Durch `int.TryParse()` wird das Problem gelöst, dass der Nutzer etwas anderes als eine Zahl eingibt, was wenn man nur `int.Parse()` nutzen würde zu einem Absturz des Programms führen würde. 