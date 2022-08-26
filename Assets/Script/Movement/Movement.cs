using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _heightCharacter;
    [SerializeField] private float _inAirMovementMultiplier;
    
    private Vector3 _normal;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void Move(Vector3 direction)
    {
        Vector3 moveDirection = transform.forward * direction.x + transform.right * direction.z;
        
        var grounded = Physics.Raycast(transform.position, Vector3.down, _heightCharacter * 0.5f + 0.3f);
        
        if(grounded)
        {
            _rigidbody.AddForce(moveDirection.normalized * _speed * 10f, ForceMode.Force);
        }
        else
        {
            _rigidbody.AddForce(moveDirection.normalized * _speed * 10f * _inAirMovementMultiplier, ForceMode.Force);
        }
        
        Vector3 velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
        if (velocity.magnitude > _speed)
        {
            Vector3 limitedVel = velocity.normalized * _speed;
            _rigidbody.velocity = new Vector3(limitedVel.x, _rigidbody.velocity.y, limitedVel.z);
        }
    }
    
    
}
