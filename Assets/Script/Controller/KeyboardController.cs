using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private CharacterJump _jump;

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movement.Move(new Vector3(vertical, 0, horizontal));

        if (Input.GetKey(KeyCode.Space))
        {
            _jump.JumpInput();
        }
        
    }
}
