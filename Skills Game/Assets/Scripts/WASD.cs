using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    public float speed = 0.02f;
    public Transform spawn;

    // Update is called once per frame
    void Update()
    {
        // Detects wasd key presses and assigns movement values to "xDirec" and "zDirec"
        float xDirec = Input.GetAxis("Horizontal");
        float zDirec = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirec, 0.0f, zDirec); // creates the move force

        transform.position += moveDirection * speed;
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("wall")){
            this.gameObject.transform.position = spawn.transform.position;
        }
    }
}
