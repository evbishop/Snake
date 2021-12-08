using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerName : NetworkBehaviour
{
    [SerializeField] TMP_Text playerNameText;
    [SyncVar(hook = nameof(HandlePlayerNameUpdated))]
    string playerName;

    void HandlePlayerNameUpdated(string oldText, string newText)
    {
        playerNameText.text = newText;
    }

    public override void OnStartServer()
    {
        playerName = $"Player {connectionToClient.connectionId}";
    }
}
