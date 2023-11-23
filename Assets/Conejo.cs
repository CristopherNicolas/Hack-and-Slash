using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Conejo: MonoBehaviour
{
    public NavMeshAgent agent;
    public static Conejo instance;
    public   float cd = 8 ,maxCD =8;

    private void Start()
    {
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if(instance == null) instance = this;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && cd > maxCD)
        {
            
        }
        cd -= Time.deltaTime;
    } 
    IEnumerator Atack()
    {
        yield break;
    }

}
