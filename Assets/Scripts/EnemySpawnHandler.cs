using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnHandler : MonoBehaviour
{
    public static EnemySpawnHandler Instance;

    private List<GameObject> pooledEnemies = new();
    private int poolCount = 30;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemyHolder;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        for(int i = 0; i < poolCount; i++)
        {
            GameObject obj = Instantiate(enemyPrefab, enemyHolder);
            obj.SetActive(false);
            pooledEnemies.Add(obj);
        }
    }

    public GameObject GetEnemy()
    {
        for(int i= 0; i< pooledEnemies.Count; i++)
        {
            if (!pooledEnemies[i].activeInHierarchy) return pooledEnemies[i];
        }
        return null;
    }
}
