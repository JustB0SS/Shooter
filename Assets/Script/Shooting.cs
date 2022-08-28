using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float timeBetweenShooting, spread, range, timeBetweenShots;
    [SerializeField] private int bulletsPerTap;
    [SerializeField] private bool allowButtonHold;
    private int bulletsShot;

    private bool shooting, readyToShoot;

    [SerializeField] private Camera fpsCam;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask whatIsEnemy;
    private RaycastHit rayHit;

    [SerializeField] private GameObject muzzleFlash, bulletHoleGraphic;

    private void Awake()
    {
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (readyToShoot && shooting){
            bulletsShot = bulletsPerTap;
            StartCoroutine(Shoot());
        }
    }
    private IEnumerator Shoot()
    {
        readyToShoot = false;

        for (int i = 0; i < bulletsShot; i++)
        {
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

            if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range))
            {
                Debug.Log(rayHit.collider.name);
            }

            Instantiate(bulletHoleGraphic, rayHit.point,
                Quaternion.FromToRotation(transform.up, rayHit.normal) * Quaternion.Euler(0f, 180f, 0f));
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity, attackPoint);

            yield return new WaitForSeconds(timeBetweenShots);
        }

        Invoke("ResetShot", timeBetweenShooting);
        yield return null;
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
   
}
