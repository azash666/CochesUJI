using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class DNACodeTest {

    [Test]
    public void DNACodeTestSimplePasses() {
        // Use the Assert class to test conditions.
        DNACode individuo = new DNACode();
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void otro()
    {
        
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator DNACodeTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
