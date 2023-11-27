using System.Collections;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(MeshCollider))]
    /// <summary>
    /// Se adjunta a el game object de la hoz del prota
    /// </summary>
    public class HozPlayer : MonoBehaviour
    {
        public bool canAtak;
        public float damage = 30;
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Enemy") && canAtak)
            {
              
                SetDamage(other.GetComponent<Enemy>());
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                SetDamage(other.GetComponent<Enemy>());
            }
        }
        void SetDamage(Enemy enemy)
        {
            enemy.hp -= damage;
            print($"{enemy.name} hp : {enemy.hp}");

        }
    }
}