using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleInvoke : MonoBehaviour
{
    void Start()
    {
        //Invoke("MeuMetodo", 3f);
        InvokeRepeating("MeuMetodo", 3f, 2f);
    }

    private void MeuMetodo()
    {
        print("Teste de Invoke");
    }
}
