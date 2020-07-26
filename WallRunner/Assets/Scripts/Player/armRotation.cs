using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armRotation : MonoBehaviour
{
    [SerializeField] private Transform PlayerArms;
    [SerializeField] private float PlayerArmsRotationVelocity = .5f;

    private void Update()
    {
        PlayerArms.Rotate(new Vector3(PlayerArmsRotationVelocity, 0, 0));
    }
}
