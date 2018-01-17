using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour {

    public bool displayAble = false;
    
    private float setTime = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(displayAble)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            
            setTime += Time.deltaTime;
            if(setTime >= 3.0f)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                displayAble = false;
                setTime = 0.0f;
            }
        }
	}
}
