﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed = 2f;
    
    float radius;
    Vector2 direction;
    public int placarDireita;
    public int placarEsquerda;
    public GUIStyle style;

    void Start()
    {
        style.fontSize = 100;
        placarDireita = 0;
        placarEsquerda = 0;
        direction = new Vector2(Random.value, Random.value);
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(direction * speed * Time.deltaTime);
        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {   
            //se colidir com o topo inverte a direção;
            direction.y = -direction.y;
        }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            //se colidir com o topo inverte a direção;
            direction.y = -direction.y;
        }
        //condições para fim de jogo;
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            //caso alguem ganhe o placar muda e a bola volta par o inicio
         
            GameOver(true);
        }
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
          
            GameOver(false);

        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(300f, 10f, 100f, 20f), "" + placarEsquerda, style);
        GUI.Label(new Rect(600f, 10f, 100f, 20f), "" + placarDireita, style);
    }

    public void GameOver(bool rightWon)
    {
        if (rightWon)
        {
            //se a direita ganhou a bola vai primeiro pra direita
            Vector2 centerPos = new Vector2(0.5f, 0.5f);
            transform.position = centerPos;
            direction = new Vector2(Random.value, Random.value);
            //atualiza o placar
            placarDireita++;
        }
        else
        {
            //se a esquerda ganhou a bola vai primeiro pra esquerda
            Vector2 centerPos = new Vector2(0.5f, 0.5f);
            transform.position = centerPos;
            direction = new Vector2(-Random.value, -Random.value);
            //atualiza o placar
            placarEsquerda++;
        }
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger: "+ other.tag);
        
        //define a colisão para objetos de tag "Raquete"
        if(other.tag == "Raquete")
        {
            bool isRight = other.GetComponent<Raquete>().isRight;
            if (isRight == true && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            else if (isRight == false&& direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
    }

}
