using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript_CS : MonoBehaviour {

	public float time;
	public Transform target;
	Vector3 Pos;
	Vector3 tmp;
	Vector3 vp;

	float rand;

	void Awake(){
		rand = 0.03f + Random.value* 0.03f;
	}

	void FixedUpdate () {

		tmp = target.position;

		vp.x += (tmp.x - Pos.x ) * rand;
		vp.y += (tmp.y - Pos.y ) * rand;
		vp.z += (tmp.z - Pos.z ) * rand;

		Pos.x += vp.x;
		Pos.y += vp.y;
		Pos.z += vp.z;

		vp.x *= 0.96f;
		vp.y *= 0.96f;
		vp.z *= 0.96f;	
	}

	void Update(){
		this.transform.position = Pos;
	}
}