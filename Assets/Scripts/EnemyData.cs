using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyData : MonoBehaviour
{
	[SerializeField][Header("%")] private float armor;
	public float maxhealth;
	public Image bar;
	[HideInInspector] public float health;
	public int bounty;
	CreateMobsSingle money;

	private void Start()
	{
		health = maxhealth;
		bar = GetComponentInChildren<Image>();
		bar.fillAmount = health / maxhealth;
	}

	public void TakeDamage(float damage)
	{
		health -= damage - (damage / 100 * armor);
		bar.fillAmount = health / maxhealth;
		if (health <= 0)
		{
			money = FindObjectOfType<CreateMobsSingle>();
			money.money += bounty + 4;
			Destroy(gameObject);
		}
	}






}
