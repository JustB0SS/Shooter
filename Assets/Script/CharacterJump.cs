using System;
using UnityEngine;

namespace Script
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterJump : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private float _heightCharacter;
        [SerializeField] private float _groundedDrag = 5f;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpDelay;
        
        private bool _readyToJump = true;
        private bool _grounded;
        
        private void FixedUpdate()
        {
            _grounded = Physics.Raycast(transform.position, Vector3.down, _heightCharacter * 0.5f + 0.3f);
            _rigidbody.drag = _grounded ? _groundedDrag : 0;

        }

        public void JumpInput()
        {
            if (_readyToJump && _grounded)
            {
                _readyToJump = false;
                
                Jump();
                
                Invoke(nameof(ResetJump),_jumpDelay);
            }
        }
        
        private void Jump()
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
            
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        }

        private void ResetJump()
        {
            _readyToJump = true;
        }
    }
}