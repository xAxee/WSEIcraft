using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class WaypointFollower2 : MonoBehaviour
{

    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 1;

    [SerializeField] float speed = 1f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        }
    }
}
