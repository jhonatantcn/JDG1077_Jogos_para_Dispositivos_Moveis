using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaforoCoroutine : MonoBehaviour
{
    [SerializeField] private SpriteRenderer CircleGreen;
    [SerializeField] private SpriteRenderer CircleYellow;
    [SerializeField] private SpriteRenderer CircleRed;

    [SerializeField] private Color OnGreen;
    [SerializeField] private Color OnYellow;
    [SerializeField] private Color OnRed;

    private Color OffGreen;
    private Color OffYellow;
    private Color OffRed;

    void Start()
    {
        OffGreen = CircleGreen.color;
        OffYellow = CircleYellow.color;
        OffRed = CircleRed.color;

        StartCoroutine(MeuMetodo());
    }

    IEnumerator MeuMetodo()
    {
        while (true)
        {
            CircleGreen.color = OnGreen;
            CircleYellow.color = OffYellow;
            CircleRed.color = OffRed;
            yield return new WaitForSeconds(3f);

            CircleGreen.color = OffGreen;
            CircleYellow.color = OnYellow;
            CircleRed.color = OffRed;
            yield return new WaitForSeconds(2f);

            CircleGreen.color = OffGreen;
            CircleYellow.color = OffYellow;
            CircleRed.color = OnRed;
            yield return new WaitForSeconds(5f);
        }
    }
}
