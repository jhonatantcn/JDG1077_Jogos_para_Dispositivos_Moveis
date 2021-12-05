using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleCoroutine : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(MeuMetodo());
    }

    IEnumerator MeuMetodo()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            print("Teste de Corrotina");
        }
    }
}
