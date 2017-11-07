using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    [SerializeField]
    private int NrOfLives = 2;
    [SerializeField]
    private Text RemainingLivesText;

    private int _currentLives;
    private PlayerMovement _playerMovement;

    private void Start() {
        _currentLives = NrOfLives;
        _playerMovement = GetComponent<PlayerMovement>();
        RemainingLivesText.text = "Lives: " + _currentLives.ToString("00");
    }

    private void OnCollisionEnter(Collision collision) {
        _currentLives--;
        RemainingLivesText.text = "Lives: " + _currentLives.ToString("00");
        if (_currentLives <= 0) {
            _playerMovement.enabled = false;
            this.enabled = false;
            //call endgame fuction from levelmanager
        }
    }

}
