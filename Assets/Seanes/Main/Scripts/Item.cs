using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //アイテムを回転rigi型に変更すること
        transform.Rotate(0.3f, 0.7f, 0.3f);
    }
}
