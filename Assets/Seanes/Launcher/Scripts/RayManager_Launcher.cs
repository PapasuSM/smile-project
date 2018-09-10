using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayManager_Launcher : MonoBehaviour {

    public GameObject dive_Camera;
    public GameObject Panels;        
    public GameObject Cube;
    public Image Gauge;
    //あかさたなはまやらわ
    public GameObject[] _panels;
    
    //aiueo
    public Image[] Gauge_Y;
    public Image[] Gauge_R;
    int n = 0;

    float GaugeTime;
    float gaugeTime;
    float gaugetime;
    float _g_Time;

    float EndPositionX = -280f;
    float endPositionX = -2f;

    Vector3 firstGaugePosition;
    Vector3 firstPlay_GaugePosition;
    Vector3 firstgaugeposition;
    //
    public InputField _inputField;
    string _Text;
    //
    public GameObject _LauncherObject;
    public Image Gauge_Play;


    Text _name;
    string NAME;
    Transform _parent;
    Transform _child0;
    Transform _child1;






    // Use this for initialization
    void Start ()
    {
        firstGaugePosition = Gauge.rectTransform.localPosition;
        firstgaugeposition = Gauge_Y[0].rectTransform.localPosition;
        firstPlay_GaugePosition = Gauge_Play.rectTransform.localPosition;        
    }


    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(dive_Camera.transform.position, dive_Camera.transform.forward);
        RaycastHit hit;
        //outにするのが重要？？？？？

        
        if (Physics.Raycast(ray, out hit))
        {
            Cube.transform.position = hit.point;


            if (hit.collider.gameObject.tag == "Quad")
            {
                //Play　＆　入力
                if (hit.collider.gameObject.name == "ray_inputcollider" ^ hit.collider.gameObject.name == "Collider_Play_Button")
                {
                    GaugeTime += Time.deltaTime * 0.02f;

                    if (hit.collider.gameObject.name == "Collider_Play_Button")
                    {
                        Gauge_Play.rectTransform.localPosition = Vector3.Lerp(Gauge_Play.rectTransform.localPosition, new Vector3(1, 0, 0), GaugeTime / 2);

                        if (Gauge_Play.rectTransform.localPosition.x >= 0)
                        {
                            LauncherScript L = _LauncherObject.GetComponent<LauncherScript>();
                            L.Connect();
                        }
                    }
                    else
                    {
                        Gauge_Play.rectTransform.localPosition = firstPlay_GaugePosition;
                    }

                    if (hit.collider.gameObject.name == "ray_inputcollider")
                    {

                        Gauge.rectTransform.localPosition = Vector3.Lerp(Gauge.rectTransform.localPosition, new Vector3(1, 0, 0), GaugeTime);

                        if (Gauge.rectTransform.localPosition.x >= EndPositionX)
                        {
                            Panels.SetActive(true);
                        }
                    }
                    else
                    {
                        Gauge.rectTransform.localPosition = firstGaugePosition;
                    }
                }
                else
                {
                    GaugeTime = 0;
                    Gauge.rectTransform.localPosition = firstGaugePosition;                
                    Gauge_Play.rectTransform.localPosition = firstGaugePosition;
                }



                if (hit.collider.gameObject.name == "Collider_あ")
                {
                    
                    //_panels[0].SetActive(false);
                    _panels[1].SetActive(false);
                    _panels[2].SetActive(false);
                    _panels[3].SetActive(false);
                    _panels[4].SetActive(false);
                    _panels[5].SetActive(false);
                    _panels[6].SetActive(false);
                    _panels[7].SetActive(false);
                    _panels[8].SetActive(false);
                    _panels[9].SetActive(false);
                    _panels[10].SetActive(false);
                    _panels[11].SetActive(false);
                    

                    gaugeTime += Time.deltaTime * 2f;
                    Gauge_Y[0].rectTransform.localPosition = Vector3.Lerp(Gauge_Y[0].rectTransform.localPosition, new Vector3(10, 0, 0), gaugeTime);

                    if (Gauge_Y[0].rectTransform.localPosition.x >= endPositionX)
                    {
                        _panels[0].SetActive(true);

                        
                        gaugetime += Time.deltaTime * 2f;
                        Gauge_R[0].rectTransform.localPosition = Vector3.Lerp(Gauge_R[0].rectTransform.localPosition, new Vector3(5, 0, 0), gaugetime);
                        if (Gauge_R[0].rectTransform.localPosition.x >= endPositionX)
                        {                       
                            addText("あ");

                            gaugetime = 0;
                            Gauge_R[0].rectTransform.localPosition = firstgaugeposition;
                            Gauge_Y[0].rectTransform.localPosition = firstgaugeposition;
                            return;
                        }
                        else
                        {                            
                            
                        }
                    }
                    else
                    {
                        gaugetime = 0;
                        Gauge_R[0].rectTransform.localPosition = firstgaugeposition;
                    }
                }
                else
                {
                    gaugetime = 0;
                    Gauge_R[0].rectTransform.localPosition = firstgaugeposition;
                    Gauge_Y[0].rectTransform.localPosition = firstgaugeposition;
                }
                if (hit.collider.gameObject.name == "Collider_か")
                {                    
                    _panels[0].SetActive(false);
                    //_panels[1].SetActive(false);
                    _panels[2].SetActive(false);
                    _panels[3].SetActive(false);
                    _panels[4].SetActive(false);
                    _panels[5].SetActive(false);
                    _panels[6].SetActive(false);
                    _panels[7].SetActive(false);
                    _panels[8].SetActive(false);
                    _panels[9].SetActive(false);
                    _panels[10].SetActive(false);
                    _panels[11].SetActive(false);
                    

                    gaugeTime += Time.deltaTime * 2f;
                    Gauge_Y[1].rectTransform.localPosition = Vector3.Lerp(Gauge_Y[1].rectTransform.localPosition, new Vector3(10, 0, 0), gaugeTime);

                    if (Gauge_Y[1].rectTransform.localPosition.x >= endPositionX)
                    {
                        _panels[1].SetActive(true);


                        gaugetime += Time.deltaTime * 2f;
                        Gauge_R[1].rectTransform.localPosition = Vector3.Lerp(Gauge_R[1].rectTransform.localPosition, new Vector3(5, 0, 0), gaugetime);
                        if (Gauge_R[1].rectTransform.localPosition.x >= endPositionX)
                        {
                            print("kaka");
                            addText("か");

                            gaugetime = 0;
                            Gauge_R[1].rectTransform.localPosition = firstgaugeposition;
                            Gauge_Y[1].rectTransform.localPosition = firstgaugeposition;
                            return;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        gaugetime = 0;
                        Gauge_R[1].rectTransform.localPosition = firstgaugeposition;
                    }
                }
                else
                {
                    gaugetime = 0;
                    Gauge_R[1].rectTransform.localPosition = firstgaugeposition;
                    Gauge_Y[1].rectTransform.localPosition = firstgaugeposition;
                }
                if (hit.collider.gameObject.name == "Collider_さ")
                {
                    _panels[0].SetActive(false);
                    _panels[1].SetActive(false);
                    //_panels[2].SetActive(false);
                    _panels[3].SetActive(false);
                    _panels[4].SetActive(false);
                    _panels[5].SetActive(false);
                    _panels[6].SetActive(false);
                    _panels[7].SetActive(false);
                    _panels[8].SetActive(false);
                    _panels[9].SetActive(false);
                    _panels[10].SetActive(false);
                    _panels[11].SetActive(false);


                    gaugeTime += Time.deltaTime * 2f;
                    Gauge_Y[2].rectTransform.localPosition = Vector3.Lerp(Gauge_Y[2].rectTransform.localPosition, new Vector3(10, 0, 0), gaugeTime);

                    if (Gauge_Y[2].rectTransform.localPosition.x >= endPositionX)
                    {
                        _panels[2].SetActive(true);


                        gaugetime += Time.deltaTime * 2f;
                        Gauge_R[2].rectTransform.localPosition = Vector3.Lerp(Gauge_R[2].rectTransform.localPosition, new Vector3(5, 0, 0), gaugetime);
                        if (Gauge_R[2].rectTransform.localPosition.x >= endPositionX)
                        {
                            addText("さ");

                            gaugetime = 0;
                            Gauge_R[2].rectTransform.localPosition = firstgaugeposition;
                            Gauge_Y[2].rectTransform.localPosition = firstgaugeposition;
                            return;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        gaugetime = 0;
                        Gauge_R[2].rectTransform.localPosition = firstgaugeposition;
                    }
                }
                else
                {
                    gaugetime = 0;
                    Gauge_R[2].rectTransform.localPosition = firstgaugeposition;
                    Gauge_Y[2].rectTransform.localPosition = firstgaugeposition;
                }
                if (hit.collider.gameObject.name == "Collider_た")
                {
                    _panels[0].SetActive(false);
                    _panels[1].SetActive(false);
                    _panels[2].SetActive(false);
                    //_panels[3].SetActive(false);
                    _panels[4].SetActive(false);
                    _panels[5].SetActive(false);
                    _panels[6].SetActive(false);
                    _panels[7].SetActive(false);
                    _panels[8].SetActive(false);
                    _panels[9].SetActive(false);
                    _panels[10].SetActive(false);
                    _panels[11].SetActive(false);


                    gaugeTime += Time.deltaTime * 2f;
                    Gauge_Y[3].rectTransform.localPosition = Vector3.Lerp(Gauge_Y[3].rectTransform.localPosition, new Vector3(10, 0, 0), gaugeTime);

                    if (Gauge_Y[3].rectTransform.localPosition.x >= endPositionX)
                    {
                        _panels[3].SetActive(true);


                        gaugetime += Time.deltaTime * 2f;
                        Gauge_R[3].rectTransform.localPosition = Vector3.Lerp(Gauge_R[3].rectTransform.localPosition, new Vector3(5, 0, 0), gaugetime);
                        if (Gauge_R[3].rectTransform.localPosition.x >= endPositionX)
                        {
                            addText("た");

                            gaugetime = 0;
                            Gauge_R[3].rectTransform.localPosition = firstgaugeposition;
                            Gauge_Y[3].rectTransform.localPosition = firstgaugeposition;
                            return;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        gaugetime = 0;
                        Gauge_R[3].rectTransform.localPosition = firstgaugeposition;
                    }
                }
                else
                {
                    gaugetime = 0;
                    Gauge_R[3].rectTransform.localPosition = firstgaugeposition;
                    Gauge_Y[3].rectTransform.localPosition = firstgaugeposition;
                }
                if (hit.collider.gameObject.name == "Collider_な")
                {
                    _panels[0].SetActive(false);
                    _panels[1].SetActive(false);
                    _panels[2].SetActive(false);
                    _panels[3].SetActive(false);
                    //_panels[4].SetActive(false);
                    _panels[5].SetActive(false);
                    _panels[6].SetActive(false);
                    _panels[7].SetActive(false);
                    _panels[8].SetActive(false);
                    _panels[9].SetActive(false);
                    _panels[10].SetActive(false);
                    _panels[11].SetActive(false);


                    gaugeTime += Time.deltaTime * 2f;
                    Gauge_Y[4].rectTransform.localPosition = Vector3.Lerp(Gauge_Y[4].rectTransform.localPosition, new Vector3(10, 0, 0), gaugeTime);

                    if (Gauge_Y[4].rectTransform.localPosition.x >= endPositionX)
                    {
                        _panels[4].SetActive(true);


                        gaugetime += Time.deltaTime * 2f;
                        Gauge_R[4].rectTransform.localPosition = Vector3.Lerp(Gauge_R[4].rectTransform.localPosition, new Vector3(5, 0, 0), gaugetime);
                        if (Gauge_R[4].rectTransform.localPosition.x >= endPositionX)
                        {
                            addText("な");

                            gaugetime = 0;
                            Gauge_R[4].rectTransform.localPosition = firstgaugeposition;
                            Gauge_Y[4].rectTransform.localPosition = firstgaugeposition;
                            return;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        gaugetime = 0;
                        Gauge_R[4].rectTransform.localPosition = firstgaugeposition;
                    }
                }
                else
                {
                    gaugetime = 0;
                    Gauge_R[4].rectTransform.localPosition = firstgaugeposition;
                    Gauge_Y[4].rectTransform.localPosition = firstgaugeposition;
                }
                if (hit.collider.gameObject.name == "Collider_は")
                {
                    n = 5;
                    _panels[0].SetActive(false);
                    _panels[1].SetActive(false);
                    _panels[2].SetActive(false);
                    _panels[3].SetActive(false);
                    _panels[4].SetActive(false);
                    //_panels[5].SetActive(false);
                    _panels[6].SetActive(false);
                    _panels[7].SetActive(false);
                    _panels[8].SetActive(false);
                    _panels[9].SetActive(false);
                    _panels[10].SetActive(false);
                    _panels[11].SetActive(false);


                    gaugeTime += Time.deltaTime * 2f;
                    Gauge_Y[n].rectTransform.localPosition = Vector3.Lerp(Gauge_Y[n].rectTransform.localPosition, new Vector3(10, 0, 0), gaugeTime);

                    if (Gauge_Y[n].rectTransform.localPosition.x >= endPositionX)
                    {
                        _panels[n].SetActive(true);


                        gaugetime += Time.deltaTime * 2f;
                        Gauge_R[n].rectTransform.localPosition = Vector3.Lerp(Gauge_R[n].rectTransform.localPosition, new Vector3(5, 0, 0), gaugetime);
                        if (Gauge_R[n].rectTransform.localPosition.x >= endPositionX)
                        {
                            addText("は");

                            gaugetime = 0;
                            Gauge_R[n].rectTransform.localPosition = firstgaugeposition;
                            Gauge_Y[n].rectTransform.localPosition = firstgaugeposition;
                            return;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        gaugetime = 0;
                        Gauge_R[n].rectTransform.localPosition = firstgaugeposition;
                    }
                }
                else
                {
                    gaugetime = 0;
                    Gauge_R[5].rectTransform.localPosition = firstgaugeposition;
                    Gauge_Y[5].rectTransform.localPosition = firstgaugeposition;
                }
                if (hit.collider.gameObject.name == "Collider_ま")
                {
                    n = 6;
                    _panels[0].SetActive(false);
                    _panels[1].SetActive(false);
                    _panels[2].SetActive(false);
                    _panels[3].SetActive(false);
                    _panels[4].SetActive(false);
                    _panels[5].SetActive(false);
                    //_panels[6].SetActive(false);
                    _panels[7].SetActive(false);
                    _panels[8].SetActive(false);
                    _panels[9].SetActive(false);
                    _panels[10].SetActive(false);
                    _panels[11].SetActive(false);


                    gaugeTime += Time.deltaTime * 2f;
                    Gauge_Y[n].rectTransform.localPosition = Vector3.Lerp(Gauge_Y[n].rectTransform.localPosition, new Vector3(10, 0, 0), gaugeTime);

                    if (Gauge_Y[n].rectTransform.localPosition.x >= endPositionX)
                    {
                        _panels[n].SetActive(true);


                        gaugetime += Time.deltaTime * 2f;
                        Gauge_R[n].rectTransform.localPosition = Vector3.Lerp(Gauge_R[n].rectTransform.localPosition, new Vector3(5, 0, 0), gaugetime);
                        if (Gauge_R[n].rectTransform.localPosition.x >= endPositionX)
                        {
                            addText("ま");

                            gaugetime = 0;
                            Gauge_R[n].rectTransform.localPosition = firstgaugeposition;
                            Gauge_Y[n].rectTransform.localPosition = firstgaugeposition;
                            return;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        gaugetime = 0;
                        Gauge_R[n].rectTransform.localPosition = firstgaugeposition;
                    }
                }
                else
                {
                    gaugetime = 0;
                    Gauge_R[6].rectTransform.localPosition = firstgaugeposition;
                    Gauge_Y[6].rectTransform.localPosition = firstgaugeposition;
                }
                if (hit.collider.gameObject.name == "Collider_や")
                {
                    n = 7;
                    _panels[0].SetActive(false);
                    _panels[1].SetActive(false);
                    _panels[2].SetActive(false);
                    _panels[3].SetActive(false);
                    _panels[4].SetActive(false);
                    _panels[5].SetActive(false);
                    _panels[6].SetActive(false);
                    //_panels[7].SetActive(false);
                    _panels[8].SetActive(false);
                    _panels[9].SetActive(false);
                    _panels[10].SetActive(false);
                    _panels[11].SetActive(false);


                    gaugeTime += Time.deltaTime * 2f;
                    Gauge_Y[n].rectTransform.localPosition = Vector3.Lerp(Gauge_Y[n].rectTransform.localPosition, new Vector3(10, 0, 0), gaugeTime);

                    if (Gauge_Y[n].rectTransform.localPosition.x >= endPositionX)
                    {
                        _panels[n].SetActive(true);


                        gaugetime += Time.deltaTime * 2f;
                        Gauge_R[n].rectTransform.localPosition = Vector3.Lerp(Gauge_R[n].rectTransform.localPosition, new Vector3(5, 0, 0), gaugetime);
                        if (Gauge_R[n].rectTransform.localPosition.x >= endPositionX)
                        {
                            addText("や");

                            gaugetime = 0;
                            Gauge_R[n].rectTransform.localPosition = firstgaugeposition;
                            Gauge_Y[n].rectTransform.localPosition = firstgaugeposition;
                            return;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        gaugetime = 0;
                        Gauge_R[n].rectTransform.localPosition = firstgaugeposition;
                    }
                }
                else
                {
                    gaugetime = 0;
                    Gauge_R[7].rectTransform.localPosition = firstgaugeposition;
                    Gauge_Y[7].rectTransform.localPosition = firstgaugeposition;
                }
                if (hit.collider.gameObject.name == "Collider_ら")
                {
                    n = 8;
                    _panels[0].SetActive(false);
                    _panels[1].SetActive(false);
                    _panels[2].SetActive(false);
                    _panels[3].SetActive(false);
                    _panels[4].SetActive(false);
                    _panels[5].SetActive(false);
                    _panels[6].SetActive(false);
                    _panels[7].SetActive(false);
                    //_panels[8].SetActive(false);
                    _panels[9].SetActive(false);
                    _panels[10].SetActive(false);
                    _panels[11].SetActive(false);


                    gaugeTime += Time.deltaTime * 2f;
                    Gauge_Y[n].rectTransform.localPosition = Vector3.Lerp(Gauge_Y[n].rectTransform.localPosition, new Vector3(10, 0, 0), gaugeTime);

                    if (Gauge_Y[n].rectTransform.localPosition.x >= endPositionX)
                    {
                        _panels[n].SetActive(true);


                        gaugetime += Time.deltaTime * 2f;
                        Gauge_R[n].rectTransform.localPosition = Vector3.Lerp(Gauge_R[n].rectTransform.localPosition, new Vector3(5, 0, 0), gaugetime);
                        if (Gauge_R[n].rectTransform.localPosition.x >= endPositionX)
                        {
                            addText("ら");

                            gaugetime = 0;
                            Gauge_R[n].rectTransform.localPosition = firstgaugeposition;
                            Gauge_Y[n].rectTransform.localPosition = firstgaugeposition;
                            return;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        gaugetime = 0;
                        Gauge_R[n].rectTransform.localPosition = firstgaugeposition;
                    }
                }
                else
                {
                    gaugetime = 0;
                    Gauge_R[8].rectTransform.localPosition = firstgaugeposition;
                    Gauge_Y[8].rectTransform.localPosition = firstgaugeposition;
                }
                if (hit.collider.gameObject.name == "Collider_わ")
                {
                    n = 9;
                    _panels[0].SetActive(false);
                    _panels[1].SetActive(false);
                    _panels[2].SetActive(false);
                    _panels[3].SetActive(false);
                    _panels[4].SetActive(false);
                    _panels[5].SetActive(false);
                    _panels[6].SetActive(false);
                    _panels[7].SetActive(false);
                    _panels[8].SetActive(false);
                    //_panels[9].SetActive(false);
                    _panels[10].SetActive(false);
                    _panels[11].SetActive(false);


                    gaugeTime += Time.deltaTime * 2f;
                    Gauge_Y[n].rectTransform.localPosition = Vector3.Lerp(Gauge_Y[n].rectTransform.localPosition, new Vector3(10, 0, 0), gaugeTime);

                    if (Gauge_Y[n].rectTransform.localPosition.x >= endPositionX)
                    {
                        _panels[n].SetActive(true);


                        gaugetime += Time.deltaTime * 2f;
                        Gauge_R[n].rectTransform.localPosition = Vector3.Lerp(Gauge_R[n].rectTransform.localPosition, new Vector3(5, 0, 0), gaugetime);
                        if (Gauge_R[n].rectTransform.localPosition.x >= endPositionX)
                        {
                            addText("わ");

                            gaugetime = 0;
                            Gauge_R[n].rectTransform.localPosition = firstgaugeposition;
                            Gauge_Y[n].rectTransform.localPosition = firstgaugeposition;
                            return;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        gaugetime = 0;
                        Gauge_R[n].rectTransform.localPosition = firstgaugeposition;
                    }
                }
                else
                {
                    gaugetime = 0;
                    Gauge_R[9].rectTransform.localPosition = firstgaugeposition;
                    Gauge_Y[9].rectTransform.localPosition = firstgaugeposition;
                }
                
                
                
                

            }
            if (hit.collider.gameObject.tag == "Quad1")
            {
                print("Quad1");
                _parent = hit.collider.transform.parent;
                _child0 = _parent.transform.GetChild(0);
                _child1 = _parent.transform.GetChild(1);

                
          
                _g_Time += Time.deltaTime * 0.1f;
                _child0.localPosition = Vector3.Lerp(_child0.localPosition, new Vector3(1, 0, 0), _g_Time);

                if (_child0.localPosition.x >= 0)
                {
                    //string NAME = hit.collider.gameObject.name;
                    _name = _child1.gameObject.GetComponent<Text>();
                    NAME = _name.text;
                    addText(NAME);

                    _g_Time = 0;
                    _child0.localPosition = new Vector3(-50, 0, 0);
                }                
            }
            else
            {
                _g_Time = 0;
                _child0.localPosition = new Vector3(-50, 0, 0);
            }
        }
    }

    public void addText(string t)
    {
        _inputField.GetComponent<InputField>();
        _inputField.text = _inputField.text + t;
        
    }

    

}
