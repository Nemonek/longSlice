# LongSlice
## Cos'è

LongSlice è un programma di test console il cui scopo è creare una funzione alla quale si passa una stringa di cifre ed un numero N: la funzione deve determinare qual'è lo span di N cifre il cui prodotto è maggiore

## Come è strutturato il codice

Questo codice si compone di 3 elementi fondamentali:
 * una parte adibita ai controlli dell'input;
 * una parte adibita al controllo e ricerca del prodotto maggiore;
 * una parte adibita alla dichiarazione di funzioni.

### Esempio
Data alla funzione la stringa "1027839564"; il prodotto maggiore per uno span di 3 cifre è 270 (9 x 5 x 6) mentre per uno span di 5 è 7560 (7 x 8 x 3 x 9 x 5).


### Controlli dell'input
```C#
//Controllo che la lunghezza sia uguale a 0 e lo span anche; ritorno 1 nel caso
if( span == 0 && digits.Length == 0 )
    return 1;

//Controllo che digits non sia vuoto, che span sia maggiore di zero e che non sia maggiore della lunghezza di digits
if ( digits.Length == 0 || digits.Length < span || span < 0 )
    throw new ArgumentException();

//Controllo che ci siano solo caratteri numerici; in caso contrario sollevo un eccezzione
foreach (char item in digits)
    if ( !(item >= 48 && item <=57) )
        throw new ArgumentException();


```

### Controllo e ricerca del prodotto maggiore
```C#
//Definisco qual'è il prodotto maggiore e lo ritorno
for (int i = 0; i < digits.Length-span+1; i++)
{
    k = prodotto(digits.Substring(i, span));
    max = (max < k) ? k : max;
}
return max;
```

### Definizione funzioni
```C#
//Faccio il prodotto dei numeri selezionati secondo lo span
int prodotto(string str) {
    int tmp = 1;
    foreach (char item in str)
        tmp*=(int)item-48; //Il casting da char a int porta la codifica ascii del char in intero: lo 0 in ascii è 48, quindi si sottrae zero al numero sottoposto al casting

    return tmp;
}
```


**Ad esempio:**

- data in ingresso la stringa "1027839564", 
- il prodotto più grande per una serie di 3 cifre è 270 (9 * 5 * 6)
- e il prodotto più grande per una serie di 5 cifre è 7560 (7 * 8 * 3 * 9 * 5).

- Per l'ingresso "73167176531330624919225119674426574742355349194934", il prodotto più grande per una serie di 6 cifre è 23520.

