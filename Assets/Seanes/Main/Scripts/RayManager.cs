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
    public GameObject i_Cracker;
    /*
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
    */
    //アイコンゲージ
    public Image i_Para_Gauge;
    public Image i_Crac_Gauge;

    //アイコンゲージタイム
    //float i_Item_GaugeTime;

    //籠のアイテム
    GameObject b_Parasol;
    GameObject b_Creacker;



        
    Vector3 firstBasketGaugePosition;
    Vector3 first_Item_GaugePosition;

    void Start()
    {
        firstBasketGaugePosition = basketGauge.rectTransform.localPosition;
        first_Item_GaugePosition = new Vector3(0, -200f);
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

        //ヒットしたコライダーのタグがQuadだったら
        //
        //各種アイテムの｛ゲージ；生成；非表示；削除｝を行う
        if (hit.collider.gameObject.tag == "Quad")
        {
            gaugeTime += Time.deltaTime * 0.02f;
            
            //
            if (hit.collider.gameObject.name == "BasketButtonCollider")
            {                
                basketGauge.rectTransform.localPosition = Vector3.Lerp(basketGauge.rectTransform.localPosition, new Vector3(0, 1, 0), gaugeTime);

                //ゲージが溜まったらUIをアクティブにする
                if (basketGauge.rectTransform.localPosition.y >= endPositionY)
                {
                    ui.SetActive(true);
                    //５秒たったら消す
                    //Invoke("setout", 5.0f);
                }
            }

            //パラソル
            if (hit.collider.gameObject.name == "Parasol")
            {
                //ゲージを動かす
                i_Para_Gauge.rectTransform.localPosition = Vector3.Lerp(i_Para_Gauge.rectTransform.localPosition, new Vector3(0, 1, 0), gaugeTime);

                //ゲージが溜まったら
                if (i_Para_Gauge.rectTransform.localPosition.y >= endPositionY)
                {
                    //ゲージ；生成；非表示；削除
                    ITEM(e_Parasol, i_Parasol, "Basket_Parasol(Clone)");
                }
            }

            //爆竹
            if (hit.collider.gameObject.name == "Cracker")
            {                
                i_Crac_Gauge.rectTransform.localPosition = Vector3.Lerp(i_Crac_Gauge.rectTransform.localPosition, new Vector3(0, 1, 0), gaugeTime);
                if (i_Crac_Gauge.rectTransform.localPosition.y >= endPositionY)
                {                    
                    ITEM(e_Cracker, i_Cracker, "Basket_Cracker(Clone)");
                }
            }

            //null３
            if (hit.collider.gameObject.name == "null")
            {
                //InstantiateEquipment(e_Parasol);
            }
            //4
            if (hit.collider.gameObject.name == "null")
            {
                //InstantiateEquipment(e_Parasol);
            }
            //5
            if (hit.collider.gameObject.name == "null")
            {
                //InstantiateEquipment(e_Parasol);
            }
        }
        else//レイが当たってないならゲージを元の位置に戻す
        {
            gaugeTime = 0;

            basketGauge.rectTransform.localPosition = firstBasketGaugePosition;

            i_Para_Gauge.rectTransform.localPosition = first_Item_GaugePosition;
            i_Crac_Gauge.rectTransform.localPosition = first_Item_GaugePosition;
        }       
    }




    //生成；非表示；削除
    void ITEM(GameObject e_Item,GameObject i_Item,string NAME)
    {
        ui.SetActive(false);     //UIを閉じる 

        if (dive_Camera.transform.childCount == 2)
        {
            InstantiateEquipment(e_Item);  //アイテム生成        
            i_Item.SetActive(false);       //アイコンを非表示        

            foreach (Transform child in basket.transform)
            {
                if (child.name == NAME)
                {
                    Destroy(child.gameObject);//籠内のアイテムを削除
                }
            }
        }        
    }   

    //装備としてアイテムを生成
    private void InstantiateEquipment(GameObject e_Item)
    { 
        GameObject obj = (GameObject)PhotonNetwork.Instantiate(e_Item.name, gameObject.transform.position, Quaternion.identity, 0);
        obj.transform.parent = dive_Camera.transform;
        obj.transform.localPosition = new Vector3(0,0,2);        
    }
}
