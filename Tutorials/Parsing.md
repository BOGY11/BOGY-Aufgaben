# Wie parse ich variablen 
`string` zu `int`/`double`
## 1. Simple Methode.
```
string stringVariable = "1";

int variableAlsInt = int.Parse(stringVariable);
double variableAlsDouble  = double.Parse(stringVariable);
```
:warning: Benutze diese methode nur, wenn du zu 100% sicher bist das die `stringVariable` eine zahl ist!

## 2. Sichere Methode
```
string stringVariable = "1";

int variableAlsInt;
double variableAlsDouble;

if (int.TryParse(stringVariable, out variableAlsInt))
{
	//Wird Ausgeführt falls es funktioniert hat
}
else
{
	//Wird Ausgeführt falls es nicht funktioniert hat
}

if (double.TryParse(stringVariable, out variableAlsDouble))
{
	//Wird Ausgeführt falls es funktioniert hat
}
else
{
	//Wird Ausgeführt falls es nicht funktioniert hat
}
```
`int.TryParse()`, bzw. `double.TryParse()` geben ein `bool` zurück, der angibt ob das Parsen funktioniert hat.\
Der wert wird innerhalb der Klammer gespeichert: `int.TryParse(input, out output)`

