using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(AudioSource),  typeof(NavMeshAgent))]
    public abstract class Enemy : MonoBehaviour
    {
        public float speed = 1,atakRange=1,hp = 100,damage=10;
        public Animator animator; // si no funciona es porque debe agregarse al objeto con el rig
        public  NavMeshAgent agent;
        [SerializeField] AudioSource source;
        [SerializeField] AudioClip clipMuerte,clipAtaque;
        Coroutine death;
        //public virtual void
        private void Awake()
        {
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();

        }
        private void Start()
        {
            agent.velocity = new Vector3(speed,speed,speed);
        }
        public virtual void Update()
        {
            if (hp <= 0 && death == null) { Morir(); return; }
            else if (hp <= 0 && death is not null) return;
                agent.SetDestination(Player.instance.transform.position);
            if (agent.remainingDistance == atakRange && animator.GetBool("atk") is false) Atacar();
        }
        public virtual void Atacar()
        {
            if (hp <= 0) return;
            animator.SetBool("atk", true);

            source.PlayOneShot(clipAtaque);
        }
        public virtual void Morir() => death = StartCoroutine(DeathDestroy());
        IEnumerator DeathDestroy()
        {
            animator.SetTrigger("morir");
            source.PlayOneShot(clipMuerte);
            agent.isStopped = true;
            yield break;
        }
    }
}