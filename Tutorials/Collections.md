
# Collections
Arrays und Listen sind zwei Wege, Daten wie Variablen zu speichern. Dabei hat jede Liste und jedes Array einen festen Typ (genau wie eine Variable), und kann auch nur genau diese Art von Werten speichern.

## Arrays
Einem Array wird bei der implementierung eine feste Größe gegeben. Diese lässt sich im Nachhinein nicht mehr verändern. \
Arrays erkennt man an ihren Rechteckigen Klammern hinter dem Namen. \
Beispiel-Implementierung für ein Array mit 4 Speicherplätzen: 
```csharp
int[] punkte = new int[4];  //Das Array wird mit einer Länge von 4 erstellt, jeder Wert ist dabei 0.
punkte[0] = 90;             //Der "erste" Index ist in der Informatik immer "0". Das Array hat also nur 0, 1, 2, 3 als Index, NICHT 4!
Console.WriteLine(punkte[0]);
Console.WriteLine(Scores.Length); //Die Länge des Arrays ist die am Anfang definierte Anzahl.
```
Probiere aus: Was passiert wenn du versuchst bei einem Array der Länge 4 das 4. Element `punkte[4]` aufzurufen? 

## Listen
Listen können, anders als Arrays, ihre Länge verändern. Man kann also beliebig viele Werte hinzufügen und wieder entfernen. \
Wird eine Liste implementiert und ihr werden noch keine Werte zugewiesen, ist sie komplett leer. \
Beispiel einer Liste die sofort mit Werten implementiert wird: 
```csharp
List<string> früchte = new List<string> {"Apfel", "Banane" };
früchte.Add("Kirsche");
früchte.Remove("Banane");

foreach(string frucht in früchte)
{
    Console.WriteLine(frucht);
}
```
Welche Ausgabe erwartest du in der Konsole wenn du dieses Programm ausführst? 
