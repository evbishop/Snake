using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class SnakeMovement : NetworkBehaviour
{
    [SerializeField] float rotationSpeed = 180f, speedChange = 0.5f;

    [SerializeField]
    [SyncVar]
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

    [ClientCallback]
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
