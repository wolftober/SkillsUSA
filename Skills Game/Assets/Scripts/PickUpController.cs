using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
   public Shooting gunScript;
   public Rigidbody rb;
   public BoxCollider coll;
   public Transform player, gunContainer;
   
   public float pickUpRange;
   public float dropForwardForce, dropUpwardForce;
   public int ammo;

   public bool equipped;
   public static bool slotFull;

   private void Start(){
        ammo = gunScript.GetComponent<Shooting>().current_ammo;
        //setup
        if(!equipped){
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if(equipped){
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
   }

    private void Update(){
        //Check if player is in range and "E" is pressed
        Vector3 distanceTopPlayer = player.position - transform.position;
        if(!equipped && distanceTopPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();

        //Drop if ammo = 0
        if(equipped && ammo == 0) Drop();
    }
   private void PickUp(){
        equipped = true;
        slotFull = true;

        //Make weapon a child of the character and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //make RigidBody kinematic and boxcollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //enable Script
        gunScript.enabled = true;
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
   }
}
