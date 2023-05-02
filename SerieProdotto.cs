using System;
using System.Collections.Generic;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        //VARIABILI
        int max = 0;
        int k = 0;
        

        //CONTROLLI
        
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


        //DEFINIZIONE DEL PRODOTTO MAGGIORE

        //Definisco qual'è il prodotto maggiore e lo ritorno
        for (int i = 0; i < digits.Length-span+1; i++)
        {
            k = prodotto(digits.Substring(i, span));
            max = (max < k) ? k : max;
        }
        return max;


        //FUNZION*

        //Faccio il prodotto dei numeri selezionati secondo lo span
        int prodotto(string str) {
            int tmp = 1;
            foreach (char item in str)
                tmp*=(int)item-48; //Il casting da char a int porta la codifica ascii del char in intero: lo 0 in ascii è 48, quindi si sottrae zero al numero sottoposto al casting

            return tmp;
        }
    }
}