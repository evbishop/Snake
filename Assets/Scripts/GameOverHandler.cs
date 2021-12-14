using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameOverHandler : NetworkBehaviour
{
    List<PlayerName> players = new List<PlayerName>();

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

    void ServerHandlePlayerSpawned(PlayerName player)
    {
        players.Add(player);
    }

    void ServerHandlePlayerDespawned(PlayerName player)
    {
        players.Remove(player);
        if (players.Count != 1) return;
        RpcGameOver(players[0].Name);
    }

    [ClientRpc]
    void RpcGameOver(string winner)
    {
        print(winner);
    }
}
