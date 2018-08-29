using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KeyBoard : Photon.MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;

    float ppX = 0;
    
    float streamBonus = 1;
    int n = 0;


    float tempoTime = 0;
    int tempo = 1;


    void Start()
    {
        if (!(photonView.isMine))
        {
            return;
        }

        float ppX = player.transform.localPosition.x;

        //子オブジェクトをアクティブにする
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }


    
    void Update()
    {
        if (!(photonView.isMine))
        {
            return;
        }
        
        //移動範囲を制限
        transform.localPosition =
            new Vector3(
                Mathf.Clamp(transform.localPosition.x, -2, 2),
                Mathf.Clamp(transform.localPosition.y, -1, 10),
                Mathf.Clamp(transform.localPosition.z, 0, 0)
                );


        //右へ曲がる条件
        if (Input.GetKey(KeyCode.RightArrow))
        {
            trunRight();
        }
        //左へ曲がる条件
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            trunLeft();
        }


        //Keyが押されるまでの時間をはかる
        tempoTime += Time.deltaTime;

        //スピード決定条件
        if (Input.GetKeyDown(KeyCode.UpArrow) && tempo == 1)
        {
            if (tempoTime <= 1)
            {
                if (tempoTime <= 0.9)
                {
                    if (tempoTime <= 0.8)
                    {
                        if (tempoTime <= 0.7)
                        {
                            if (tempoTime <= 0.6)
                            {
                                if (tempoTime <= 0.5)
                                {
                                    if (tempoTime <= 0.4)
                                    {
                                        if (tempoTime <= 0.3)
                                        {
                                            if (tempoTime <= 0.2)
                                            {
                                                if (tempoTime <= 0.1)
                                                {
                                                    speedUP(5f);
                                                    tempoTime = 0;
                                                    tempo = 2;
                                                    return;
                                                }
                                                speedUP(4.5f);
                                                tempoTime = 0;
                                                tempo = 2;
                                                return;
                                            }
                                            speedUP(4f);
                                            tempoTime = 0;
                                            tempo = 2;
                                            return;
                                        }
                                        speedUP(3.5f);
                                        tempoTime = 0;
                                        tempo = 2;
                                        return;
                                    }
                                    speedUP(3f);
                                    tempoTime = 0;
                                    tempo = 2;
                                    return;
                                }
                                speedUP(2.5f);
                                tempoTime = 0;
                                tempo = 2;
                                return;
                            }
                            speedUP(2f);
                            tempoTime = 0;
                            tempo = 2;
                            return;
                        }
                        speedUP(1.5f);
                        tempoTime = 0;
                        tempo = 2;
                        return;
                    }
                    speedUP(1f);
                    tempoTime = 0;
                    tempo = 2;
                    return;
                }
                speedUP(0.5f);
                tempoTime = 0;
                tempo = 2;
                return;
            }
            speedUP(0);
            tempoTime = 0;
            tempo = 2;
            return;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && tempo == 2)
        {
            if (tempoTime <= 1)
            {
                if (tempoTime <= 0.9)
                {
                    if (tempoTime <= 0.8)
                    {
                        if (tempoTime <= 0.7)
                        {
                            if (tempoTime <= 0.6)
                            {
                                if (tempoTime <= 0.5)
                                {
                                    if (tempoTime <= 0.4)
                                    {
                                        if (tempoTime <= 0.3)
                                        {
                                            if (tempoTime <= 0.2)
                                            {
                                                if (tempoTime <= 0.1)
                                                {
                                                    speedUP(5f);
                                                    tempoTime = 0;
                                                    tempo = 1;
                                                    return;
                                                }
                                                speedUP(4.5f);
                                                tempoTime = 0;
                                                tempo = 1;
                                                return;
                                            }
                                            speedUP(4f);
                                            tempoTime = 0;
                                            tempo = 1;
                                            return;
                                        }
                                        speedUP(3.5f);
                                        tempoTime = 0;
                                        tempo = 1;
                                        return;
                                    }
                                    speedUP(3f);
                                    tempoTime = 0;
                                    tempo = 1;
                                    return;
                                }
                                speedUP(2.5f);
                                tempoTime = 0;
                                tempo = 1;
                                return;
                            }
                            speedUP(2f);
                            tempoTime = 0;
                            tempo = 1;
                            return;
                        }
                        speedUP(1.5f);
                        tempoTime = 0;
                        tempo = 1;
                        return;
                    }
                    speedUP(1f);
                    tempoTime = 0;
                    tempo = 1;
                    return;
                }
                speedUP(0.5f);
                tempoTime = 0;
                tempo = 1;
                return;
            }
            speedUP(0f);
            tempoTime = 0;
            tempo = 1;
            return;
        }

        if (tempoTime >= 2) //２秒以上間隔があくとスピードが０
        {
            if (!(Input.GetKeyDown(KeyCode.UpArrow)) || !(Input.GetKeyDown(KeyCode.DownArrow)))
            {
                speedUP(0);
            }
        }
    }



    //SlipStream開始により最高速度上昇
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            print("SlipStream!!!!");
            streamBonus = 1.2f;
        }
    }

    //SlipStreaam終了
    private void OnTriggerExit(Collider other)
    {
        Invoke("streamBonusEND", 3.0f);
    }
    void streamBonusEND()
    {
        streamBonus = 1;
    }




    //スピード
    void speedUP(float z)
    {
        n = 1;

        if (0 <= Time.time && Time.time <= 5)
        {
            n = 0;
        }

        agent.speed = n * z * streamBonus;
    }

    //右へ曲がる
    void trunRight()
    {
        if (ppX < 2)
        {
            //rigidbody型
            //player.GetComponent<Rigidbody>().AddForce(transform.right * 0.1f, ForceMode.Impulse);

            //transform型でいいのか？？？？？
            player.transform.Translate(0.05f, 0, 0);
        }
    }

    //左へ曲がる
    void trunLeft()
    {
        if (ppX > -2)
        {
            //rigidbody型
            //player.GetComponent<Rigidbody>().AddForce(transform.right * 0.1f, ForceMode.Impulse);
            //transform型
            player.transform.Translate(-0.05f, 0, 0);
        }
    }
}