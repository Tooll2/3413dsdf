using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTower : MonoBehaviour
{
    private GameObject enemiesToDamage;
    private Transform mytransform;
    public ShootTowerSolo shootTower;

    public float radius;

    public LayerMask whatIsEnemy;

    private bool find;

    void Start()
    {
        mytransform = GetComponent<Transform>();
    }

    void LateUpdate()
    { 
        find = Physics2D.OverlapCircle(mytransform.position, radius, whatIsEnemy);
        if (find)
        {
            enemiesToDamage = shootTower.enemyTarget;
            if (enemiesToDamage != null)
            {
                Vector3 dir = transform.position - enemiesToDamage.transform.position;
                Rotate(dir);
            }
        }
    }

    private void Rotate(Vector3 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * 800);
    }

}
