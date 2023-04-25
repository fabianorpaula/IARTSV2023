using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fazendeiro : MonoBehaviour
{
    private NavMeshAgent Agente;
    public GameObject Destino;
    public GameObject Casa;
    public GameObject Floresta;

    public int madeira;
    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        Destino = Floresta;
    }

    // Update is called once per frame
    void Update()
    {
        Agente.SetDestination(Destino.transform.position);
        if(Vector3.Distance(transform.position, Destino.transform.position) < 4)
        {
            MudarDestino();
        }
    }

    void MudarDestino()
    {
        if(Destino == Floresta)
        {
            madeira = 10;
            Destino = Casa;

        }else if(Destino == Casa)
        {
            Casa.GetComponent<Casa>().TotalMadeira += madeira;
            madeira = 0;
            Destino = Floresta;
        }
   
    }
}
