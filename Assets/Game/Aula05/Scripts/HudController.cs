using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public Text points;

    private void Start()
    {
        points.text = "0";
    }

    public void ScoreIncrease()
    {
        int pt = int.Parse(points.text); // Conversao de string para int

        pt++; // Adiciona 1 ponto

        points.text = "" + pt; // Conversao de int para string
    }

    public void ScoreReset()
    {
        points.text = "0";
    }
}
