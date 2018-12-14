using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class DNACode
    {
        public readonly static int GEN_MIN_VALUE = 0;
        public readonly static int GEN_MAX_VALUE = 10;

        public readonly static String[] KEYS = { "velocidadMaxima", "aceleracion", "frenado", "agarre", "peso", "punteria", "prudencia", "anguloMaxGiro" };
        private Dictionary<String, int> dna;                                                                                            //La key será el nombre del gen y el int el valor de 0/1 a 10.

        public static int sumatoryGenValues = 40;

        //CONSTRUCTORES
        //Crear un nuevo individuo aleatorio


        //Crear un individuo vacio
        public DNACode()
        {
            dna = new Dictionary<string, int>();
            foreach (String key in KEYS)
            {
                dna[key] = GEN_MIN_VALUE;
            }
        }


        //METODOS
        //Inicializa un nuevo individuo
         public DNACode initialize()
        {
            dna = new Dictionary<string, int>();
            foreach (string key in KEYS)
            {
                dna[key] = GEN_MIN_VALUE;
            }
            addQuantity(sumatoryGenValues);
            return this;
        }


        //Combina genes de un vector de padres para crear un nuevo individuo
        public static DNACode combine(DNACode[] parents)
        {
            System.Random rnd = new System.Random();
            DNACode toReturn = new DNACode();
            foreach (string key in KEYS)
            {
                int aux = rnd.Next(0, parents.Length);
                int val = parents[aux].getGen(key);
                toReturn.addGen(key, val);
            }
            toReturn.addQuantity(-toReturn.incrementFromSumatoryGenValues());//TODO Cambiar descripcion N

            return toReturn;
        }

        public static DNACode combine(DNACode[] parents, int numToMutate)
        {
            DNACode toReturn = combine(parents);
            toReturn.mutate(numToMutate);
            return toReturn;
        }


        private int incrementFromSumatoryGenValues()
        {
            int sum = 0;
            foreach (string key in KEYS)
            {
                sum += getGen(key);
            }
            return sum - sumatoryGenValues;
        }


        //Esta función añade una cantidad "valor" a los genes. Si valor < 0, los resta
        private void addQuantity(int valueToAdd)
        {
            System.Random rnd = new System.Random();
            List<String> auxKeys = new List<String>();
            int auxValue;
            foreach (String key in KEYS)
                if ((dna[key] > GEN_MIN_VALUE && valueToAdd < 0) || (dna[key] < GEN_MAX_VALUE && valueToAdd > 0))
                {
                    auxKeys.Add(key);
                }

            if (valueToAdd > 0)
                auxValue = valueToAdd;
            else
                auxValue = -valueToAdd;

            for (int i = 0; i < auxValue; i++)
            {
                int aux = rnd.Next(0, auxKeys.Count);
                int val = dna[auxKeys[aux]];
                if (valueToAdd > 0)
                    dna[auxKeys[aux]] = val + 1;
                else
                    dna[auxKeys[aux]] = val - 1;
                if ((val >= GEN_MAX_VALUE - 1 && valueToAdd > 0) || (val <= GEN_MIN_VALUE + 1 && valueToAdd < 0)) auxKeys.RemoveAt(aux);
            }
        }




        public void mutate(int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                mutate();
            }

        }

        // Mutate two gens randomly. Sum 1 to one, and substract 1 to another
        public void mutate()
        {
            System.Random rnd = new System.Random();
            int auxUp, valUp, auxDown, valDown;

            // list of the potential gens to be increased
            List<String> auxKeysUp = new List<String>();
            foreach (String key in KEYS)
                if (dna[key] < GEN_MAX_VALUE)
                {
                    auxKeysUp.Add(key);
                }

            // list of the potential gens to be decreased                
            List<String> auxKeysDown = new List<String>();
            foreach (String key in KEYS)
                if (dna[key] > GEN_MIN_VALUE)
                {
                    auxKeysDown.Add(key);
                }

            // Look for one gen to increase
            auxUp = rnd.Next(0, auxKeysUp.Count);
            String keyUp = auxKeysUp[auxUp];
            valUp = dna[keyUp];

            // Look for one gen to decrease
            if (auxKeysDown.Contains(keyUp)) auxKeysDown.Remove(keyUp);
            auxDown = rnd.Next(0, auxKeysDown.Count);
            valDown = dna[auxKeysDown[auxDown]];

            dna[KEYS[auxUp]] = valUp + 1;
            dna[KEYS[auxDown]] = valDown - 1;
        }



        private void addGen(string key, int valor)
        {
            dna[key] = valor;
        }


        public int getGen(string key)
        {
            return dna[key];
        }


        public static void setSumatoryGenValues(int sumatoryGenValues)
        {
            if (sumatoryGenValues > KEYS.Length * (GEN_MAX_VALUE - GEN_MIN_VALUE))
            {
                throw new ArgumentOutOfRangeException();
            }
            DNACode.sumatoryGenValues = sumatoryGenValues;
        }


        public int getN()
        {
            return sumatoryGenValues;
        }

        public int calculateTotalQuantity()
        {
            float total_quantity = 0;
            foreach (String key in KEYS)
                total_quantity += dna.getGen(key);
            return total_quantity;
        }

    }
