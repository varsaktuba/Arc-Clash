using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector3 SpawnPos;
    public GameObject spawnObject;
    public Transform spawnPlaceHolder;
    private float newSpawnDuration = 1.0f;

    #region Singleton
    public static Spawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = spawnPlaceHolder.position;
        SpawnNewObject();
    }
    void SpawnNewObject()
    {
        Instantiate(spawnObject, SpawnPos, Quaternion.identity);
    }

    public void NewSpawnRequest()
    {
        Invoke(methodName: "SpawnNewObject", newSpawnDuration);
    }
}
