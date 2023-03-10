using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private float dist;
    public float moveSpeed = 3;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);
        transform.LookAt(player);
        GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed );
    }
     //DIE!
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Bullet"))
            Destroy(gameObject);
    }
}
