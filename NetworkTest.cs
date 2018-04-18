using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Photon继承这个PunBehaviour
public class NetworkTest : Photon.PunBehaviour {

	// Use this for initialization
	void Start () {

        PhotonNetwork.ConnectUsingSettings("0.0.1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
