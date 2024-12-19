using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 1000; // Puntuación inicial
    public TextMeshProUGUI scoreText; // Texto para mostrar la puntuación en la UI
    public GameObject gameOverPanel; // Panel que se mostrará cuando el juego termine
    private SoundManager soundManager;
    public TextMeshProUGUI highScore; // Texto para mostrar el highscore
    public GameObject gameOverCanvaS;

    private int localHighScore;

    void Start()
    {
        UpdateScoreText(); // Inicializar el texto con la puntuación
        gameOverPanel.SetActive(false); // Ocultar el panel de fin del juego al inicio
        soundManager = FindObjectOfType<SoundManager>();

        // Cargar el highscore local
        localHighScore = PlayerPrefs.GetInt("LocalHighScore", 0);
        UpdateHighScoreText();
    }

    public void DecreaseScore(int amount)
    {
        score -= amount;
        UpdateScoreText();

        if (score <= 0)
        {
            soundManager.GameOver();
            GameOver();
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
        CheckForNewLocalHighScore(); // Comprobar si se ha alcanzado un nuevo highscore local
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        // Mostrar el panel de Game Over y detener el tiempo
        gameOverPanel.SetActive(true);
        gameOverCanvaS.SetActive(true);
        Time.timeScale = 0f; // Pausar el juego
        Debug.Log("Juego terminado");

        // Almacenar el highscore global si el local es mayor
        CheckForNewGlobalHighScore();
    }

    public void RestartGame()
    {
        // Reiniciar el juego (puedes cambiar esto para ir a la escena principal)
        Time.timeScale = 1f; // Reanudar el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void CheckForNewLocalHighScore()
    {
        // Si la puntuación actual es mayor que el highscore local, actualizarlo
        if (score > localHighScore)
        {
            localHighScore = score;
            PlayerPrefs.SetInt("LocalHighScore", localHighScore); // Guardar el nuevo highscore local
            UpdateHighScoreText(); // Actualizar el texto del highscore
        }
    }

    void CheckForNewGlobalHighScore()
    {
        // Obtener el highscore global guardado
        int globalHighScore = PlayerPrefs.GetInt("GlobalHighScore", 0);

        // Si el highscore local es mayor que el global, actualizar el global
        if (localHighScore > globalHighScore)
        {
            PlayerPrefs.SetInt("GlobalHighScore", localHighScore); // Guardar el nuevo highscore global
        }
    }

    void UpdateHighScoreText()
    {
        highScore.text = "High Score: " + localHighScore;
    }
}
