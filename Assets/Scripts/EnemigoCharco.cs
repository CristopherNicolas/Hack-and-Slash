using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class EnemigoCharco : Enemy
    {
        Transform player;
        NavMeshAgent agent;
        private void Start()
        {
            player = Player.instance.transform;
        }
        public override void Atacar()
        {
            base.Atacar();

        }
        public override void Update()
        {

            agent.SetDestination(Player.instance.transform.position);
            if (agent.remainingDistance == atakRange && animator.GetBool("atk") is false) Atacar();
        }

    }
}