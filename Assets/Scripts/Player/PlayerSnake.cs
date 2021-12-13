using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class PlayerSnake : NetworkBehaviour
{
    [SerializeField] TailSpawner tailSpawner;
    [SerializeField] PlayerName playerName;
    public static event Action<PlayerName> ServerOnPlayerSpawned;
    public static event Action<PlayerName> ServerOnPlayerDespawned;

    public override void OnStartServer()
    {
        ServerOnPlayerSpawned?.Invoke(playerName);
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
        ServerOnPlayerDespawned?.Invoke(playerName);
        foreach (var tail in tailSpawner.Tails)
            NetworkServer.Destroy(tail);
        NetworkServer.Destroy(gameObject);
    }
}
