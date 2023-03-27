using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basiccrate : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject interactText;
    private bool canInteract = false;
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, playerObject.transform.position);
        
        if (distanceFromPlayer <= 7)
        {
            interactText.SetActive(true);
            canInteract = true;
        }
        else
        {
            interactText.SetActive(false);
            canInteract = false;
        }
        
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            // For now, interacting just destroys the crate
            Destroy(gameObject);
        }
    }
}
