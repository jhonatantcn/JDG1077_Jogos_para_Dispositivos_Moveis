using UnityEngine;

public class FollowGyro : MonoBehaviour
{
    private Gyroscope gyro; // Variável do tipo Gyroscope

    private void Start()
    {
        EnableGyro();
    }

    // Ativa o giroscópio
    public void EnableGyro()
    {
        // SystemInfo: Sistema de acesso a informação de hardware
        // supportsGyroscope: Verifica se existe um giroscópio disponível no dispositivo.
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true; // Ativa o giroscópio
        }
        else
        {
            print("Este dispositivo não possui giroscópio");
        }
    }

    private void Update()
    {
        if (gyro.enabled)
        {
            // Opção 01 - (Opção recomendada)
            // Gira o objeto para coincidir com a orientação do dispositivo no espaço
            // (Usa Quaternion)
            // transform.rotation = gyro.attitude;


            // Opção 02
            // Gira o objeto de acordo com a velocidade de rotação em torno de
            // cada um dos três eixos (Euler) em radianos por segundo.
            // A velocidade de rotação é resetada assim que paro de rotacionar o dispositivo
            // transform.eulerAngles = -gyro.rotationRateUnbiased * 10;


            // Opção 03
            // Gira o objeto de acordo com a velocidade de rotação em torno de
            // cada um dos três eixos (Euler) em radianos por segundo.
            // O transform.eulerAngles sempre recebe a soma da velocidade de rotação
            // evitando que o objeto volte a posição inicial
            float xRotation = -gyro.rotationRateUnbiased.x;
            float yRotation = -gyro.rotationRateUnbiased.y;
            float zRotation = gyro.rotationRateUnbiased.z;

            transform.eulerAngles += new Vector3(xRotation, yRotation, zRotation);
        }
    }
}