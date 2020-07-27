using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticelSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private Vector2 spawnRange;
    [SerializeField] private GameObject obsteclePrefab;


    private float spawnTimer;

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0)
        {
            Spawn();
            spawnTimer = spawnRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        Vector3 from = new Vector3(pos.x + spawnRange.x, pos.y, pos.z);
        Vector3 to = new Vector3(pos.x + spawnRange.y, pos.y, pos.z);
        Gizmos.DrawLine(from,to);
    }

    private void Spawn()
    {
        Vector3 pos = transform.position;
        Vector3 obstclPos = new Vector3(pos.x + Random.Range(spawnRange.x,spawnRange.y), pos.y, pos.z);
        GameObject obsticle = Instantiate(obsteclePrefab,obstclPos,Quaternion.identity);
    }

}
