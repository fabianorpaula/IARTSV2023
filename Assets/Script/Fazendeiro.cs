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
    public GameObject Lazer;

    public int madeira;
    public int comida;
    public bool loteria = false;

    public enum S_tipo {Lenhador, Agricultor, Maraja};
    public S_tipo MeuTipo;

    private float tempoLazer = 0;

    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        Destino = Casa;
    }

    public void DefinirFuncao(int meuT)
    {
        if (loteria == false)
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
                case 2:
                    MeuTipo = S_tipo.Maraja;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(loteria == true)
        {
            AvisarCasa();
        }
        else
        {
            Agente.SetDestination(Destino.transform.position);
            if (Vector3.Distance(transform.position, Destino.transform.position) < 4)
            {
                MudarDestino();
            }
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
            if (MeuTipo == S_tipo.Maraja)
            {
                Destino = Lazer;
            }
        }
        else if(Destino == Lazer)
        {
            //Agora só vive como maraja;
            loteria = true;
        }
   
    }


    void AvisarCasa()
    {
        tempoLazer += Time.deltaTime;
        if(tempoLazer >= 10)
        {
            Casa.GetComponent<Casa>().ReceberAvisoMaraja();
            tempoLazer = 0;
        }
    }

    public int InformaTipo()
    {
        if (MeuTipo == S_tipo.Lenhador)
        {
            return 0;
        }else if (MeuTipo == S_tipo.Agricultor)
        {
            return 1;
        }else if (MeuTipo == S_tipo.Maraja)
        {
            return 2;
        }else
        {
            return -1;
        }
    }
}
