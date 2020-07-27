using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpSoeed;

    [SerializeField] private float inputDelay;

    [SerializeField] private float PlayerRotationVelocityDuringAJump;

    [SerializeField] private GameObject PlayerMesh;

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
        LeanTween.rotate(PlayerMesh, new Vector3(-90, PlayerMesh.transform.rotation.eulerAngles.y + 180, 0), 1/PlayerRotationVelocityDuringAJump);
        runState = runState == RunState.RunLeftWall ? RunState.RunRightWall : RunState.RunLeftWall;
        int dir = runState == RunState.RunLeftWall ? 1 : -1;
        //playerRb.isKinematic = false;
        playerRb.velocity = new Vector2(jumpSoeed * dir, 0);
        isJumpping = true;
    }
}
