using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTerrain : MonoBehaviour {

    [SerializeField]
    private Transform AttachPosition;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            LevelGenerator.LG.SpawnNewTerrain();
            Destroy(gameObject);
        }
    }

    public Vector3 GetAttachPosition() {
        return AttachPosition.position;
    }

}
