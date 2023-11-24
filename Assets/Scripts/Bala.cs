using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
	float damage = 30;
	ParticleSystem particles;
	private void Start()
	{
		Destroy(gameObject,15);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.GetComponent<Enemy>().hp -= 30;
			//Instantiate(particles, transform.position, Quaternion.identity);
			print("bala impactada");
			ContadorCombo.Instance.AddToCount(1);
			Destroy(gameObject);
			
		}
	}
	private void Update()
	{
		transform.Translate(Vector3.forward * Time.deltaTime*10);
	}
}
