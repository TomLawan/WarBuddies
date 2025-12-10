using UnityEngine;
using PurrNet;
public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Update()
    {
        // 0 = Left Click, 1 = Right Click, 2 = Middle Click
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }

    }

    void Shoot()

    {
        // I-spawn ang bala sa position at ROTATION ng firePoint
        // Dahil umiikot ang player, iikot din ang firePoint, kaya tama ang direction ng bala
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}