using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isWalkingRight = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
    }

    private void SwitchDirection()
    {
        isWalkingRight = !isWalkingRight;

        if (isWalkingRight)
        {
            transform.rotation = Quaternion.Euler(0,45,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0,-45,0);
        }
    }
}