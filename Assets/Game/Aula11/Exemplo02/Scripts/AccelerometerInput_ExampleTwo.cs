using UnityEngine;
using UnityEngine.UI;

public class AccelerometerInput_ExampleTwo : MonoBehaviour
{
    public float speed = 200f;

    private bool supports;

    public Vector3 accelerometerValue; // Valor do aceler�metro
    public Vector3 accelerometerSmoothedValue; // Valor suavizado do aceler�metro 

    void Start()
    {
        accelerometerSmoothedValue = Vector3.zero;

        supports = SupportsAccelerometer();
    }

    public bool SupportsAccelerometer()
    {
        if (SystemInfo.supportsAccelerometer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {
        if (supports)
        {
            accelerometerValue = Input.acceleration;

            // Suaviza��o da transi��o entre acelera��es (interpola��o)
            accelerometerSmoothedValue = Vector3.Lerp(accelerometerSmoothedValue, accelerometerValue, Time.deltaTime); // Time.deltaTime: tempo de carregamento de um frame a outro, cerca de 0.01 (por�m varia)

            // Aplica rota��o em z de acordo com a acelera��o em x
            transform.eulerAngles = new Vector3(0, 0, -accelerometerSmoothedValue.x * speed);
        }
    }
}
