using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMove._hasCoin = true;
            Debug.Log("Coin Collected");
            Destroy(gameObject, 0.5f);
        }
    }
}
