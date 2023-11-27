using UnityEngine;

namespace Assets.Scripts
{
    public class HozParca : MonoBehaviour
    {
        bool canDetect;
        float hozDamage = 30;
        public void ActivarHozDesactivarHoz() => canDetect = canDetect? false: true;
       
        private void OnTriggerEnter(Collider other)
        {
            if (canDetect && other.CompareTag("Player"))
            {
                Player.instance.hp -= hozDamage;
                canDetect = false;
            }
        }
    }
}