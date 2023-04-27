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
    public GameObject Carne;

    public int madeira;
    public int comida;
    public int tipo;
    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        tipo = Random.Range(0, 10);
        if(tipo < 5)
        {
            Destino = Floresta;
        }
        else
        {
            Destino = Carne;
        }
        
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

        }
        else if (Destino == Carne)
        {
            comida = 10;
            Destino = Casa;
        }
        else if(Destino == Casa)
        {
            Casa.GetComponent<Casa>().TotalMadeira += madeira;
            Casa.GetComponent<Casa>().TotalComida += comida;
            madeira = 0;
            comida = 0;
            if (tipo < 5)
            {
                Destino = Floresta;
            }
            else
            {
                Destino = Carne;
            }
        }
   
    }
}
