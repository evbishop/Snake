using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNetworkManager : NetworkManager
{
    [SerializeField] GameObject foodSpawnerPrefab;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);
        if (numPlayers != 2) return;
        var foodSpawnerInstance = Instantiate(foodSpawnerPrefab);
        NetworkServer.Spawn(foodSpawnerInstance);
    }
}
