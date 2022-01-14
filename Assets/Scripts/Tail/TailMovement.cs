using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TailMovement : NetworkBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] TailNetwork tail;

    void Start()
    {
        transform.position = tail.Target.transform.position;
    }

    void Update()
    {
        agent.speed = tail.Owner.Speed;
        agent.SetDestination(tail.Target.transform.position);
    }
}
