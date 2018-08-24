using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonController : MonoBehaviour {

    public GameObject playerBox;

    

    //部屋に入った時に呼ばれる
    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(
            playerBox.name,
            new Vector3(0f, 0f, 1f),
            Quaternion.identity,
            0
         );
    }
}