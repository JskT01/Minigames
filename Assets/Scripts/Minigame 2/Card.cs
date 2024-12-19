using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int id;
    public Button button;
    public Image cardImage;
    private GameController gameController;

    private void Awake()
    {
        gameController= FindObjectOfType<GameController>();
    }
    public void Initialize(int id, Sprite image, GameController controller)
    {
        this.id = id;
        cardImage.sprite = image;
        gameController = controller;
        button.onClick.AddListener(OnCardClicked);
    }

    public void Reveal()
    {
        cardImage.enabled = true;
    }

    public void Hide()
    {
        cardImage.enabled = false;
    }

    private void OnCardClicked()
    {
        gameController.OnCardClicked(this);
    }

}
