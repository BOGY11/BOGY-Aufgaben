# Verzweigungen

Es gibt mehrere Möglichkeiten aufgrund einer Aussage eine Entscheidung zu treffen. \
Diese Entscheidung nennt man "Verzweigung" . \
Am leichtesten ist eine if/else Verzweigung (falls/ sonst). 
```csharp
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

Ein `switch` ist nützlich wenn man einen Wert mit mehreren Optionen auf einmal Vergleichen will: 
```csharp
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