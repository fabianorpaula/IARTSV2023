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
    

    public enum S_tipo {Lenhador, Agricultor};
    public S_tipo MeuTipo;


    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        
        
    }

    public void DefinirFuncao(int meuT)
    {
        switch (meuT)
        {
            case 0:
                //Coleta Madeira
                MeuTipo = S_tipo.Lenhador;
                break;
            case 1:
                //Coleta Comida
                MeuTipo = S_tipo.Agricultor;
                break;
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
            if (MeuTipo == S_tipo.Lenhador)
            {
                Destino = Floresta;
            }
           if(MeuTipo == S_tipo.Agricultor)
            {
                Destino = Carne;
            }
        }
   
    }
}
