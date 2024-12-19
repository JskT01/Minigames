using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform board;
    public List<Sprite> cardImages;
    public TextMeshProUGUI timerText;

    private List<Card> cards = new List<Card>();
    private Card firstCard, secondCard;
    private float timeLeft=180f;
    private int matchesNeeded;
    private SoundManager2 soundManager;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager2>();
        StartLevel();
    }

    void StartLevel()
    {
        ClearBoard();
        
        SetTimer();
        CreateCards();
    }

    void SetTimer()
    {
        
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Tiempo: " + Mathf.Ceil(timeLeft).ToString();
            yield return null;
        }

        GameOver();
    }

    void CreateCards()
    {
        int numPairs = 12; // Aumenta el número de pares con cada nivel
        matchesNeeded = numPairs;

        List<int> ids = new List<int>();
        for (int i = 0; i < numPairs; i++)
        {
            ids.Add(i);
            ids.Add(i);
        }

        ids.Shuffle();

        foreach (int id in ids)
        {
            GameObject newCard = Instantiate(cardPrefab, board);
            Card card = newCard.GetComponent<Card>();
            card.Initialize(id, cardImages[id], this);
            card.Hide();
            cards.Add(card);
        }
    }

    public void OnCardClicked(Card clickedCard)
    {
        Debug.Log("ENTER");
        if (firstCard == null)
        {
            firstCard = clickedCard;
            firstCard.Reveal();
            
        }
        else if (secondCard == null && clickedCard != firstCard)
        {
            secondCard = clickedCard;
            secondCard.Reveal();

            if (firstCard.id == secondCard.id)
            {
                matchesNeeded--;
                soundManager.Match();
                CheckWin();
                firstCard = secondCard = null;
            }
            else
            {
                soundManager.Error();
                StartCoroutine(HideCards());
            }
        }
    }

    IEnumerator HideCards()
    {
        yield return new WaitForSeconds(1f);
        firstCard.Hide();
        secondCard.Hide();
        firstCard = secondCard = null;
    }

    void CheckWin()
    {
        if (matchesNeeded == 0)
        {
            soundManager.Win();
            
        }
    }

    void GameOver()
    {
        StopAllCoroutines();
        timerText.text = "Tiempo agotado";
        // Mostrar alguna pantalla de Game Over o reiniciar el juego
    }

    void ClearBoard()
    {
        foreach (Card card in cards)
        {
            Destroy(card.gameObject);
        }
        cards.Clear();
        firstCard = secondCard = null;
    }

}
