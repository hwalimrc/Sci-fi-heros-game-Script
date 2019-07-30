using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    public void ScaneChange1()
    { SceneManager.LoadScene("HowToPlay"); }
    
    public void SceneChange2()
    { SceneManager.LoadScene("SampleScene"); }

    public void MainScene()
    { SceneManager.LoadScene("TitleScreen"); }

    public void OptionScene()
    { SceneManager.LoadScene("Option"); }
}