using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayManager :　Photon.MonoBehaviour {

    public GameObject dive_Camera;
    public GameObject basket;
    public Image reticle;
    //
    public Image basketGauge;
    public GameObject ui;
    float endPositionY = -0.1f;
    float gaugeTime;

    //装備アイテム
    public GameObject e_Parasol;
    public GameObject e_Cracker;

    //アイコン
    public GameObject i_Parasol;
    /*
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
    */
    //アイコンゲージ
    public Image i_Para_Gauge;

    //アイコンゲージタイム
    float i_Para_gaugeTime;

    //籠のアイテム
    GameObject b_Parasol;
    GameObject b_Creacker;



        
    Vector3 firstBasketGaugePosition;
    Vector3 first_i_ParaGaugePosition;

    void Start()
    {
        firstBasketGaugePosition = basketGauge.rectTransform.localPosition;
        first_i_ParaGaugePosition = i_Para_Gauge.rectTransform.localPosition;
    }



    void Update()
    {
        Ray ray = new Ray(dive_Camera.transform.position, dive_Camera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //レイが当たってるところに〇を表示する
            reticle.rectTransform.position = hit.point;            
            //レイが当たってるゲームオブジェクトの名前と場所をプリント
            //GameObject selestedObj = hit.collider.gameObject;
            //print("name: " + selestedObj.name + selestedObj.transform.position);            
        }

        //ヒットしたコライダーのTagがButtonだったら
        //Gaugeポジションをスライドさせる
        if (hit.collider.gameObject.tag == "Button")
        {
            gaugeTime += Time.deltaTime * 0.02f;
            basketGauge.rectTransform.localPosition = 
                Vector3.Lerp(
                    basketGauge.rectTransform.localPosition, new Vector3(0, 1, 0), gaugeTime
                    );

            //ゲージが溜まったらUIをアクティブにする
            if (basketGauge.rectTransform.localPosition.y >= endPositionY)
            {
                ui.SetActive(true);
                //５秒たったら消す
                //Invoke("setout", 5.0f);
            }
        }
        else//レイが"Button"に当たってないならゲージを元の位置に戻す
        {
            gaugeTime = 0;
            basketGauge.rectTransform.localPosition = firstBasketGaugePosition;
        }


      
    
        //ヒットしたコライダーのタグがQuadだったら
        //各種アイテムを増備する
        if (hit.collider.gameObject.tag == "Quad")
        {
            
            //パラソル
            if (hit.collider.gameObject.name == "Parasol")
            {
                //ゲージを動かす
                i_Para_gaugeTime += Time.deltaTime * 0.02f;
                i_Para_Gauge.rectTransform.localPosition =
                    Vector3.Lerp(
                        i_Para_Gauge.rectTransform.localPosition, new Vector3(0, 1, 0), i_Para_gaugeTime
                        );

                //ゲージが溜まったら
                if (i_Para_Gauge.rectTransform.localPosition.y >= endPositionY)
                {                   
                    //アイテム生成
                    InstantiateEquipment();                                        
                    
                    //UIを閉じる
                    ui.SetActive(false);
                    
                    //籠内のパラソルを削除
                    foreach (Transform child in basket.transform)
                    {
                        if (child.name == "Basket_Parasol(Clone)")
                        {
                            Destroy(child.gameObject);
                        }
                    }
                }               
            }

            //爆竹
            if (hit.collider.gameObject.name == "Cracker")
            {
                //InstantiateEquipment(e_Parasol);
            }

            //null
            if (hit.collider.gameObject.name == "null")
            {
                //InstantiateEquipment(e_Parasol);
            }

            if (hit.collider.gameObject.name == "null")
            {
                //InstantiateEquipment(e_Parasol);
            }

            if (hit.collider.gameObject.name == "null")
            {
                //InstantiateEquipment(e_Parasol);
            }

           


        }
        else//レイが当たってないならゲージを元の位置に戻す
        {
            i_Para_gaugeTime = 0;
            i_Para_Gauge.rectTransform.localPosition = first_i_ParaGaugePosition;
        }       
    }











    //UIを非表示にする
    void setout()
    {
        ui.SetActive(false);
    }

    //装備としてアイテムを生成
    private void InstantiateEquipment()
    {
        GameObject obj = (GameObject)PhotonNetwork.Instantiate(e_Parasol.name, gameObject.transform.position, Quaternion.identity, 0);
        obj.transform.parent = dive_Camera.transform;
        obj.transform.localPosition = new Vector3(0,0,2);        
    }
}
