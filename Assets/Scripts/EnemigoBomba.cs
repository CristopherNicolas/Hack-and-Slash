using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemigoBomba : Enemy
    {
        public float timeToExplosion = 3,radius=2,force=1.5f;
        public override void Atacar()
        {
            base.Atacar();
            StartCoroutine(Explotar(3,radius,force));
        }
        IEnumerator Explotar(float time,float radius,float force)
        {
            speed = 0;
            // poner sonido comenzar cuenta
            yield return new WaitForSeconds(time);
            var colls = Physics.OverlapSphere(transform.position, radius);
            //poner sonido explosion
            foreach (var item in colls)
            {
                var rb = item.GetComponent<Rigidbody>();
                if (rb is not null)
                {
                    if (item.CompareTag("Player")) item.GetComponent<Player>().hp -= 15;
                    rb.AddExplosionForce(force, transform.position, radius);
                }
            }
            Destroy(gameObject);
        }
        
    }
}