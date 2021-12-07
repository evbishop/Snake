using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TailMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] TailNetwork tail;

    void Update()
    {
        agent.speed = tail.Owner.Speed + 0.5f;
        agent.SetDestination(tail.Target.transform.position);
    }
}
