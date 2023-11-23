 using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using DG.Tweening;

namespace Assets.Scripts
{
    public class EnemigoCharco : Enemy
    {
        public float distanciaParaEncharcare = 6;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && canDetect)
            {
                canDetect = false;
                Player.instance.hp -= damage;
                print("falg enemy");
            }
        }
        private IEnumerator Start()
        {
            while (true)
            {
                while (true)
                {
                    yield return new WaitForSeconds(.1f);
                    if (distanciaParaEncharcare <= agent.remainingDistance && agent.remainingDistance > atakRange)
                    {
                        transform.DOScale(new Vector3(1, .1f, 1), 1.3f);
                        agent.SetDestination(Player.instance.transform.position);

                    }
                    else if (agent.remainingDistance < atakRange)
                    {
                        Atacar();
                    }
                }
            }
        }
        public override void Atacar()
        {
          transform.DOScale(Vector3.one, 1.3f);
            canDetect = true;
            StartCoroutine(AtaqueCharco());
            
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
        public bool canDetect;
        public override void Update()
        {
            agent.SetDestination(Player.instance.transform.position);

         
        }

    }
}