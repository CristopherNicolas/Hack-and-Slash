using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHabilidades : MonoBehaviour
{
    public float timeScale = .5f;
    [SerializeField] Animator animator;
    // ataque basico estaqueable, si coliciona con con enemigo, actualizar marcador de combo
    int cantidadDeVecesPrecionado;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && ! Player.instance.pistol.aimCamera.gameObject.activeInHierarchy)
        {
            if (cantidadDeVecesPrecionado > 3) return;
            cantidadDeVecesPrecionado++;
            animator.SetInteger("atack", cantidadDeVecesPrecionado);
        }
        if (Input.GetKeyDown(KeyCode.Q) && Player.instance.pistol.aimCamera.gameObject.activeInHierarchy)
        {
            Player.instance.LanzarBomba();
        }
    }
  
    public void AtaqueBasico()
    {

        Debug.Log("ATK B  count : "+cantidadDeVecesPrecionado);
        if (cantidadDeVecesPrecionado >= 3) { 
        cantidadDeVecesPrecionado = 0;
            animator.SetInteger("atack", cantidadDeVecesPrecionado);
        }
        //chequear si se presiono 2 veces y al terminar continua en  2 para poner en 0 y que no se quede en la animacion de forma permanente.
    }
    void AtaqueDefinitivo()
    {
        animator.SetBool("ulti", true);
    }
    bool isDashing = false;
    IEnumerator StartDash()
    {
        if (isDashing) yield break;
        isDashing = true;
        Time.timeScale = timeScale;
         yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        Time.timeScale = 1;
    }
    public void Dash() => StartCoroutine(StartDash());
}
