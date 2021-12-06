using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using System;

public class Snake : NetworkBehaviour
{
    [SerializeField] float rotationSpeed = 180f, speedChange = 0.5f;
    [SerializeField] GameObject tailPrefab;

    [SerializeField] [SyncVar]
    float speed = 3f;
    public float Speed 
    {
        get { return speed; }
        private set { speed = value; }
    }

    public override void OnStartServer()
    {
        Food.ServerOnFoodEaten += ServerHandleFoodEaten;
    }

    public override void OnStopServer()
    {
        Food.ServerOnFoodEaten -= ServerHandleFoodEaten;
    }

    void ServerHandleFoodEaten(GameObject playerWhoAte)
    {
        if (gameObject == playerWhoAte)
            Speed += speedChange;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border")) SceneManager.LoadScene(0);
    }
}
