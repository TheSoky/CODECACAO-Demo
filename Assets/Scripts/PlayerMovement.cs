using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float StartingSpeed = 1000.0f;
    [SerializeField]
    private float Speed = 1.0f;
    [SerializeField]
    private float ForwardSpeedMultiplier = 1.0f;

    private Rigidbody _rigidbody;
    private float _verticalMovement;
    private float _horizonatlMovement;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(Vector3.forward * StartingSpeed);
    }

    private void Update() {
        _verticalMovement = Input.GetAxisRaw("Vertical");
        _horizonatlMovement = Input.GetAxisRaw("Horizontal");

        _rigidbody.AddForce(Vector3.forward * ForwardSpeedMultiplier * Time.deltaTime);
        _rigidbody.AddForce(Vector3.up * _verticalMovement * Speed * Time.deltaTime);
        _rigidbody.AddForce(Vector3.right * _horizonatlMovement * Speed * Time.deltaTime);

    }

}
