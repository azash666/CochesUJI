using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoADN {
    private int VALOR_INICIAL_DEL_GEN = 0;
    private int VALOR_MAXIMO_DEL_GEN = 10;

    private static string[] KEYS = { "velocidadMaxima", "aceleracion", "agarre", "peso", "punteria", "prudencia"};
    private Dictionary<string, int> adn;                                                                                            //La key será el nombre del gen y el int el valor de 0/1 a 10.

    //Crear un nuevo individuo aleatorio
    public CodigoADN(int n)
    {
        System.Random rnd = new System.Random();
                // Ponemos los genes a valor inicial.
        for (int i = 0; i < KEYS.Length; i++)
            adn[KEYS[i]] = VALOR_INICIAL_DEL_GEN;

        for(int i=0; i<n; i++)
        {
            int aux = rnd.Next(0, KEYS.Length-1);
            int val = adn[KEYS[aux]];
            if (val < VALOR_MAXIMO_DEL_GEN)
                adn[KEYS[aux]] = val + 1;
            else
                i--;
        }
    }

    //Crear un individuo vacio
    public CodigoADN()
    {
        foreach (string key in KEYS)
        {
            adn[key] = VALOR_INICIAL_DEL_GEN;
        }
    }

            /**********    Se me plantea una posible mejora.¿ Preferis la herencia genetica entre dos progenitores o entre todos ellos, a modo de vector, de forma aleatoria?    */

    public static CodigoADN combinar(CodigoADN adnA, CodigoADN adnB)
    {
        CodigoADN devolver = new CodigoADN();
        foreach (string key in KEYS)
        {
            //...
        }
        return null;
    }

    public void mutar()
    {

    }
	
}
