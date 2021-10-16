using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private Touch t;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                Manager.instance.HP--; // se o usuário tocar, diminua o HP em 1
            }
            
            if (Manager.instance.HP == 0)
                Destroy(gameObject); // se HP = 0, destrua o objeto ao qual este script está anexado
        }
    }
}
