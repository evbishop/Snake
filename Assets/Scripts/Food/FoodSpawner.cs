using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : NetworkBehaviour
{
    [SerializeField] GameObject foodPrefab;
    [SerializeField] float xSize = 8f, zSize = 8f;

    public override void OnStartServer()
    {
        SpawnFood();
        Food.ServerOnFoodEaten += SpawnFood;
    }

    public override void OnStopServer()
    {
        Food.ServerOnFoodEaten -= SpawnFood;
    }

    [Server]
    void SpawnFood()
    {
        var pos = new Vector3(
            Random.Range(-xSize, xSize),
            foodPrefab.transform.position.y,
            Random.Range(-zSize, zSize));
        var foodInstance = Instantiate(foodPrefab, pos, foodPrefab.transform.rotation);
        NetworkServer.Spawn(foodInstance);
    }
}
