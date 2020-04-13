using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    [Tooltip("Object to be spawned")]
    public TrapObject SpawnObject = null;
    [Tooltip("Object speed")]
    public float ProjectileSpeed = 1.0f;

    [Space(5)]

    [Tooltip("Delay between Traps (in seconds)")]
    [Range(0, 100)]
    public float SpawnDelay = 0.5f;

    [Tooltip("Duration of Object in s")]
    [Range(0, 100)]
    public float ObjectLifeSpan = 8;

    // Start is called before the first frame update
    void Start()
    {
        // Uncomment this to use independently of Trigger Area
        //if (SpawnObject != null)
        //{
        //    StartCoroutine("SpawnObjects");
        //}
        //Debug.Log("Direction: " + transform.forward);
    }

    public IEnumerator SpawnObjects()
    {
        for (;;)
        {
            TrapObject ob = Instantiate(SpawnObject, transform.position, transform.rotation);
            ob.SetVelocity(ProjectileSpeed, transform.forward);
            ob.SetDestroyTimer(ObjectLifeSpan);

            // Debug.Log("Spawned object");

            yield return new WaitForSeconds(SpawnDelay);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 direction = transform.TransformDirection(transform.forward) * 3;
        float arrowHeadLength = 0.8f;
        float arrowHeadAngle = 25.0f;

        Gizmos.DrawRay(transform.position, direction);

        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Gizmos.DrawRay(transform.position + direction, right * arrowHeadLength);
        Gizmos.DrawRay(transform.position + direction, left * arrowHeadLength);

        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
