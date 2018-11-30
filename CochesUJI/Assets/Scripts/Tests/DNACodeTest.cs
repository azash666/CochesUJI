using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class DNACodeTest {

    [Test]
    public void DNACodeTestSimplePasses() {
        // Use the Assert class to test conditions.

        TestConstructor();
        //Assert.That(resultadoObtenido, Is.EqualTo(resultadoEsperado));

    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator DNACodeTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }

    private void TestConstructor()
    {
        DNACode dna = new DNACode();
        foreach (String key in DNACode.KEYS)
        {
            float res = dna.getGen(key);
            Assert.That(res, Is.EqualTo(0));
        }    
    }
}
