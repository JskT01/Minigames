using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private ScoreManager scoreManager;
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // Encontrar el ScoreManager en la escena
    }

    void Update()
    {
        // Si el obstáculo sale de la pantalla, reducir puntos y desactivarlo
        if (transform.position.y < -6f && this.gameObject.activeSelf )
        {
            scoreManager.DecreaseScore(5);
            // Restar puntos específicos
            gameObject.SetActive(false); // Volver al pool
            
        }
    }
}
