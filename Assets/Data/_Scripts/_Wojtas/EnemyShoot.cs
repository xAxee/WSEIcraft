using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(5);
        StartCoroutine(Shoot());
    }
}
