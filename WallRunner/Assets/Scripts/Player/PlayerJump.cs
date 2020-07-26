using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpSoeed;

    [SerializeField] private float inputDelay;

    [SerializeField] private float PlayerRotationVelocityDuringAJump = 2;

    [SerializeField] private CameraRotation cameraRotation;

    [SerializeField] private Transform PlayerMesh;

    private Rigidbody playerRb;
    private RunState runState;
    private bool isJumpping;
    private float inputDelayTimer;

    public bool IsJumping => isJumpping;

    private enum RunState
    {
        RunRightWall,
        RunLeftWall
    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        runState = RunState.RunLeftWall;
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //Continue run
            isJumpping = false;
            playerRb.velocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
            //playerRb.isKinematic = true;
        }
    }

    private void Update()
    {
        if (inputDelayTimer > 0 && !isJumpping)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space))
            inputDelayTimer = inputDelay;

        if (inputDelayTimer > 0)
            inputDelayTimer -= Time.deltaTime;
    }

    private void Jump()
    {
        //PlayerMesh.
        runState = runState == RunState.RunLeftWall ? RunState.RunRightWall : RunState.RunLeftWall;
        int dir = runState == RunState.RunLeftWall ? 1 : -1;
        //playerRb.isKinematic = false;
        playerRb.velocity = new Vector2(jumpSoeed * dir, 0);
        isJumpping = true;
        cameraRotation.SwitchCameras();
    }
}
