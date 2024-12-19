using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // Encontrar el ScoreManager en la escena
        soundManager = FindObjectOfType<SoundManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            soundManager.GrabItem();
            scoreManager.IncreaseScore(5);
            // Desactivar al jugador cuando colisiona
            collision.gameObject.SetActive(false);
            
        }
    }
}
