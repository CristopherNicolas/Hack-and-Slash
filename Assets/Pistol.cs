using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject movementCamera, aimCamera;
   CinemachineImpulseSource source;
    private void Start()
    {

        // al disparar : source.GenerateImpulse()
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1) && !aimCamera.gameObject.activeInHierarchy)
        {
            movementCamera.gameObject.SetActive(false);
            aimCamera.gameObject.SetActive(true);
            StartCoroutine(ShowAim());
        }
        else if(Input.GetMouseButtonUp(1) && !movementCamera.gameObject.activeInHierarchy)
        {
            movementCamera.gameObject.SetActive(true);
            aimCamera.gameObject.SetActive(false);
            aim.transform.DOScale(Vector3.zero, .21f);
        }
    }
    public GameObject aim;
    IEnumerator ShowAim()
    {
        yield return new WaitForSeconds(.45f);
        aim.transform.DOScale(Vector3.one, .25f);
    }
}
