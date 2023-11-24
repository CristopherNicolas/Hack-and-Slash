using Assets.Scripts;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            StartCoroutine(Atack());
        }
        cd += Time.deltaTime;
    } 
    IEnumerator Atack()
    {
        cd = maxCD;
        //detectar enemigo mas cercano
        var enemigos = Physics.OverlapSphere(transform.position, 20).ToList();
        if (enemigos.Count == 0) yield break;
         List<Transform> transforms = new List<Transform>();
                enemigos.ForEach(e =>
                {
                    if (e.CompareTag("Enemy")) transforms.Add(e.transform);
                }); if(transforms.Count ==0 ) yield break;
        Transform t = EncontrarTransformMasCercanoEnLista(transform, transforms.ToArray());

        //mostrar 

        // mover hasta el
        float tiempo = Vector3.Distance(transform.position, t.position) / 3;
        print(tiempo);
        transform.DOMove(t.position, tiempo);
        yield return new WaitForSeconds(tiempo+2);

        //regresar a pos player
        transform.DOMove(Player.instance.transform.position, tiempo);
         //esconder
        yield break;
    }
    Transform EncontrarTransformMasCercanoEnLista(Transform objetivo, Transform[] lista)
    {
        Transform transformMasCercano = null;
        float distanciaMinima = float.MaxValue;

        foreach (Transform transformActual in lista)
        {
            // Calcula la distancia entre las posiciones de las transformaciones
            float distancia = Vector3.Distance(objetivo.position, transformActual.position);

            // Comprueba si la distancia es menor que la distancia mínima actual
            if (distancia < distanciaMinima)
            {
                distanciaMinima = distancia;
                transformMasCercano = transformActual;
            }
        }

        return transformMasCercano;
    }

}
