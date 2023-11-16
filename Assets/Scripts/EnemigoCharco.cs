 using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

namespace Assets.Scripts
{
    public class EnemigoCharco : Enemy
    {
        Transform player;
        NavMeshAgent agent;
        float distanciaParaEncharcare = 6;
        private void Start()
        {
            player = Player.instance.transform;
        }
        public override void Atacar()
        {
            base.Atacar();
            
        }
        IEnumerator AtaqueCharco()
        {
            yield return new WaitForSeconds(2.5f);
            Physics.OverlapSphere(transform.position, 1).ToList().
                ForEach(e => { 
                    if(e.CompareTag("Player"))
                    {
                        Player.instance.hp -= damage;
                         Player.instance.characterController.Move(Vector3.up * distanciaParaEncharcare /2 );
                    }
                });

        }
        public override void Update()
        {

            if (distanciaParaEncharcare <= agent.remainingDistance && agent.remainingDistance > atakRange)
                animator.SetBool("encharcarse", true);

            agent.SetDestination(Player.instance.transform.position);
            if (agent.remainingDistance == atakRange && animator.GetBool("atk") is false) Atacar();
        }

    }
}