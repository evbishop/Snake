using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] TMP_Text winnerNameText;

    void Start()
    {
        GameOverHandler.ClientOnGameOver += ClientHandleGameOver;
    }

    void OnDestroy()
    {
        GameOverHandler.ClientOnGameOver -= ClientHandleGameOver;
    }

    void ClientHandleGameOver(string winner)
    {
        canvas.SetActive(true);
        winnerNameText.text = $"{winner} победил!";
    }
}
