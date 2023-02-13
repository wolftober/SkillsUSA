using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
