using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject coinObj;
    [SerializeField] int enemyScoreVal = 10;
    [SerializeField] NavMeshAgent agent;
    Transform playerTransform;

    private void Start()
    {
        playerTransform = PlayerController.Instance.gameObject.transform;
    }
    private void Update()
    {
        agent.SetDestination(playerTransform.position);
    }
    public void EnemyKilled()
    {
        UIManager.Instance.HandleGameUIUpdate?.Invoke();
        PlayerController.Instance.playerData.UpdateScore(enemyScoreVal);
        Instantiate(coinObj,transform.position, coinObj.transform.rotation);
        gameObject.SetActive(false);
    }
}
