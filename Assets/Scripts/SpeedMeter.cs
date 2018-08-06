using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeedMeter : MonoBehaviour {

    public Image gauge;
    Vector3 latestPos;
    Vector3 speed;
    GameObject player;
    Vector3 firstPosition;

    float gaugeTime = 0;

    // Use this for initialization
    void Start() {

        player = GameObject.Find("player");

        firstPosition = gauge.rectTransform.localPosition;
    }

    // Update is called once per frame
    void Update() {

        speed = ((player.transform.position - latestPos) / Time.deltaTime);

        int x = Mathf.FloorToInt(speed.x);
        int y = Mathf.FloorToInt(speed.y);
        int z = Mathf.FloorToInt(speed.z);

        float speeds = (x * x) + (y * y) + (z * z);
        int t = Mathf.FloorToInt(speeds);

        print(t);

        gaugeTime = Time.deltaTime * 1f;
        if (0 < t) {
            if (1 <= t && t < 3) {

                speedMater(100f);
            }

            if (3 <= t && t < 15) {

                speedMater(300f);
            }

            if (15 <= t) {

                speedMater(450f);
            }
        }

        latestPos = player.transform.position;
    }



    void speedMater(float m){

        gauge.rectTransform.localPosition =
                Vector3.Lerp(
                    gauge.rectTransform.localPosition,
                    new Vector3(m, 0, 0),
                    gaugeTime
                    );
    }
}
