using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("----- Player -------------------")]
    public Rigidbody2D rb;
    [Range(0f, 1000f)] public float jumpForce;
    [Range(0f, 1000f)] public float speed;
    private Touch t;

    [Header("----- Pipes -------------------")]
    public PipesController pipesController;

    [Header("----- Hud -------------------")]
    public HudController hudController;

    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (Input.touchCount > 0)
        {
            t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            }
        }

        if (transform.position.y > 20 || transform.position.y < -20)
        {
            Death();
        }
    }

    public void Death()
    {
        // parar velocidade do player
        rb.velocity = Vector2.zero;

        // Voltar player para posição inicial
        transform.position = Vector2.zero;

        // Voltar tubos para posição inicial
        pipesController.pipesList[0].transform.position = pipesController.pipesInitialPositionsList[0];
        pipesController.pipesList[1].transform.position = pipesController.pipesInitialPositionsList[1];
        pipesController.pipesList[2].transform.position = pipesController.pipesInitialPositionsList[2];

        // zerar pontuação
        hudController.ScoreReset();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            Death();
        }
    }
}
