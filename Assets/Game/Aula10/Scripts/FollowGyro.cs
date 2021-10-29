using UnityEngine;

public class FollowGyro : MonoBehaviour
{
    private Gyroscope gyro; // Vari�vel do tipo Gyroscope

    private void Start()
    {
        EnableGyro();
    }

    // Ativa o girosc�pio
    public void EnableGyro()
    {
        // SystemInfo: Sistema de acesso a informa��o de hardware
        // supportsGyroscope: Verifica se existe um girosc�pio dispon�vel no dispositivo.
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true; // Ativa o girosc�pio
        }
        else
        {
            print("Este dispositivo n�o possui girosc�pio");
        }
    }

    private void Update()
    {
        if (gyro.enabled)
        {
            // Op��o 01 - (Op��o recomendada)
            // Gira o objeto para coincidir com a orienta��o do dispositivo no espa�o
            // (Usa Quaternion)
            // transform.rotation = gyro.attitude;


            // Op��o 02
            // Gira o objeto de acordo com a velocidade de rota��o em torno de
            // cada um dos tr�s eixos (Euler) em radianos por segundo.
            // A velocidade de rota��o � resetada assim que paro de rotacionar o dispositivo
            // transform.eulerAngles = -gyro.rotationRateUnbiased * 10;


            // Op��o 03
            // Gira o objeto de acordo com a velocidade de rota��o em torno de
            // cada um dos tr�s eixos (Euler) em radianos por segundo.
            // O transform.eulerAngles sempre recebe a soma da velocidade de rota��o
            // evitando que o objeto volte a posi��o inicial
            float xRotation = -gyro.rotationRateUnbiased.x;
            float yRotation = -gyro.rotationRateUnbiased.y;
            float zRotation = gyro.rotationRateUnbiased.z;

            transform.eulerAngles += new Vector3(xRotation, yRotation, zRotation);
        }
    }
}