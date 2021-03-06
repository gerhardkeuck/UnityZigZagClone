using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Transform rayStart;

    private Rigidbody rb;
    private bool isWalkingRight = true;
    private Animator anim;
    private GameManager gameManager;

    private static readonly int IsFalling = Animator.StringToHash("isFalling");
    private static readonly int IsGameRunning = Animator.StringToHash("isGameStarted");

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (!gameManager.isGameStarted)
        {
            return;
        }
        else
        {
            anim.SetTrigger(IsGameRunning);
        }

        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    private void Update()
    {
        if (!gameManager.isGameStarted)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchDirection();
        }

        RaycastHit hit;
        if (!Physics.Raycast(rayStart.position, Vector3.down, out hit, 10f))
        {
            anim.SetTrigger(IsFalling);
        }

        if (transform.position.y < -2)
        {
            gameManager.EndGame();
        }
    }

    private void SwitchDirection()
    {
        isWalkingRight = !isWalkingRight;

        if (isWalkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }
}