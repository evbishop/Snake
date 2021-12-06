using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Tail : NetworkBehaviour
{
    [SyncVar]
    GameObject target;

    [SyncVar]
    Snake owner;

    public GameObject Target
    {
        get { return target; }
        private set { target = value; }
    }

    public Snake Owner
    {
        get { return owner; }
        private set { owner = value; }
    }

    public override void OnStartServer()
    {
        Owner = connectionToClient.identity.GetComponent<Snake>();
        var tails = Owner.GetComponent<TailSpawner>().Tails;
        Target = tails.Count == 0 ? Owner.gameObject : tails[tails.Count - 1];
    }
}
