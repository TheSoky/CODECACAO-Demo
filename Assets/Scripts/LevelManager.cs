using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private Transform Player;
    [SerializeField]
    private Text ScoreText;

    private void Update() {
        ScoreText.text = "Distance: " + Player.position.z.ToString("000.00");
    }

    //TODO function which defines endgame scenario

}
