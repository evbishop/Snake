using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class PlayerSnake : NetworkBehaviour
{
    [SerializeField] TailSpawner tailSpawner;

    [ServerCallback]
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out NetworkIdentity networkIdentity)
            && networkIdentity.connectionToClient == connectionToClient)
            return;
        switch (other.tag)
        {
            case "Border":
            case "Player":
            case "Tail":
                DestroySelf();
                break;
        }
    }

    void DestroySelf()
    {
        foreach (var tail in tailSpawner.Tails)
            NetworkServer.Destroy(tail);
        NetworkServer.Destroy(gameObject);
    }
}
