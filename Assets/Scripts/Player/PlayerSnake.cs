using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class PlayerSnake : NetworkBehaviour
{
    [SerializeField] TailSpawner tailSpawner;
    public static event Action<PlayerSnake> ServerOnPlayerSpawned;
    public static event Action<PlayerSnake> ServerOnPlayerDespawned;

    public override void OnStartServer()
    {
        ServerOnPlayerSpawned?.Invoke(this);
    }

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
        ServerOnPlayerDespawned?.Invoke(this);
        foreach (var tail in tailSpawner.Tails)
            NetworkServer.Destroy(tail);
        NetworkServer.Destroy(gameObject);
    }
}
