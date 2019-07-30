using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class characterUI : MonoBehaviour {
    Text HPLable;

    void Awake()
    {
        HPLable = GetComponent<Text>();
    }

    void Update()
    {
        HPLable.text = PlayerHealth.currentHealth.ToString();
        if(PlayerHealth.dead == true)
        {
            HPLable.text = "Game Over";
        }
    }
}