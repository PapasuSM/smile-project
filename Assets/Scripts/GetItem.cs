using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : Photon.MonoBehaviour
{
    //籠アイテム
    public GameObject b_parasol;
    public GameObject b_cracker;
    //
    public GameObject i_Parasol;
    public GameObject i_Cracker;
    /*
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
    */
    

   
    //コライダーに接触した相手がアイテム（Para）だった場合アイテムとして付与する
    //private void OnCollisionEnter(Collision other)
    private void OnTriggerEnter(Collider other)
    {
        //アイテムがParaだった場合
        if (other.name == "Field_Parasol" && photonView.isMine)
        {           
            InstantiatePlayer(b_parasol);
            
            //フィールド上のアイテムを消去
            Destroy(other.gameObject);
        }

        if (other.name == "Field_Cracker")
        {
            InstantiatePlayer(b_cracker);
            Destroy(other.gameObject);
        }

    }

    //籠からアイテムが出たら同種のアイコンを非表示にする
    private void OnTriggerExit(Collider other)
    {        
        if(other.name == "Basket_Parasol(Clone)")//switch文のほうがいい？？？？？？？？？？
        {
            i_Parasol.SetActive(false);
        }
        if(other.name == "Basket_Cracker(Clone)")
        {
            i_Cracker.SetActive(false);
        }
    }

    //籠の中にアイテムがあるなら同種のアイコンを表示する
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Basket_Parasol(Clone)")
        {
            i_Parasol.SetActive(true);
        }
        if (other.name == "Basket_Cracker(Clone)")
        {
            i_Cracker.SetActive(true);
        }
    }




    //籠の中にアイテムを生成
    private void InstantiatePlayer(GameObject b_item)
    {
        GameObject obj = (GameObject)PhotonNetwork.Instantiate(b_item.name, gameObject.transform.position, Quaternion.identity, 0);
        obj.transform.parent = gameObject.transform;
    }
}
