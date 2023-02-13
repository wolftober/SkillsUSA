using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class returntomenu : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        Button b = button.GetComponent<Button>();
        b.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // put code here
    }
}
