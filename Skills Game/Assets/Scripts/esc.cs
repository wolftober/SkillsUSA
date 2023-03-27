using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esc : MonoBehaviour
{
    public GameObject MainMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu.GetComponent<MainMenu>().ReturnToMenu();
        }
    }
}
