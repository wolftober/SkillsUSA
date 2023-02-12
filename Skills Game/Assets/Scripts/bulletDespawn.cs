using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDespawn : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if(collision.gameObject.CompareTag("Enemy")){
            Destroy(this.gameObject);
        }
    }

}
