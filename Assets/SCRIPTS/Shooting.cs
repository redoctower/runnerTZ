using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform startpos;
    [SerializeField] private float bulletspeed;
    Vector3 hitpoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && PlayerManager.isShooting)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                hitpoint = (hit.point - startpos.position).normalized;
                print("hitpoint");
            }
            else
            {
                hitpoint = ray.direction;
                print("direction");
            }
            InstantiateBullet(hitpoint);
        }
    }

    void InstantiateBullet(Vector3 end)
    {
        GameObject bul = PoolManager.GetObject(bullet.name, startpos.position, Quaternion.identity);
        bul.transform.position = startpos.position;
        var _rb = bul.GetComponent<Rigidbody>();
        _rb.velocity = Vector3.zero;
        _rb.AddForce(end * bulletspeed);
    }
}
