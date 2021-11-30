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
        var tailInstance = Instantiate(
            tailPrefab, 
            Tails.Count == 0 ?
                transform.position : 
                Tails[Tails.Count - 1].transform.position, 
            Quaternion.identity);
        NetworkServer.Spawn(tailInstance);
        Tails.Add(tailInstance);
    }
}
