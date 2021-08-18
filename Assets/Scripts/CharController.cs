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
    private static readonly int IsFalling = Animator.StringToHash("isFalling");

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchDirection();
        }

        RaycastHit hit;
        if (!Physics.Raycast(rayStart.position, Vector3.down, out hit, 10f))
        {
            anim.SetTrigger(IsFalling);
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