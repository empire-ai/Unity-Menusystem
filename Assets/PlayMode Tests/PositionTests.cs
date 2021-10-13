using System.Collections;
using MenuSystem.Menus;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PositionTests
{
    bool sceneLoaded = false;

    [OneTimeSetUp]
    public void Setup()
    {
        SceneManager.sceneLoaded += (scene, loaded) =>
        {
            if (scene.name == "Demo Scene")
                sceneLoaded = true;
        };
        SceneManager.LoadScene("Demo Scene", LoadSceneMode.Single);
    }

    [UnityTest]
    public IEnumerator MenuPositionCorrect()
    {
        yield return new WaitUntil(() => sceneLoaded);

        var menuContainer = GameObject.FindObjectOfType<MenuContainer>();
        var openClose = GameObject.FindObjectOfType<ShowHideMenu>();

        //Menu should be opened but we check for closed position to fail the test on purpose

        Assert.AreEqual(menuContainer.Current.gameObject.transform.localPosition, 
            new Vector3(openClose.ClosePosition.x, openClose.ClosePosition.y, 0));
    }
}
