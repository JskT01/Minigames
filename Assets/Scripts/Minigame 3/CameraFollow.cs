using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;          // Referencia al transform del jugador
    public Vector3 offset;            // Desplazamiento de la c�mara respecto al jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado de movimiento de la c�mara

    void LateUpdate()
    {
        // Calcula la posici�n deseada de la c�mara
        Vector3 desiredPosition = player.position + offset;

        // Interpola suavemente entre la posici�n actual y la deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
