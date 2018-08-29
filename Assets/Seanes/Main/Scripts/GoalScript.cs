using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour{

    public static bool goal;

    void Start(){

        goal = false;
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "player"){

            print("ゴーーーール！！！");
            goal = true;           
        }
    }
}
