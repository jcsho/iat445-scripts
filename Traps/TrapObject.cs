using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObject : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 projectileDirection;
    private float projectileSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody>() == null)
        {
            Debug.LogError("Trap Object requires Rigidbody component");
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = projectileDirection.normalized * projectileSpeed;
        // Debug.Log("Velocity: " + rb.velocity);
        // Debug.Log("Direction: " + projectileDirection);
    }

    public void SetVelocity(float speed, Vector3 direction)
    {
        projectileSpeed = speed;
        projectileDirection = direction;
    }
}
