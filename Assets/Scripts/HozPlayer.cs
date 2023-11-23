using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Se adjunta a el game object de la hoz del prota
    /// </summary>
    public class HozPlayer : MonoBehaviour
    {
        public bool canAtak;
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Enemy"))
            {
              //  other.get
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {

            }
        }

    }
}