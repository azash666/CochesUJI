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
        float correctValue = DNACode.sumatoryGenValues;
        DNACode dna = new DNACode();
        dna.initialize();

        float total_quantity = 0;
        foreach (String key in DNACode.KEYS)
            total_quantity += dna.getGen(key);

        Assert.That(total_quantity, Is.EqualTo(correctValue));


    }
}
