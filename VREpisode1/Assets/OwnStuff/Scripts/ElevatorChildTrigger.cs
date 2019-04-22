﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ElevatorChildTrigger : MonoBehaviour {
    GameObject mainSDK;
    GameObject Elevator;
   
    void Start () {
        mainSDK = GameObject.Find("[VRTK_SDKManager]");
        Elevator = GameObject.Find("ELEVATOR2.0");
	}
	
    private void OnTriggerEnter(Collider other)
    {
        if (other == GameObject.Find("Water").GetComponent<WaterMovement>().head)
        {
            mainSDK.transform.parent = Elevator.transform;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == GameObject.Find("Water").GetComponent<WaterMovement>().head)
        {
            mainSDK.transform.parent = null;
        }
    }

    void Update () {
		
	}
}