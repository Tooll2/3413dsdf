using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyCreepsSolo : MonoBehaviour
{
    CreateMobsSingle mobsSingle;
    WPManager wPManager;

    private void Start()
    {
        wPManager = GetComponent<WPManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (wPManager.kyes[0] && wPManager.kyes[1])
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
