using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = -1200f;
    public float launchZ = -200f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(projectile, transform.position,
                                                      transform.rotation);

            bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                 (0, launchVelocity, launchZ));
        }
    }
}
