using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float kineticForce = 5000f;

    private void OnEnable()
    {
        Invoke(nameof(BackToPool), 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            var enemy = collision.gameObject.GetComponentInParent(typeof(Enemy)) as Enemy;
            //collision.gameObject.GetComponent<Enemy>().Die();
            enemy.Die();
            collision.gameObject.GetComponent<Rigidbody>().AddForce((gameObject.transform.position - collision.transform.position).normalized * kineticForce);
        }
    }

    private void BackToPool(){ GetComponent<PoolObject>().ReturnToPool (); }
}
