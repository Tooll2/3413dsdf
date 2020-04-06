using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Money : MonoBehaviour
{
	public int money, income, timer = 25;
	public Text timerText, incomeText, moneyText;

	private void Awake()
	{
		StartCoroutine(TimerIncome());
	}

	private void Start()
	{
		income = 25;
		
	}
	private void FixedUpdate()
	{
		moneyText.text = "Gold " + money;
	}


	IEnumerator TimerIncome()
	{
		while (true)
		{
			timer--;
			timerText.text = "Income " + timer;
			if (timer <= 0)
			{
				money += income;
				timer = 25;
			}
			yield return new WaitForSeconds(1);
		}
	}
}
