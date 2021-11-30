using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class Food : NetworkBehaviour
{
    [SerializeField] GameObject particlePrefab;

    public static event Action<GameObject> ServerOnFoodEaten;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        ServerParticles();

        NetworkServer.Destroy(gameObject);
        ServerOnFoodEaten?.Invoke(other.gameObject);
    }

    [ServerCallback]
    void ServerParticles()
    {
        GameObject boom = Instantiate
                    (particlePrefab, transform.position, particlePrefab.transform.rotation);
        NetworkServer.Spawn(boom);
        StartCoroutine(DelayedDestroy(boom, 3f));
    }

    IEnumerator DelayedDestroy(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        NetworkServer.Destroy(obj);
    }
}
