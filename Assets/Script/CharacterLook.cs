using System;
using UnityEngine;

namespace Script
{
    public class CharacterLook : MonoBehaviour
    {
        [SerializeField] private Transform _playerBody;
        
        private float _xRotation;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Look(float mouseX, float mouseY)
        {
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90, 90);

            transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            _playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}