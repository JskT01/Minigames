using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public ObjectPool obstaclePool; // Referencia al pool de obstáculos
    public float initialSpawnInterval = 2f; // Tiempo inicial entre cada obstáculo
    public float initialObstacleSpeed = 5f; // Velocidad inicial de los obstáculos
    public float difficultyIncreaseRate = 0.05f; // Aceleración del intervalo
    public float speedIncreaseRate = 0.1f; // Aceleración de la velocidad

    private float spawnInterval; // Intervalo actual de generación
    private float obstacleSpeed; // Velocidad actual de los obstáculos
    private float timeElapsed; // Tiempo transcurrido en el juego

    void Start()
    {
        
        spawnInterval = initialSpawnInterval;
        obstacleSpeed = initialObstacleSpeed;
        timeElapsed = 0f;
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            // Obtener un obstáculo aleatorio del pool
            GameObject obstacle = obstaclePool.GetPooledObject();
            if (obstacle != null)
            {
                float randomX = Random.Range(-8f, 8f);
                float randomRotation = Random.Range(-15f, 180f);
                float randomScale= Random.Range(0.15f, 0.25f);
                obstacle.transform.position = new Vector3(randomX, 6f, 0); // Fuera de la pantalla
                obstacle.transform.localEulerAngles = new Vector3(0f, 0f, randomRotation);
                obstacle.SetActive(true); // Activar el obstáculo
                obstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstacleSpeed); // Aplicar velocidad
            }

            // Esperar antes de generar el siguiente obstáculo
            yield return new WaitForSeconds(spawnInterval);

            // Aumentar la dificultad con el tiempo
            timeElapsed += spawnInterval;

            // Incrementar la frecuencia de los obstáculos (disminuyendo el intervalo)
            spawnInterval = Mathf.Max(0.5f, initialSpawnInterval - timeElapsed * difficultyIncreaseRate);

            // Incrementar la velocidad de los obstáculos
            obstacleSpeed = initialObstacleSpeed + timeElapsed * speedIncreaseRate;
        }
    }
}
