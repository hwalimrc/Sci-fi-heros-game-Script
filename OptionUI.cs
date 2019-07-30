using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUI : MonoBehaviour {
    public GameObject OptUI;
    public static bool getPaused = false;

    // Use this for initialization
    void Start()
    {
        OptUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.getOptionUI == true)
        {
            OptUI.SetActive(true);
        }

        if (Input.GetButtonDown("Pause"))
        {
            if (PauseMenu.getOptionUI)
                OptUI.SetActive(false);
        }
    }
}