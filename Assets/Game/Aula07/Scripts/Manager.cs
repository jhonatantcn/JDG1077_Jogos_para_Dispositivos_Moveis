using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance = null; // declara e inicializa uma classe Manager estática pública como nula. Isso será usado em breve.
    public int HP = 3; // Variável de ponto de vida que usaremos em outro objeto do jogo.

    private void Awake() // Awake é chamado uma única vez, antes do método Start
    {
        if (instance == null) // Determina se nossa instância é nula
            instance = this; // atribui esta instância da classe a instance 
        else if (instance != this) // Determina se nossa instância já está atribuída
            Destroy(gameObject); // Como já temos um Manager atribuído em outro lugar, não precisamos de uma duplicata.
    }

}
