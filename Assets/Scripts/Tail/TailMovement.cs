using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TailMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Tail tail;

    void Update()
    {
        if (!tail || !tail.Target || !tail.Owner) return;
        agent.speed = tail.Owner.Speed;
        agent.SetDestination(tail.Target.transform.position);
    }
}
