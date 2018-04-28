using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCamera : MonoBehaviour {

	//初期位置
	Vector3 position;

	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Quaternion.Euler(0,Time.time * 10,0) * position;
		transform.LookAt(Vector3.zero);
	}
}
