using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent(typeof(PlayerMover)))
        {
            CollectionCoin();
        }
    }

    public void CollectionCoin()
    {
        gameObject.SetActive(false);
    }
}
