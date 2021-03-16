using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CoinController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            GameManager.Instance.AddCoin();
            this.gameObject.SetActive(false);
        }
    }

}
