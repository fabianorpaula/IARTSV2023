using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public int TotalMadeira = 0;
    public int TotalComida = 500;
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


}
