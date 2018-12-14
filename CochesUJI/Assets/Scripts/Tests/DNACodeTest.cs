using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;

public class DNACodeTest {

    [Test]
    public void DNACodeTestSimplePasses() {
        // Use the Assert class to test conditions.

        Test_Constructor();
        Test_initialize();
        Test_mutate();
        Test_combine();
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator DNACodeTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }

    private void Test_Constructor()
    {
        DNACode dna = new DNACode();
        foreach (String key in DNACode.KEYS)
        {
            float result = dna.getGen(key);
            Assert.That(result, Is.EqualTo(0));
        }    
    }

    // After the initialization, the sum of all values for the keys must to be equal to DNACode.sumatoryGenValues
    private void Test_initialize()
    {
        DNACode dna = new DNACode().initialize();

        int total_quantity = dna.calculateTotalQuantity();
        int correctValue   = dna.getSumatoryGenValues();

        Assert.That(total_quantity, Is.EqualTo(correctValue));
    }

    private void Test_mutate()
    {
    	int N = 100;
    	for (int i=0; i<N; i++)
    	{
    		DNACode dna = new DNACode().initialize();

    		dna.mutate();
        	int total_quantity = dna.calculateTotalQuantity();
        	int correctValue   = dna.getSumatoryGenValues();

        	Assert.That(total_quantity, Is.EqualTo(correctValue));
    	}
    }

    private void Test_combine()
    {
    	int N = 100;
    	for (int i=0; i<N; i++)
    	{
    		DNACode[] parents = new DNACode[2];
    		parents[0] = new DNACode().initialize();
    		parents[1] = new DNACode().initialize();

    		DNACode new_dna        = DNACode.combine(parents);
    		int     total_quantity = new_dna.calculateTotalQuantity();
        	int     correctValue   = new_dna.getSumatoryGenValues();

        	Assert.That(total_quantity, Is.EqualTo(correctValue));
        }
    }

}
