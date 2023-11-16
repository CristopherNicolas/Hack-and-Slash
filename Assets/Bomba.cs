using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public AudioSource audioSource;
    public float time= 3,radius=1.5f,force = 5;
    public ParticleSystem particle;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(time);
        Reventar();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") is false)
            Reventar();
    }
    public void Reventar()
    {
        Instantiate(particle);
        audioSource.Play(); 
        var arr = Physics.OverlapSphere(transform.position, radius);
        foreach (var item in arr)
        {
            var rb = item.GetComponent<Rigidbody>();    
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject);
    }
}
