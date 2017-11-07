using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour {

    public enum MovementDirection {
        Horizontal,
        Vertical,
        Circular
    }

    [SerializeField]
    private MovementDirection Direction = MovementDirection.Horizontal;

    [SerializeField]
    private float Amplitude = 5.0f;

    private float initializationTime;

    private void Start() {
        initializationTime = Time.timeSinceLevelLoad;
    }

    private void Update() {
        switch (Direction) {
            case MovementDirection.Horizontal:
                transform.Translate(Mathf.Cos(Time.timeSinceLevelLoad - initializationTime) * Vector3.right * Amplitude * Time.deltaTime);
                break;
            case MovementDirection.Vertical:
                transform.Translate(Mathf.Sin(Time.timeSinceLevelLoad - initializationTime) * Vector3.forward * Amplitude * Time.deltaTime);
                break;
            case MovementDirection.Circular:
                Vector3 direction = new Vector3();
                direction = Mathf.Cos(Time.timeSinceLevelLoad - initializationTime) * Vector3.right * Amplitude * Time.deltaTime
                         + Mathf.Sin(Time.timeSinceLevelLoad - initializationTime) * Vector3.forward * Amplitude * Time.deltaTime;
                transform.Translate(direction);
                break;
            default:
                break;
        }
    }

}
