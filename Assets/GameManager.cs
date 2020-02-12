using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Bola bola;
    public Raquete raquete;
    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    

    // Start is called before the first frame update
    void Start()
    {
        
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        //instancia os objetos do jogo, sendo as raquetes variaveis nomeadas para modificação
        Instantiate(bola);

        Raquete raquete1 = Instantiate(raquete) as Raquete;
        Raquete raquete2 = Instantiate(raquete) as Raquete;
        raquete1.Init(true); //direita
        raquete2.Init(false); //esquerda
    }

    
    
    
}
