using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public static float time;
    // Use this for initialization
    void Start(){

        time = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if(GoalScript.goal == false){

            time = Time.time;
        }

        int t = Mathf.FloorToInt(time - 5);
        
        Text uiText = GetComponent<Text>();

        if (time >= 5){
            uiText.text = "Time:" + t;
        }else{
            t = -t;
            uiText.text = "Time:" + t + "秒前";
        }
	}
}
