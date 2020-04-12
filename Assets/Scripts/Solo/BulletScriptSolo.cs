using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScriptSolo : MonoBehaviour
{
    public float speed, bulletDamage;
    public float radius;
    private Collider2D enemiesToDamage = null;

    public GameObject lookEnemy;



    public LayerMask whatIsEnemy;

    private Transform mytransform;
    private Transform target = null;
    private Rigidbody2D rb;
    private Vector3 dir;


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
            lookEnemy = null;
            Destroy(gameObject);
        }
        else
        {
            lookEnemy = enemiesToDamage.gameObject;
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
            if (bulletDamage == 250 || bulletDamage == 550 || bulletDamage == 950)
            {
                if (Random.Range(0, 101) < 20)
                    bulletDamage *= 2;
            }
            EnemyDataSolo enemy = other.GetComponent<EnemyDataSolo>();
            enemy.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
