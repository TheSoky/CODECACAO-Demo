using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform Player;
    [SerializeField]
    private Vector3 PositionOffset;

    private Transform _transform;

    private void Awake() {
        _transform = transform;
    }

    private void LateUpdate() {
        _transform.position = Player.position - PositionOffset;
    }

}
