using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenu : MonoBehaviour
{
    public GameObject ItemUI;
    public static bool isOpened;
    private bool Paused = false;

    // Use this for initialization
    void Start()
    {
        isOpened = false;
        ItemUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpened == true)
        { ItemUI.SetActive(true); }

        if (isOpened == false)
        { ItemUI.SetActive(false); }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (isOpened == true) // UI가 열려있는 경우
            {
                ItemUI.SetActive(false);
                isOpened = false;
            }

            else if (isOpened == false) // UI가 닫혀있는 경우
            {
                ItemUI.SetActive(true);
                isOpened = true;
            }
        }
    }
}