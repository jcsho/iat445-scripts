using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObject : MonoBehaviour
{
    private Vector3 projectileDirection;
    private float projectileSpeed = 1f;
    private float timeAlive = 8;

    private void Start()
    {
        //StartCoroutine("DestroyOnTimer");
        Destroy(gameObject, timeAlive);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(projectileDirection.normalized * projectileSpeed * Time.deltaTime, Space.Self);
    }

    public void SetVelocity(float speed, Vector3 direction)
    {
        projectileSpeed = speed;
        projectileDirection = direction;
    }

    public void SetDestroyTimer(float amount)
    {
        timeAlive = amount;
    }

    IEnumerator DestroyOnTimer()
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(this);
    }
}
