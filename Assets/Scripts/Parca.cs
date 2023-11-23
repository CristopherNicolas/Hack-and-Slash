using System.Collections;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

namespace Assets.Scripts
{/// <summary>
/// como la hoz esta en un  game object, añadir game object al rigg y poner este componente
/// </summary>
    public class Parca : Enemy
    {
        public CinemachineImpulseSource impulseSource;
        public HozParca hoz; 
        public override void Atacar()
        {
            base.Atacar();
            StartCoroutine(Elevar());
        }
        public override void Update()
        {
            base.Update();
        }
        IEnumerator Elevar()
        {
            agent.gameObject.SetActive(false);
            Vector3 startPos = transform.position;
            transform.DOMove(new Vector3(0,transform.position.y + Random.Range(5, 10),0),3);
            yield return new WaitForSeconds(3);
            //quedarse en el aire y poner animacion de ataque, luego caida
            animator.SetBool("ataqueAire", true);
            yield return new WaitForSeconds(2);
            transform.DOMove(startPos,1.5f);
            yield return new WaitForSeconds(1.5f);
            impulseSource.GenerateImpulse();
            yield return new WaitForSeconds(1);
            agent.gameObject.SetActive(true);

        }
    }
}