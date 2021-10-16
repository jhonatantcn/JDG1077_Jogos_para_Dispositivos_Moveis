using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInZoomOut : MonoBehaviour
{
	public Camera mainCamera; // C�mera do jogo

	float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;
	// espa�o entre toques anteriores, espa�o entre toques atuais, modificador do tamanho da c�mera

	Vector2 firstTouchPrevPos, secondTouchPrevPos; // Posi��es anteriores de toque

	public float zoomModifierSpeed = 0.1f; // velocidade de zoom

	void Update()
	{
		if (Input.touchCount == 2) // Se existem dois toques na tela
		{
			Touch firstTouch = Input.GetTouch(0); // captura o primeiro toque
			Touch secondTouch = Input.GetTouch(1); // captura o segundo toque

			firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
			// Calcula a posi��o anterior do primeiro toque

			secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;
			// Calcula a posi��o anterior do segundo toque

			touchesPrevPosDifference = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
			// Calcula o espa�o entre os toques anteriores

			touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;
			// Calcula o espa�o entre os toques atuais

			zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomModifierSpeed;
			// Recebe o deslocamento progressivo entre os toques atuais * a velocidade de zoom
			// Quanto maior a dist�ncia de deslocamento, maior ser� o modificador de zoom

			if (touchesPrevPosDifference > touchesCurPosDifference) // Se o espa�o anterior era maior
				mainCamera.orthographicSize += zoomModifier; // Aumenta o tamanho da c�mera (ZoomIn)
			if (touchesPrevPosDifference < touchesCurPosDifference) // Se o espa�o anterior era menor
				mainCamera.orthographicSize -= zoomModifier; // Diminui o tamanho da c�mera (ZoomOut)
		}

		mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, 2f, 10f);
		// Mathf.Clamp d� limtes para o tamanho da c�mera, m�nimo 2 e m�ximo 10 (zoom m�nimo e zoom m�ximo)
	}
}