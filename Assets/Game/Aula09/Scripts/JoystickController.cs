using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public Transform player;
    public Transform circle;
    public Transform outerCircle;
    public float speed = 10.0f;

    private Vector2 pointA;
    private Vector2 pointB;
    private Vector2 offset;
    private Vector2 direction;
    private Touch t;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                // pointA é a primeira posição de toque na tela
                // ScreenToWorldPoint converte a posição do toque em pixels para coordenadas (x,y)
                pointA = Camera.main.ScreenToWorldPoint(t.position);

                // Posição onde meu joystick irá aparecer ao tocar a tela
                circle.position = pointA;
                outerCircle.position = pointA;

                // Habilita a renderização do joystick na cena
                circle.GetComponent<SpriteRenderer>().enabled = true;
                outerCircle.GetComponent<SpriteRenderer>().enabled = true;
            }

            // pointB é a última posição de toque na tela
            pointB = Camera.main.ScreenToWorldPoint(t.position);

            // Deslocamento (x,y)
            offset = pointB - pointA;

            // Restringe o deslocamento em magnitude 1.0f para determinar a direção
            direction = Vector2.ClampMagnitude(offset, 1.0f);

            moveCharacter(direction);

            // Deslocamento do objeto circle (x,y)
            circle.position = pointA + direction * 5;
        }
        else
        {
            // Desabilita a renderização do joystick na cena
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
        /** 
         * O deltaTime é o intervalo de tempo entre um Update e outro.
         * Time.deltaTime garante que o objeto terá uma velocidade constante. 
         * Se você remover o deltaTime do cálculo, o objeto se movimentará 
         * diferentes distâncias a cada segundo.
         * **/
    }
}