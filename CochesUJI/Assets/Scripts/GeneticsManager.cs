using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneticsManager {
    //TODO: Cambiar nombre de la clase
    
    private static DNACode[] sample;


    public static void newInitialSample(int sampleSize, int sumatoryGenValues)
    {
        sample = new DNACode[sampleSize];
        for (int i = 0; i < sampleSize; i++) {
            DNACode.setSumatoryGenValues(sumatoryGenValues);
            sample[i] = new DNACode().initialize();
        }

    }


    public static void newVoidSample(int sampleSize)
    {
        sample = new DNACode[sampleSize];
        for (int i = 0; i < sampleSize; i++)
            sample[i] = new DNACode();
    }


    public static void cambiaN(int n)
    {
        //TODO
       // DNACode.setN(n);
        
    }


//Carece de sentido
    public static DNACode[] podaPorcentaje(int porcentaje)
    {
        int cantidad = sample.Length * porcentaje / 100;
        return podaCantidad(cantidad);
    }

//Carece de sentido
    public static DNACode[] podaCantidad(int cantidad)
    {
        DNACode[] devolver = new DNACode[cantidad];
        for (int i=0; i<cantidad; i++)
        {
            devolver[i] = sample[i];
        }
        return devolver;
    }

    public static void generarDescendientes(DNACode[] padres)
    {
        for (int i = 0; i < sample.Length; i++)
            sample[i] = DNACode.combinar(padres);
    }

    public static void generarDescendientes(DNACode[] padres, bool mantenerPadres)
    {
        if (mantenerPadres)
        {
            for (int i = 0; i < padres.Length; i++)
                sample[i] = padres[i];
            for (int i = padres.Length; i < sample.Length; i++)
                sample[i] = DNACode.combinar(padres);
        }
        else
        {
            generarDescendientes(padres);
        }
    }
    
    

    public static void mutar()
    {
        foreach (DNACode adn in sample)
        {
            adn.mutate();
        }
    }

    public static void mutar(int n)
    {
        foreach (DNACode adn in sample)
        {
            adn.mutate(n);
        }
    }


    // getIndividuo(-1) devuelve el último individuo, como en Python

    public static DNACode getIndividuo(int i)
    {
        if (i >= sample.Length || -i > sample.Length) throw new IndexOutOfRangeException();
        if (i < 0) i = sample.Length - i;
        return sample[i];
    }

    public static DNACode[] getIndividuoArray(int[] indices)
    {
        DNACode[] devolver = new DNACode[indices.Length];
        int j = 0;
        foreach (int i in indices)
        {
            if (i >= sample.Length || -i > sample.Length) throw new IndexOutOfRangeException();
            devolver[j] = sample[i];
            j++;
        }
        return devolver;
    }

    public static int length()
    {
        return sample.Length;
    }
}
