using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject panelEnd;
    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelEnd.SetActive(true);
            await Task.Delay(2000);
            Application.Quit();
        }
    }
}
