using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMLV : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject selestedObj = hit.collider.gameObject;
                print("name: " + selestedObj.name + selestedObj.transform.position);
            }
        }

    }
}
