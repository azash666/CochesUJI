using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneticsManager {
    //TODO: Cambiar nombre de la clase
    
    private static DNACode[] sample;


    public static void newInitialSample(int sampleSize, int sumatoryGenValues)
    {
        

    }


    public static void newVoidSample(int sampleSize)
    {
        sample = new DNACode[sampleSize];
        for (int i = 0; i < sampleSize; i++)
            sample[i] = new DNACode();
    }


    public static void changeSumatoryGenValues(int newSumatoryGenValues)
    {
        DNACode.setSumatoryGenValues(newSumatoryGenValues);
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

    public static void generateDescendants(DNACode[] parents)
    {
        for (int i = 0; i < sample.Length; i++)
            sample[i] = DNACode.combine(parents);
    }

    public static void generateDescendants(DNACode[] parents, bool keepParents)
    {
        if (keepParents)
        {
            for (int i = 0; i < parents.Length; i++)
                sample[i] = parents[i];
            for (int i = parents.Length; i < sample.Length; i++)
                sample[i] = DNACode.combine(parents);
        }
        else
        {
            generateDescendants(parents);
        }
    }
    
    

    public static void mutate()
    {
        foreach (DNACode adn in sample)
        {
            adn.mutate();
        }
    }

    public static void mutate(int n)
    {
        foreach (DNACode adn in sample)
        {
            adn.mutate(n);
        }
    }


    // getIndividuo(-1) devuelve el último individuo, como en Python

    public static DNACode getSingleSample(int index)
    {
        if (index >= sample.Length || -index > sample.Length) throw new IndexOutOfRangeException();
        if (index < 0) index = sample.Length - index;
        return sample[index];
    }

    public static DNACode[] getSubarraySample(int[] indexes)
    {
        DNACode[] toReturn = new DNACode[indexes.Length];
        int j = 0;
        foreach (int i in indexes)
        {
            if (i >= sample.Length || -i > sample.Length) throw new IndexOutOfRangeException();
            toReturn[j] = sample[i];
            j++;
        }
        return toReturn;
    }

    public static int length()
    {
        return sample.Length;
    }
}
