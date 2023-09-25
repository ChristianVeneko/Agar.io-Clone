using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public static Player Instance { get { return instance; } }

    public float scaleThreshold = 0.5f; // El umbral de escala en el que la cámara se alejará.

    private Camera mainCamera;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        mainCamera = Camera.main;
    }

    public void IncreaseSize(float size)
    {
        Transform playerTransform = gameObject.transform;
        // Aumentar la escala del jugador.
        playerTransform.localScale += new Vector3(size, size, 0f);

        // Calcular el tamaño del jugador en la vista de la cámara.
        float playerScaleInView = playerTransform.lossyScale.x / mainCamera.orthographicSize;

        Debug.Log(playerScaleInView);
        Debug.Log(scaleThreshold);
        // Comprobar si el jugador ocupa más del umbral de la pantalla.
        if (playerScaleInView > scaleThreshold)
        {
            Debug.Log(playerScaleInView);
            Debug.Log("Aumentar la vista de la cámara.");
            mainCamera.orthographicSize += 0.5f; // Puedes ajustar este valor según tu necesidad.
        }
    }
}
