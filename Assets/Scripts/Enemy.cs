using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(AudioSource), typeof(Animator), typeof(NavMeshAgent))]
    public abstract class Enemy : MonoBehaviour
    {
        public float speed = 1,atakRange=1,hp = 100,damage=10;
        public Animator animator;
        [SerializeField] NavMeshAgent agent;
        [SerializeField] AudioSource source;
        [SerializeField] AudioClip clipMuerte,clipAtaque;
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
            agent.SetDestination(Player.instance.transform.position);
            if (agent.remainingDistance == atakRange && animator.GetBool("atk") is false) Atacar();
        }
        public virtual void Atacar()
        {
            animator.SetBool("atk", true);
            source.PlayOneShot(clipAtaque);
        }
        public virtual void Morir()
        {
            animator.SetTrigger("morir");
            source.PlayOneShot(clipMuerte);
        }
        
    }
}