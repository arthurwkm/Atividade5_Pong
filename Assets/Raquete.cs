using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raquete : MonoBehaviour
{
    [SerializeField]
    float speed = 15f;
    float height;

    string input;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        
    }

    public void Init(bool isRightRaquete)
    {
        isRight = isRightRaquete;
        Vector2 pos = Vector2.zero;
        if (isRightRaquete)
        {
            //manda a raquete para a direita da tela
            pos = new Vector2(GameManager.topRight.x, 0);
            //adiciona uma pequena distancia da tela (para não ficar "grudado")
            pos -= Vector2.right * transform.localScale.x;
            input = "RaqueteDireita";
        }
        else
        {
            //manda a raquete para a esquerda da tela
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            //adiciona uma pequena distancia da tela (para não ficar "grudado")
            pos += Vector2.right * transform.localScale.x;
            input = "RaqueteEsquerda";
        }

        transform.position = pos;

        transform.name = input;
    }

    // Update is called once per frame
    void Update()
    {
        //movimenta a raquete de acordo com o input a cada frame,
        //multiplicado por deltaTime para normalizar a velocidade independente do framerate
        float move = Input.GetAxis(input) * Time.deltaTime * speed;
        
        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }
        transform.Translate(move * Vector2.up);
    }
}
