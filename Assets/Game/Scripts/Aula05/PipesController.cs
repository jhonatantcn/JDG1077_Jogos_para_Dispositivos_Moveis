using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesController : MonoBehaviour
{
    public GameObject player;
    public HudController hudController;

    public List<GameObject> pipesList;
    [HideInInspector] public List<Vector2> pipesInitialPositionList;

    public float playerPipeDistance;
    public float spawnPipeDistance;

    void Start()
    {
        pipesInitialPositionList.Add(pipesList[0].transform.position);
        pipesInitialPositionList.Add(pipesList[1].transform.position);
        pipesInitialPositionList.Add(pipesList[2].transform.position);
    }

    void Update()
    {
        if (player.transform.position.x - pipesList[0].transform.position.x > playerPipeDistance)
        {
            hudController.ScoreIncrease();
            pipesList[0].transform.position = new Vector2(pipesList[0].transform.position.x + spawnPipeDistance, pipesList[0].transform.position.y);
        }

        if (player.transform.position.x - pipesList[1].transform.position.x > playerPipeDistance)
        {
            hudController.ScoreIncrease();
            pipesList[1].transform.position = new Vector2(pipesList[1].transform.position.x + spawnPipeDistance, pipesList[1].transform.position.y);
        }

        if (player.transform.position.x - pipesList[2].transform.position.x > playerPipeDistance)
        {
            hudController.ScoreIncrease();
            pipesList[2].transform.position = new Vector2(pipesList[2].transform.position.x + spawnPipeDistance, pipesList[2].transform.position.y);
        }
    }
}
