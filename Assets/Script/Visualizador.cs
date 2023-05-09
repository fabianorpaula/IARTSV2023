using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Visualizador : MonoBehaviour
{
    public TMP_Text populacao;
    public TMP_Text comida;
    public TMP_Text madeira;
    public TMP_Text lazer;
    public TMP_Text tipo;
    public TMP_Text tempo;
    //Onde Eu pego as informa��es
    public Casa MinhaCasa;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        populacao.text = "Popula��o: " + MinhaCasa.Fazendeiros.Count + "/" + (MinhaCasa.QtdCasas * 5);
        comida.text = "Comida: " + MinhaCasa.TotalComida;
        madeira.text = "Madeira: " + MinhaCasa.TotalMadeira;
        lazer.text = "Lazer: " + MinhaCasa.TotalVidaBoa;
        //tipo;
        //tempo;
    }
}