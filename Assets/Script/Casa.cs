using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public int TotalMadeira = 0;
    public int TotalComida = 500;
    //Relogio
    private float tempoCarne = 0;
    
    
    public GameObject MeuFazendeiro;
    public List<GameObject> Fazendeiros;

    //Informações
    public GameObject Floresta;
    public GameObject Carne;

    private void Start()
    {
       
    }

    private void Update()
    {
        if(TotalComida > 250)
        {
            CriarFazendeiro();
        }
        Consumo();
    }

    void CriarFazendeiro()
    {
        if(TotalComida > 50)
        {
            GameObject MeuF = Instantiate(MeuFazendeiro, transform.position, Quaternion.identity);
            MeuF.GetComponent<Fazendeiro>().Floresta = Floresta;
            MeuF.GetComponent<Fazendeiro>().Carne = Carne;
            MeuF.GetComponent<Fazendeiro>().Casa = this.gameObject;
            TotalComida -= 50;
            Fazendeiros.Add(MeuF);
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
    }

}
