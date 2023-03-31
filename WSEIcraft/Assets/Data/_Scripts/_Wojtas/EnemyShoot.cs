using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    float currentxPosition;
    float currentyPosition;
    void Start()
    {
        StartCoroutine(Shoot());
        currentxPosition = transform.position.x;
        currentyPosition = transform.position.y;
    }

    IEnumerator Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(5);
        StartCoroutine(Shoot());
    }
    bool ifGoingRight()
    {
        return currentxPosition < transform.position.x;
    }
}
