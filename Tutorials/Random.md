# Wie generiert man eine Zufallszahl
## Zahlengenerator
Erstelle ein Object mit dem du Zufallszahlen generieren kannst:
```
var zufall = new Random();
```

## Zufällige zahl von- bis-
Jetzt kannst dz `zufall` benutzen um eine Zufallszahl zu generieren.\
Z.B. eine zahl von 1-5:
```
int zahl = zufall.Next(5) + 1;
```

### Erklärung:
`zufall.Next(5)` gibt zufällig eine von 5 zahlen zurück. diese sind 0-4.\
`zufall.Next(7)` würde daher eine zufällige zahl von 0-6 zurückgeben.\
Damit wir aber eine Zahl von 1-5, bzw. 1-7 bekommen muss man die zahl noch um 1 erhöhen.

|code|ergebniss|
|:-:|:-:|
|`zufall.Next(5)`|Zufällige zahl von 0-4|
|`zufall.Next(7)`|Zufällige zahl von 0-6|
|`zufall.Next(5) + 1`|Zufällige zahl von 1-5|
|`zufall.Next(7) + 1`|Zufällige zahl von 1-7|
|`zufall.Next(4) + 10`|Zufällige zahl von 10-13|

## Zufällige Kommazahl
Für eine Kommazahl (`double`) gibt es `zufall.NextDouble()`.\
Das gibt eine Zufällige kommazahl zwichen 0-1, wobei nie der wert 1 raus kommt.

### Zufällige Kommazahl von- bis-
Beispiel 1-5:
```
doble zahl = zufall.NextDouble() * 5 + 1;
```

`zufall.NextDouble() * 5` gibt eine zufällige Kommazahl zwichen 0 und 5, wobei niemals der wert 5 raus kommt.\
`zufall.NextDouble() * 5 + 1;` gibt eine zufällige kommazahl zwichen 1 und 6, wobei niemals genau 6 raus kommt.