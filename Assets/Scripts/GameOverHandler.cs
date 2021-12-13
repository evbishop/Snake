using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameOverHandler : NetworkBehaviour
{
    List<PlayerSnake> players = new List<PlayerSnake>();

    public override void OnStartServer()
    {
        PlayerSnake.ServerOnPlayerSpawned += ServerHandlePlayerSpawned;
        PlayerSnake.ServerOnPlayerDespawned += ServerHandlePlayerDespawned;
    }

    public override void OnStopServer()
    {
        PlayerSnake.ServerOnPlayerSpawned -= ServerHandlePlayerSpawned;
        PlayerSnake.ServerOnPlayerDespawned -= ServerHandlePlayerDespawned;
    }

    void ServerHandlePlayerSpawned(PlayerSnake player)
    {
        players.Add(player);
    }

    void ServerHandlePlayerDespawned(PlayerSnake player)
    {
        players.Remove(player);
        if (players.Count != 1) return;
    }
}
