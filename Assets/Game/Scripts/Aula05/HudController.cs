using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public Text score;

    void Start()
    {
        score.text = "0";
    }

    public void ScoreIncrease()
    {
        int sc = int.Parse(score.text);

        sc++;

        score.text = "" + sc;
    }

}
