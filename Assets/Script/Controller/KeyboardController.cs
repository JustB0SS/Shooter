using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class KeyboardController : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private CharacterJump _jump;
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        _movement.Move(new Vector2(vertical,horizontal));

        if (Input.GetKey(KeyCode.Space))
        {
            _jump.JumpInput();
        }
        
    }
}
