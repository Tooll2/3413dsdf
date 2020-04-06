using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{



    public float speed, bulletDamage;
    public float radius;

    public LayerMask whatIsEnemy;

    private Transform mytransform;
    private Transform target = null;
    private Rigidbody2D rb;
    private Vector3 dir;
    private Collider2D enemiesToDamage = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mytransform = GetComponent<Transform>();
        enemiesToDamage = Physics2D.OverlapCircle(mytransform.position, radius, whatIsEnemy);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
       
        if (enemiesToDamage == null)
        {
            Destroy(gameObject);
        }
        else
        {
            target = enemiesToDamage.GetComponent<Transform>();
            dir = target.position - mytransform.position;
            rb.velocity = dir.normalized * speed;
        }

        if (target == null)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyData enemy = other.GetComponent<EnemyData>();
            enemy.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
