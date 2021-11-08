using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] int countdown = 3;

    void Start()
    {
        StartCoroutine(GameCountdown());
    }

    IEnumerator GameCountdown()
    {
        Time.timeScale = 0;
        while (countdown > 0)
        {
            yield return new WaitForSecondsRealtime(1f);
            countdown--;
            timerText.text = countdown.ToString();
        }
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
