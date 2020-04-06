using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyEnemy : MonoBehaviour
{
    CreateMobsSingle mobsSingle;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Death"))
        {
            mobsSingle = FindObjectOfType<CreateMobsSingle>();
            mobsSingle.life--;
            mobsSingle.textLife.text = "Life " + mobsSingle.life;
            if (mobsSingle.life <= 0)
                Time.timeScale = 0;

            Destroy(gameObject);
        }
        if (other.CompareTag("Tower"))
        {
            Destroy(other.gameObject);
        }

    }
}
