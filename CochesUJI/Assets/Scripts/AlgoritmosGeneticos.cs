using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AlgoritmosGeneticos {
    //TODO: Cambiar nombre de la clase
    
    private static CodigoADN[] individuos;


    public static void nuevaMuestraInicial(int cantidadIndividuos, int n)
    {
        individuos = new CodigoADN[cantidadIndividuos];
        for (int i = 0; i < cantidadIndividuos; i++)
            individuos[i] = new CodigoADN(n);

    }
    public static void nuevaMuestraVacia(int cantidadIndividuos)
    {
        individuos = new CodigoADN[cantidadIndividuos];
    }

    public static void cambiaN(int n)
    {
        foreach (CodigoADN adn in individuos)
        {
            adn.setN(n);
        }
    }

//Carece de sentido
    public static CodigoADN[] podaPorcentaje(int porcentaje)
    {
        int cantidad = individuos.Length * porcentaje / 100;
        return podaCantidad(cantidad);
    }

//Carece de sentido
    public static CodigoADN[] podaCantidad(int cantidad)
    {
        CodigoADN[] devolver = new CodigoADN[cantidad];
        for (int i=0; i<cantidad; i++)
        {
            devolver[i] = individuos[i];
        }
        return devolver;
    }

    public static void generarDescendientes(CodigoADN[] padres)
    {
        for (int i = 0; i < individuos.Length; i++)
            individuos[i] = CodigoADN.combinar(padres);
    }

    public static void generarDescendientes(CodigoADN[] padres, bool mantenerPadres)
    {
        if (mantenerPadres)
        {
            for (int i = 0; i < padres.Length; i++)
                individuos[i] = padres[i];
            for (int i = padres.Length; i < individuos.Length; i++)
                individuos[i] = CodigoADN.combinar(padres);
        }
        else
        {
            generarDescendientes(padres);
        }
    }
    

    public static void combinar()
    {
        //Combinar los individuos
    }

    public static void mutar()
    {
        foreach (CodigoADN adn in individuos)
        {
            adn.mutar();
        }
    }

    public static void mutar(int n)
    {
        foreach (CodigoADN adn in individuos)
        {
            adn.mutar(n);
        }
    }


    // getIndividuo(-1) devuelve el último individuo, como en Python

    public static CodigoADN getIndividuo(int i)
    {
        if (i >= individuos.Length || -i > individuos.Length) throw new IndexOutOfRangeException();
        if (i < 0) i = individuos.Length - i;
        return individuos[i];
    }

    public static CodigoADN[] getIndividuoArray(int[] indices)
    {
        CodigoADN[] devolver = new CodigoADN[indices.Length];
        int j = 0;
        foreach (int i in indices)
        {
            if (i >= individuos.Length || -i > individuos.Length) throw new IndexOutOfRangeException();
            devolver[j] = individuos[i];
            j++;
        }
        return devolver;
    }

    public static int length()
    {
        return individuos.Length;
    }
}
