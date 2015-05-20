using UnityEngine;

public class Spawner: MonoBehaviour
{
    public GameObject prefab;
    public int spawnCount = 10;

    void Start()
    {
        for (var i = 0; i < spawnCount; i++) Instantiate(prefab);
    }
}
