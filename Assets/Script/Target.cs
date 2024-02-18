using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 10;
    private float maxSpeed = 11;
    private float maxTorque = 5;
    public float lifetime = 3.0f;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
        //targetRb.AddTorque(RandomTorque(),RandomTorque(), RandomTorque(),
          //  ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        Destroy(gameObject, lifetime);
    }

    Vector3 RandomForce()
    {
        return Vector3.back * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(3.345f,0.553f,6.69f);
    }
}
