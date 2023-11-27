using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class AbrirPuzzle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.Puzzle2();
            Destroy(gameObject);   
        }
    }
}
