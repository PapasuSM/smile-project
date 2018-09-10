using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Script : MonoBehaviour
{

    public GameObject _rayManager;
    public GameObject dive_Camera;

    GameObject _Gauge;
    float _EndPosition = -1;
    Text text;
    string S;
    Vector3 _FirstGaugePosition;
    Vector3 _GP;
    float gaugeTime;
    float x;


    // Use this for initialization
    void Start()
    {
        _FirstGaugePosition = this.transform.GetChild(0).localPosition;

        text = this.gameObject.GetComponentInChildren<Text>();
        S = (text).ToString();
        

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(dive_Camera.transform.position, dive_Camera.transform.forward);
        RaycastHit hit;

        //_GP = this.gameObject.GetComponentsInChildren<RectTransform>(0);
      
        x = this.transform.GetChild(0).localPosition.x;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "panel")
            {
                gaugeTime += Time.deltaTime * 2f;
                _GP = Vector3.Lerp(_GP, new Vector3(10, 0, 0), gaugeTime);

                if (x >= _EndPosition)
                {
                    RayManager_Launcher R = _rayManager.GetComponent<RayManager_Launcher>();
                    R.addText(S);

                    _GP = _FirstGaugePosition;
                    gaugeTime = 0;
                }
            }
            else
            {
                _GP = _FirstGaugePosition;
                gaugeTime = 0;

            }
        }
    }
}
