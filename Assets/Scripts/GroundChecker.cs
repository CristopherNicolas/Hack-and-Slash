using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField]Player player;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            player.isGrounded = true;
            print("coll enter");
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            player.isGrounded = false ;
            print("coll exit");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("floor"))
        {
            player.isGrounded = true;
           // print("trig enter");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("floor"))
        {
            player.isGrounded = false;
           // print("trig exit");
        }
    }
}
