using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] FixedJoystick _joystick;
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    private void FixedUpdate() 
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * moveSpeed);
        if(_joystick.Horizontal !=0 || _joystick.Vertical != 0) transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
    }
}
