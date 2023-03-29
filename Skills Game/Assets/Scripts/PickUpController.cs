using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
   public GenericShoot gunScript;
   public Rigidbody rb;
   public BoxCollider coll;
   public Transform gunContainer;
   private Transform player;
   private GunManager pistol;
   
   public float pickUpRange;
   public float dropForwardForce, dropUpwardForce;
   public float despawnTime;
   //public int ammo;

   public bool equipped;
   private bool used;
   public static bool slotFull;

   private void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //setup
        if(!equipped){
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
            used = false;
        }
        if(equipped){
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
            used = true;
        }
   }

    private void Update(){

        //Check if player is in range and "E" is pressed
        Vector3 distanceTopPlayer = player.position - transform.position;
        if(!equipped && distanceTopPlayer.magnitude <= pickUpRange && !slotFull && !used) PickUp();

        //Drop if ammo = 0
        if(equipped && gunScript.current_ammo == 0) Drop();

     //    if(equipped && Input.GetMouseButtonDown(0)){
     //      gunScript.fire();
     //    }
    }
   private void PickUp(){
        equipped = true;
        slotFull = true;
        used = true;

        //make RigidBody kinematic and boxcollider a trigger
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Make weapon a child of the character and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        //transform.localScale = Vector3.one;

        //enable Script
        gunScript.enabled = true;
        gunScript.gameObject.GetComponent<Collider>().enabled = false;

        //pistol
        player.GetComponent<GunManager>().SetPistolActive(false);
   }

   private void Drop(){
        equipped = false;
        slotFull = false;

        //Set parent to null
        transform.SetParent(null);

        //make RigidBody not kinematic and boxcollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //GunC carries moment of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //AddForce
        rb.AddForce(player.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(player.up * dropUpwardForce, ForceMode.Impulse);
        //add random Rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random,random,random)*10);

        //disable Script
        gunScript.enabled = false;
        gunScript.gameObject.GetComponent<Collider>().enabled = true;

        //pistol
        player.GetComponent<GunManager>().SetPistolActive(true);

        StartCoroutine(Despawn());
   }

   private IEnumerator Despawn(){
        yield return new WaitForSeconds(despawnTime);
        Destroy(this.gameObject);
   }
}
