using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject PauseUI;
	public static bool getOptionUI = false;
	public static bool getPaused = false;
	
	// Use this for initialization
	void Start () {
		PauseUI.SetActive(false);
		//OptionUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Pause"))
		{
            getPaused = !getPaused;
        }

		if (getPaused)
		{
			PauseUI.SetActive(true);
			Time.timeScale = 0;
		}
		
		else
		{
			PauseUI.SetActive(false);
			Time.timeScale = 1f;
		}
	}

    public void callOptionUI()
    {
        getOptionUI = true;
        PauseUI.SetActive(false);
    }
}