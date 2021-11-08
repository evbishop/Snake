using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    Snake snake;
    Transform tailTarget;

    void Start()
    {
        snake = FindObjectOfType<Snake>();
        var tails = snake.Tails;

        tailTarget = tails[tails.Count - 1].transform;
        tails.Add(gameObject);
    }

    void Update()
    {
        transform.LookAt(tailTarget);
        transform.position = Vector3.Lerp(
            transform.position,
            tailTarget.position,
            snake.Speed * Time.deltaTime * 3f);
    }
}
