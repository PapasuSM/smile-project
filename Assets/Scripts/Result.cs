using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour {

    private int highScore;
    public Text resultTime;
    public Text bestTime;
    public GameObject resultUI;

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("HighScore")){

            highScore = PlayerPrefs.GetInt("HighScore");
        }else{

            highScore = 999;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GoalScript.goal){

            resultUI.SetActive(true);
            int result = Mathf.FloorToInt(TimerScript.time - 5);
            resultTime.text = "今のタイム:" + result;
            bestTime.text = "最短タイム:" + highScore;

            if(highScore > result){

                PlayerPrefs.SetInt("HighScore", result);
            }

        }
		
	}
}
