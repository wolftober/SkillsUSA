using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateLoot : MonoBehaviour
{
    public GameObject drop;
    public Transform box;

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Bullet")){
            Instantiate(drop, box.position,  Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
