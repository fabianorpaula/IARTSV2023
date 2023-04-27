using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public int TotalMadeira = 100;
    public int TotalComida = 500;
    public int QtdCasas = 1;

    //Relogio
    private float tempoCarne = 0;
    private float tempoMadeira = 0;
    
    
    public GameObject MeuFazendeiro;
    public List<GameObject> Fazendeiros;

    //Informações
    public GameObject Floresta;
    public GameObject Carne;

    private void Start()
    {
        CriarFazendeiro(1);
        CriarFazendeiro(1);
        CriarFazendeiro(1);
        CriarFazendeiro(0);
        CriarFazendeiro(0);


    }

    private void Update()
    {
        if(TotalComida > 250)
        {
            CriarFazendeiro(1);
        }
        if(TotalMadeira > 200)
        {
            CriarCasa();
        }
        Consumo();
    }

    void CriarFazendeiro(int escolhetipo)
    {
        //Limite de População
        if ((QtdCasas * 5) > Fazendeiros.Count)
        {
            //Limite de Comida
            if (TotalComida > 50)
            {
                GameObject MeuF = Instantiate(MeuFazendeiro, transform.position, Quaternion.identity);
                MeuF.GetComponent<Fazendeiro>().Floresta = Floresta;
                MeuF.GetComponent<Fazendeiro>().Carne = Carne;
                MeuF.GetComponent<Fazendeiro>().Casa = this.gameObject;
                TotalComida -= 50;
                Fazendeiros.Add(MeuF);
                MeuF.GetComponent<Fazendeiro>().DefinirFuncao(escolhetipo);
            }
        }
    }

    void CriarCasa()
    {
        if(TotalMadeira > 100)
        {
            TotalMadeira = TotalMadeira - 100;
            QtdCasas++;
        }
    }

    void Consumo()
    {
        tempoCarne += Time.deltaTime;
        if(tempoCarne > 5)
        {
            tempoCarne = 0;
            TotalComida = TotalComida - Fazendeiros.Count;
            if(TotalComida < 0)
            {
                Debug.Log("Morreu De Fome!!!!");
                Time.timeScale = 0;
            }
        }

        tempoMadeira += Time.deltaTime;
        if (tempoMadeira > 10)
        {
            tempoMadeira = 0;
            TotalMadeira = TotalMadeira - Fazendeiros.Count;
            if (TotalMadeira < 0)
            {
                Debug.Log("Morreu De Fome!!!!");
                Time.timeScale = 0;
            }
        }
    }

}
