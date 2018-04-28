using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myTrail : MonoBehaviour {

	Rigidbody rb;
	GameObject[] go_list;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		go_list = GameObject.FindGameObjectsWithTag("Player");
		transform.position = Random.onUnitSphere * 40;
	}
	
	// Update is called once per frame
	void Update () {

		foreach(GameObject go in go_list){

			if(this.gameObject.GetInstanceID() == go.GetInstanceID()){
				continue;
			}

			var diff = go.transform.position - transform.position;
			var len = diff.sqrMagnitude;
			var force = diff/len;

			rb.AddForce(force);
		}

		rb.AddForce(-transform.position);

	}
}
