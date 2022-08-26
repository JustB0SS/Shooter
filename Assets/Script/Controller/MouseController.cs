using UnityEngine;

namespace Script.Controller
{
    [RequireComponent(typeof(CharacterLook))]
    public class MouseController : MonoBehaviour
    {
        [SerializeField] private float _mouseSensitivity;
        [SerializeField] private CharacterLook _characterLook;

        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

            _characterLook.Look(mouseX, mouseY);
        }
    }
}