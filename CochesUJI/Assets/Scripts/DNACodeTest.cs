using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DNACodeTest : MonoBehaviour {
    DNACode individuo;
    String path = "Assets/Scripts/DNACodeTest.txt";
    // Use this for initialization
    void Start () {
        if(!File.Exists(path)) File.CreateText(path);
        File.WriteAllText(path, "TESTS DE LA CLASE DNACode\n-------------------------\n");
        File.AppendAllText(path, "  Constructor\n");
        File.AppendAllText(path, "GenMaxValue = " + DNACode.GEN_MAX_VALUE + "\n");
        File.AppendAllText(path, "GenMinValue = " + DNACode.GEN_MIN_VALUE + "\n");
        individuo = new DNACode();
        foreach(string key in DNACode.KEYS)
        {
            File.AppendAllText(path, key + " --> " + individuo.getGen(key)+ "\n");
        }


        File.AppendAllText(path, "\n  .initialize()\n");
        File.AppendAllText(path, "n=" + individuo.getN()+"\n");
        for (int i = 0; i < 20; i++)
        {
            File.AppendAllText(path, "-----Prueba numero " + i+"\n");
            individuo = individuo.initialize();
            foreach (string key in DNACode.KEYS)
            {
                File.AppendAllText(path, key + " --> " + individuo.getGen(key) + "\n");
            }
        }
        DNACode.setSumatoryGenValues(DNACode.KEYS.Length * DNACode.GEN_MAX_VALUE);
        /*
        Debug.Log("n="+ individuo.getN());
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("    Prueba numero " + i);
            individuo = individuo.initialize();
            foreach (string key in DNACode.KEYS)
            {
                Debug.Log(key + " --> " + individuo.getGen(key));
            }
        }
        DNACode.setSumatoryGenValues(DNACode.KEYS.Length * DNACode.GEN_MAX_VALUE + 1);
        
        Debug.Log("n=" + individuo.getN());
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("    Prueba numero " + i);
            try
            {
                individuo = individuo.initialize();
                foreach (string key in DNACode.KEYS)
                {
                    Debug.Log(key + " --> " + individuo.getGen(key));
                }
            }catch(Exception e)
            {
                Debug.Log("Produce excepción");
            }
        }*/
        
    }

    // Update is called once per frame
    void Update () {
	}
}
