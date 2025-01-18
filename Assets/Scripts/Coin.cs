using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int CoinVal = 5; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.Instance.playerData.UpdateCoins(CoinVal);
            UIManager.Instance.HandleGameUIUpdate?.Invoke();
            Destroy(gameObject);
        }
    }
}
