using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slipstream : Photon.MonoBehaviour{
    
    public NavMeshAgent agent;
    public Transform diveCamera;
    public GameObject player;

    GameObject divecamera;

    float streamBonus = 1;
    int n = 0;

    
    void Start()
    {
        
        if (!(photonView.isMine))
        {
            return;
        }
        

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        

    }
    

    //移動範囲を制限
    void Update()
    {
        transform.localPosition =
            new Vector3(
                Mathf.Clamp(transform.localPosition.x, -2, 2),
                Mathf.Clamp(transform.localPosition.y, -1, 10),
                Mathf.Clamp(transform.localPosition.z, 0, 0)
                );
        /*
        diveCamera = transform.GetChild(3);
        diveCamera.SetActive(true);
        */
    }



    //SlipStream開始により最高速度上昇
    private void OnTriggerEnter(Collider other){
    
        if (other.tag == "player"){

            print("SlipStream!!!!");
            streamBonus = 1.2f;
        }
    }

    //SlipStreaam終了
    private void OnTriggerExit(Collider other){

        Invoke("streamBonusEND", 3.0f);
    }
    void streamBonusEND(){

        streamBonus = 1;
    }


    private void FixedUpdate(){

        if (!(photonView.isMine))
        {
            return;
        }

        //子オブジェクトのDiveCameraをアクティブにする


        float dcrX = diveCamera.localRotation.x;
        float dcrY = diveCamera.localRotation.y;
        float dcrZ = diveCamera.localRotation.z;

        //レーン変更
        if (dcrZ >= 0.25f){
            trunRight();
        }
        if (dcrZ <= -0.25f){
            trunLeft();
        }

        //スピードを制御
        if (-0.2f <= dcrX && dcrX <= 0.2f){
            if (-0.2f <= dcrY && dcrY <= 0.2f){

                speedUP(4.5f);
            }

            if (dcrY < -0.2f ^ 0.2 < dcrY){

                speedUP(3.0f);
            }
        }

        if (dcrX < -0.2f ^ 0.2 < dcrX){
            if (dcrY < -0.2f ^ 0.2 < dcrY){

                speedUP(1.0f);
                return;
            }

            speedUP(3.0f);
        }
    }





    //スピードアップ
    void speedUP(float z){

        n = 1;

        if(0 <= Time.time && Time.time <= 5){
            n = 0;
        }

        agent.speed = n * z * streamBonus;        
    }

    //右へ曲がる
    void trunRight(){
        float ppX = player.transform.localPosition.x;

        if (ppX < 2){
            //rigidbody型
            //player.GetComponent<Rigidbody>().AddForce(transform.right * 0.1f, ForceMode.Impulse);
            
            //transform型でいいのか？？？？？
            player.transform.Translate(0.05f, 0, 0);
        }
    }

    //左へ曲がる
    void trunLeft(){
        float ppX = player.transform.localPosition.x;

        if (ppX > -2){
            //rigidbody型
            //player.GetComponent<Rigidbody>().AddForce(transform.right * 0.1f, ForceMode.Impulse);
            //transform型
            player.transform.Translate(-0.05f, 0, 0);
        }
    }
}