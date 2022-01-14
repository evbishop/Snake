using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class TailSpawner : NetworkBehaviour
{
    [SerializeField] GameObject tailPrefab;
    public List<GameObject> Tails { get; } = new List<GameObject>();

    public override void OnStartServer()
    {
        Food.ServerOnFoodEaten += AddTail;
    }

    public override void OnStopServer()
    {
        Food.ServerOnFoodEaten -= AddTail;
    }

    void AddTail(GameObject playerWhoAte)
    {
        if (playerWhoAte != gameObject) return;
        var tailInstance = Instantiate(tailPrefab);
        NetworkServer.Spawn(tailInstance, connectionToClient);
    }
}
