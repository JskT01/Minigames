using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;   // Prefab de la plataforma
    public float spawnInterval = 2f;    // Intervalo de aparici�n
    private float lastSpawnTime;
    private float platformWidth = 5f;   // Ancho de cada plataforma
    private float nextYPosition = 0f;  // Posici�n Y inicial para la primera plataforma
    public float yIncrement = 2f;       // Incremento de la posici�n Y para cada plataforma
    private bool isFirstPlatform = true; // Verificador para la primera plataforma

    private void Start()
    {
        SpawnPlatforms();
    }

    private void Update()
    {
        if (Time.time - lastSpawnTime > spawnInterval)
        {
            SpawnPlatforms();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnPlatforms()
    {
        for (int i = 0; i < 10; i++) // Genera un lote de 10 plataformas
        {
            Vector3 spawnPosition;

            if (isFirstPlatform)
            {
                // Posici�n fija para la primera plataforma
                spawnPosition = new Vector3(-5f, -3f, 0f);
                isFirstPlatform = false; // Ya se ha generado la primera plataforma
            }
            else
            {
                // Posici�n aleatoria en X y progresiva en Y para plataformas posteriores
                float xPos = Random.Range(-platformWidth, platformWidth);
                spawnPosition = new Vector3(xPos, nextYPosition, 0);
                nextYPosition += yIncrement; // Aumenta la posici�n en Y
            }

            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
