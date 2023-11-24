using Assets.Scripts;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.DOScale(Vector3.zero, .95f);
            Player.instance.pistol.balas += 10;
            UISystem.instance.balasCountText.transform.DOPunchScale(Vector3.one, .35f);
            Destroy(gameObject, 1);   
        }
        
    }
}
