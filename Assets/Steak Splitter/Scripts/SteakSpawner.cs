using UnityEngine;

public class SteakSpawner : MonoBehaviour
{
    public GameObject FrozenSteakPrefab; // Assign your prefab here in the Inspector
    public Transform FrozenSteakSpawnPoint;     // Assign your empty GameObject here in the Inspector

    void Start()
    {
        // Instantiate the prefab at the position and rotation of the spawnPoint
        if (FrozenSteakPrefab != null && FrozenSteakSpawnPoint != null)
        {
            GameObject spawnedObject = Instantiate(FrozenSteakPrefab, FrozenSteakSpawnPoint.position, FrozenSteakSpawnPoint.rotation);
            // Optionally, make the spawned object a child of the spawnPoint
            // spawnedObject.transform.parent = spawnPoint; 
        }
        else
        {
            Debug.LogError("Prefab or Spawn Point not assigned in PrefabSpawner script!");
        }
    }

    public void SpawnSteak()
    {
        if (FrozenSteakPrefab != null && FrozenSteakSpawnPoint != null)
        {
            GameObject spawnedObject = Instantiate(FrozenSteakPrefab, FrozenSteakSpawnPoint.position, FrozenSteakSpawnPoint.rotation);
            // Optionally, make the spawned object a child of the spawnPoint
            // spawnedObject.transform.parent = spawnPoint; 
        }
        else
        {
            Debug.LogError("Prefab or Spawn Point not assigned in PrefabSpawner script!");
        }
    }
}