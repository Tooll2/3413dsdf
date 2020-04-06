using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTower : MonoBehaviour
{
	public GameObject bullet;
	public LayerMask whatIsEnemy;
	public float startAttackTime, radius, bulletDamage, lvl = 1;
	public Transform attackPosition;

	private bool shoot;

	private float timeBtwEnemyAttack;

	private void Start()
	{
		attackPosition = GetComponent<Transform>();
	}


	private void Update()
	{
		Shoot();
	}

	void Shoot()
	{
		shoot = Physics2D.OverlapCircle(attackPosition.position, radius, whatIsEnemy);
		if (shoot && timeBtwEnemyAttack <= 0f)
		{
			GameObject bullet2 = Instantiate(bullet, attackPosition.position, attackPosition.rotation);
			bullet2.GetComponent<BulletScript>().bulletDamage = bulletDamage;
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
