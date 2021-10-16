using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesController : MonoBehaviour
{
    [Header("----- Player ----------------")]
    public GameObject Player;

    [Header("----- Lists -----------------")]
    public List<GameObject> pipesList;
    [HideInInspector] public List<Vector2> pipesInitialPositionsList;

    [Header("----- Distances -------------")]
    [Range(0f, 20f)] public float playerPipeDistance;
    [Range(0f, 20f)] public float spawnPipeDistance;

    [Header("----- Hud -------------------")]
    public HudController hudController;


    void Start()
    {
        pipesInitialPositionsList.Add(pipesList[0].transform.position);
        pipesInitialPositionsList.Add(pipesList[1].transform.position);
        pipesInitialPositionsList.Add(pipesList[2].transform.position);
    }

    void Update()
    {
        if (Player.transform.position.x - pipesList[0].transform.position.x > playerPipeDistance) 
        {
            hudController.ScoreIncrease();
            int rand = Random.Range(-3, 3);
            pipesList[0].transform.position = new Vector2(pipesList[0].transform.position.x + spawnPipeDistance, rand);
        }

        if (Player.transform.position.x - pipesList[1].transform.position.x > playerPipeDistance)
        {
            hudController.ScoreIncrease();
            int rand = Random.Range(-3, 3);
            pipesList[1].transform.position = new Vector2(pipesList[1].transform.position.x + spawnPipeDistance, rand);
        }

        if (Player.transform.position.x - pipesList[2].transform.position.x > playerPipeDistance)
        {
            hudController.ScoreIncrease();
            int rand = Random.Range(-3, 3);
            pipesList[2].transform.position = new Vector2(pipesList[2].transform.position.x + spawnPipeDistance, rand);
        }
    }
}
