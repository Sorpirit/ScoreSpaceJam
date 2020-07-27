using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fierRate;
    [SerializeField] private float inputDelay;
    [SerializeField] private Transform fierPoint;

    [SerializeField] private bool useE;

    [SerializeField] private float bulletSpeed;

    private float fierTimer;
    private float inputTimer;
    private PlayerJump playerJump;
    private KeyCode targetKey;

    private void Start()
    {
        playerJump = GetComponent<PlayerJump>();
        targetKey = useE ? KeyCode.E : KeyCode.Space;
    }

    private void Update()
    {
        if(fierTimer > 0)
            fierTimer -= Time.deltaTime;

        if (inputTimer > 0)
            inputTimer -= Time.deltaTime;

        if (Input.GetKeyDown(targetKey) && playerJump.IsJumping)
            inputTimer = inputDelay;

        if(inputTimer > 0 && playerJump.IsJumping  && fierTimer <= 0)
        {
            Fier();
            inputTimer = 0;
            fierTimer = fierRate;
        }
    }

    private void Fier()
    {
        GameObject bullet = Instantiate(bulletPrefab,fierPoint.position,fierPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * bulletSpeed;
    }
}
