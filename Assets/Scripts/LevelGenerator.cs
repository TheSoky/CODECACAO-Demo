using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour {

    [SerializeField]
    private int NrOfEmptyTerrains = 5;
    [SerializeField]
    private int NrOfTerrainsActive = 15;
    [SerializeField]
    private GameObject BaseTerrain;
    [SerializeField]
    private int NrOfTerrainsForGravityChange = 20;
    [SerializeField]
    private List<GameObject> Obstacles = new List<GameObject>();

    [Header("UI Variables")]
    [SerializeField]
    private RectTransform GravityArrow;

    [Header("Read-only:")]
    [SerializeField]
    private Vector3 _currentGravity;

    private Vector3 _nextAttachLocation;
    private Transform _transform;
    private int _countToChange = 0;

    private static LevelGenerator instance = null;
    public static LevelGenerator LG {
        get {
            return instance;
        }
    }

    private void Awake() {
        if(instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }

        _currentGravity = Physics.gravity;
        _transform = transform;
        _nextAttachLocation = _transform.position;
        GravityArrow.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);

    }

    private void Start() {
        for (int i = 0; i < NrOfEmptyTerrains; i++) {
            SpawnEmptyTerrain();
        }
        for (int i = NrOfEmptyTerrains; i < NrOfTerrainsActive; i++) {
            SpawnNewTerrain();
        }
    }

    public void SpawnNewTerrain() {
        if (_countToChange >= NrOfTerrainsForGravityChange) {
            int gravityIndex = Random.Range(0, 4);
            switch (gravityIndex) {
                case 0:
                    _currentGravity = new Vector3(0.0f, -9.81f);
                    Physics.gravity = _currentGravity;
                    GravityArrow.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
                    break;
                case 1:
                    _currentGravity = new Vector3(0.0f, 9.81f);
                    Physics.gravity = _currentGravity;
                    GravityArrow.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
                    break;
                case 2:
                    _currentGravity = new Vector3(-9.81f, 0.0f);
                    Physics.gravity = _currentGravity;
                    GravityArrow.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
                    break;
                case 3:
                    _currentGravity = new Vector3(9.81f, 0.0f);
                    Physics.gravity = _currentGravity;
                    GravityArrow.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    break;
                default:
                    break;
            }


            _countToChange = 0;
        }
        GameObject terrainClone = Instantiate(BaseTerrain, _nextAttachLocation, Quaternion.identity);
        terrainClone.transform.SetParent(_transform);

        GameObject obstacleClone = Instantiate(Obstacles[Random.Range(0, Obstacles.Count)], _nextAttachLocation, Quaternion.identity);
        obstacleClone.transform.SetParent(terrainClone.transform);

        BaseTerrain baseTerrainClone = terrainClone.GetComponent<BaseTerrain>();
        _nextAttachLocation = baseTerrainClone.GetAttachPosition();
        _countToChange++;
    }

    public void SpawnEmptyTerrain() {
        GameObject terrainClone = Instantiate(BaseTerrain, _nextAttachLocation, Quaternion.identity);
        terrainClone.transform.SetParent(_transform);
        BaseTerrain baseTerrainClone = terrainClone.GetComponent<BaseTerrain>();
        _nextAttachLocation = baseTerrainClone.GetAttachPosition();
        _countToChange++;
    }

}
