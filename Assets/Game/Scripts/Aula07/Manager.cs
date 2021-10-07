using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance = null; // declara e inicializa uma classe Manager est�tica p�blica como nula. Isso ser� usado em breve.
    public int HP = 3; // Vari�vel de ponto de vida que usaremos em outro objeto do jogo.

    private void Awake() // Awake � chamado uma �nica vez, antes do m�todo Start
    {
        if (instance == null) // Determina se nossa inst�ncia � nula
            instance = this; // atribui esta inst�ncia da classe a instance 
        else if (instance != this) // Determina se nossa inst�ncia j� est� atribu�da
            Destroy(gameObject); // Como j� temos um Manager atribu�do em outro lugar, n�o precisamos de uma duplicata.
    }

}
