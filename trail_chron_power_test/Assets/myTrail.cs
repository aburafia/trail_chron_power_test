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
		transform.position = Random.onUnitSphere * 40f;

		//球表面の接線方向へのパワーだとおもう
		//そして、ここ、Impulusつけないと、全然結果が違う。
		//Impulusなるほど。dtがデカすぎるなるほどｗｗｗ
		rb.AddForce(Vector3.Cross(transform.position,Random.onUnitSphere),ForceMode.Impulse);

	}
	
	// Update is called once per frame
	void Update () {

		foreach(GameObject go in go_list){

			if(this.gameObject.GetInstanceID() == go.GetInstanceID()){
				continue;
			}

			var diff = go.transform.position - transform.position;
			var len = diff.sqrMagnitude;

			//normalized忘れてた。lenで割ってるからねいるよね
			var force = diff.normalized/len;

			//100とかマジックナンバー。適当
			rb.AddForce(force * 100f);
		}

		rb.AddForce(-transform.position);

	}
}
