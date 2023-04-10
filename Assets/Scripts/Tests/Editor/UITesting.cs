using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools.Utils;


public class UITesting
{
    [Test]
    public void ScrollBarHaveCorrectInitValuesTest()
    {
        var scrollBar = GameObject.FindObjectOfType<Scrollbar>();

        Assert.IsNotNull(scrollBar);
        Assert.Greater(scrollBar.value, 0f);
        Assert.Less(scrollBar.value, 0.3f);
    }
}
