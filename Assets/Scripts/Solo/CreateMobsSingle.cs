using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMobsSingle : MonoBehaviour
{
    public GameObject[] mobs;
    private Transform respownPoint;
    public int wave, maxWave = 30, money, life = 20, timerWave;
    public Text moneyText, waveText, textLife;
    private IEnumerator instMob;
    public float countSpawn;
    public int[] minCount, maxCount;

    private void Start()
    {
        respownPoint = GetComponent<Transform>();
        instMob = Instmobs();
        StartCoroutine(instMob);
        waveText.text = wave + " / " + maxWave;
    }

    private void FixedUpdate()
    {
        moneyText.text = "Gold " + money;
    }

    public IEnumerator Instmobs()
    {
        int rnd;
        for (wave = 0; wave < maxWave; wave++)
        { 
            yield return new WaitForSecondsRealtime(timerWave);
            for (int i = 0; i <= 5 + (wave * (Random.Range(1, 5) * countSpawn)); i++)
            {
                rnd = Random.Range(minCount[wave], maxCount[wave]);
                Instantiate(mobs[rnd], respownPoint.position, respownPoint.rotation);
                yield return new WaitForSecondsRealtime(Random.Range(0.2f, 1));
            }
            waveText.text = wave+1 + " / " + maxWave;
        }
    }

}
