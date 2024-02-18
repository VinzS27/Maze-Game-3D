using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private Rigidbody Enemyrb;
    private GameObject player;

    void Start()
    {
        Enemyrb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position -
            transform.position).normalized;
        Enemyrb.AddForce(lookDirection * speed);

        if(transform.position.y < -1)
        {
            Destroy(gameObject);
        }
    }
}
