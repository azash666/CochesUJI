using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoADN {
    private static int VALOR_MINIMO_DEL_GEN = 0;
    private static int VALOR_MAXIMO_DEL_GEN = 10;

    private static string[] KEYS = { "velocidadMaxima", "aceleracion", "agarre", "peso", "punteria", "prudencia"};
    private Dictionary<string, int> adn;                                                                                            //La key será el nombre del gen y el int el valor de 0/1 a 10.

    private int n;              //n es el la suma de genes

    

    //Crear un nuevo individuo aleatorio
    public CodigoADN(int n)
    {
        adn = new Dictionary<string, int>();
        if (n > KEYS.Length * (VALOR_MAXIMO_DEL_GEN - VALOR_MINIMO_DEL_GEN))
        {
            n = KEYS.Length * VALOR_MAXIMO_DEL_GEN;
        }
        else
        {
            this.n = n;
            // Ponemos los genes a valor inicial.
            for (int i = 0; i < KEYS.Length; i++)
                adn[KEYS[i]] = VALOR_MINIMO_DEL_GEN;
            addCantidad(n);
        }
    }

    //Crear un individuo vacio
    public CodigoADN()
    {
        adn = new Dictionary<string, int>();
        n = 0;
        foreach (string key in KEYS)
        {
            adn[key] = VALOR_MINIMO_DEL_GEN;
        }
    }

    //Combina genes de un vector de padres para crear un nuevo individuo

    public static CodigoADN combinar(CodigoADN[] adns)
    {
        System.Random rnd = new System.Random();
        CodigoADN devolver = new CodigoADN();
        foreach (string key in KEYS)
        {
            int aux = rnd.Next(0, adns.Length);
            int val = adns[aux].getGen(key);
            devolver.n += val;
            devolver.addGen(key,val);
        }
        devolver.addCantidad(devolver.cuentaDiferenciaN());
        
        return devolver;
    }

    private int cuentaDiferenciaN()
    {
        int suma = 0;
        foreach (string key in KEYS)
        {
            suma += getGen(key);
        }
        return suma - n;
    }


    

    //Esta función añade una cantidad "valor" a los genes. Si valor < 0, los resta

    private void addCantidad(int valor)
    {
        System.Random rnd = new System.Random();
        List<String> auxKeys = new List<String>();
        int valorAux;
        foreach (String key in KEYS)
            if ((adn[key] > VALOR_MINIMO_DEL_GEN && valor < 0) || (adn[key] < VALOR_MAXIMO_DEL_GEN && valor > 0))
            {
                auxKeys.Add(key);
            }

        if (valor > 0)
            valorAux = valor;
        else
            valorAux = -valor;

        for (int i = 0; i < valorAux; i++)
        {
            int aux = rnd.Next(0, auxKeys.Count);
            int val = adn[auxKeys[aux]];
            if (valor > 0)
                adn[auxKeys[aux]] = val + 1;
            else
                adn[auxKeys[aux]] = val - 1;
            if ((val >= VALOR_MAXIMO_DEL_GEN - 1 && valor>0 ) || (val <= VALOR_MINIMO_DEL_GEN + 1 && valor <0)) auxKeys.RemoveAt(aux);
        }
    }



    //TODO: Cambiar el constructor para que en vez de usar i--, descarte los genes máximos (Optimización).

    public void mutar(int cantidad)
    {
        System.Random rnd = new System.Random();

        for (int i = 0; i < cantidad; i++)
        {
            int aux, val, aux2, val2;
            do
            {
                aux = rnd.Next(0, KEYS.Length - 1);
                val = adn[KEYS[aux]];
            } while (val < VALOR_MAXIMO_DEL_GEN);
            do
            {
                aux2 = rnd.Next(0, KEYS.Length - 1);
                val2 = adn[KEYS[aux2]];
            } while (val2 > VALOR_MINIMO_DEL_GEN || val2 == val);
            adn[KEYS[aux]] = val + 1;
            adn[KEYS[aux2]] = val2 - 1;
        }
        
    }

    public void mutar()
    {
        mutar(1);
    }



    private void addGen(string key, int valor)
    {
        adn[key] = valor;
    }

    public int getGen(string key)
    {
        return adn[key];
    }

    public void setN(int nuevaN)
    {
        addCantidad(nuevaN - n);
        n = nuevaN;
    }

    public int getN()
    {
        return n;
    }
	
}
