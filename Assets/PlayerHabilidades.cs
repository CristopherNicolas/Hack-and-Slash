using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerHabilidades : MonoBehaviour
{
    public float timeScale = .5f;
    [SerializeField] Animator animator;
    // ataque basico estaqueable, si coliciona con con enemigo, actualizar marcador de combo
    int cantidadDeVecesPrecionado;
    void AtaqueBasico()
    {
        string atkBStringAnimatorID = "atkB";
        if (cantidadDeVecesPrecionado == 1) atkBStringAnimatorID = "atkB1";
        else if (cantidadDeVecesPrecionado == 2) atkBStringAnimatorID = "atkB2";

        animator.SetBool(atkBStringAnimatorID, true);
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
