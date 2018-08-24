using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket_Item : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        
        //籠から出たらオブジェクトを消す
        if (this.transform.localPosition.x <= -0.5 || 0.5 <= this.transform.localPosition.x)
        {
            Invoke("Delete", 2.0f);
        }

        if (this.transform.localPosition.y <= -0.5 || 0.5 <= this.transform.localPosition.y)
        {
            Invoke("Delete", 2.0f);
        }

        if (this.transform.localPosition.z <= -0.5 || 0.5 <= this.transform.localPosition.z)
        {
            Invoke("Delete", 2.0f);          
        }
	}


    void Delete()
    {
        Destroy(gameObject);        
    }
}
