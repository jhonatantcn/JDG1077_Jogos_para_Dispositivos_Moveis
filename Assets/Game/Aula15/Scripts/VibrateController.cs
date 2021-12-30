using UnityEngine;
public class VibrateController : MonoBehaviour
{
    private Touch t;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                Handheld.Vibrate();
            }
        }
    }
}