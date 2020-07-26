using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody objRb;

    private void Start()
    {
        objRb.velocity = Vector3.down * speed;
    }

}
