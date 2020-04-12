using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowerSolo : MonoBehaviour
{
	public GameObject bullet;
	public LayerMask whatIsEnemy;
	public float startAttackTime, radius, bulletDamage = 10;
	public Transform attackPosition;
	public int[] priceUp;
	public int lvl = 0;

	private bool shoot;
	private GameObject bullet2;
	[HideInInspector] public GameObject enemyTarget;


	private float timeBtwEnemyAttack;

	private void Start()
	{
		attackPosition = GetComponent<Transform>();
	}


	private void FixedUpdate()
	{
		Shoot();
		if (shoot && bullet2 != null)
			enemyTarget = bullet2.GetComponent<BulletScriptSolo>().lookEnemy;
	}

	void Shoot()
	{
		shoot = Physics2D.OverlapCircle(attackPosition.position, radius, whatIsEnemy);
		if (shoot && timeBtwEnemyAttack <= 0f)
		{
			bullet2 = Instantiate(bullet, attackPosition.position, attackPosition.rotation);
			bullet2.GetComponent<BulletScriptSolo>().bulletDamage = bulletDamage;
			timeBtwEnemyAttack = startAttackTime;
		}
		timeBtwEnemyAttack -= Time.fixedDeltaTime;
	}


	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(attackPosition.position, radius);
	}
}
