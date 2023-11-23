using Assets.Scripts;
using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject movementCamera, aimCamera,balaPrefab,canonObject;
    public CinemachineImpulseSource source;
    public ParticleSystem particles;
    public Animator animator;
    public Transform brazoPistol;
    float pistolCD = .35f;

   
    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            //rotar al estar apuntando
           Player.instance.transform.parent.Rotate(Vector3.up  , 3 * Input.GetAxis("Mouse X"));
            //brazoPistol.Rotate(Vector3.forward * 3 * Input.GetAxis("Vertical"));
            
        }
        if(Input.GetMouseButtonDown(1) && !aimCamera.gameObject.activeInHierarchy)
        {
            animator.SetBool("apuntar", true);
            movementCamera.gameObject.SetActive(false);
            aimCamera.gameObject.SetActive(true);
            StartCoroutine(ShowAim());
        }
        else if(Input.GetMouseButtonUp(1) && !movementCamera.gameObject.activeInHierarchy)
        {
            animator.SetBool("apuntar", false);
            movementCamera.gameObject.SetActive(true);
            aimCamera.gameObject.SetActive(false);
            aim.transform.DOScale(Vector3.zero, .21f);
        }
        if (pistolCD < .35f) pistolCD += Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && aimCamera.gameObject.activeInHierarchy && pistolCD >= .35f)
        {
            Disparar();
            pistolCD = 0;
        }
    }
    public GameObject aim;
    IEnumerator ShowAim()
    {
        yield return new WaitForSeconds(.45f);
        if (!aimCamera.gameObject.activeInHierarchy) yield break;
        aim.transform.DOScale(Vector3.one, .25f);
    }
    public void Disparar()
    {
        //Instantiate(particles);
        //poner sonido disparo
        Instantiate(balaPrefab, canonObject.transform.position,Player.instance.transform.parent.rotation);
        source.GenerateImpulse();
    }
}
