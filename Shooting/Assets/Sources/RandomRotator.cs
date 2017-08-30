using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	float tumble = 5;

	void Start () {
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * tumble;
			//insideUnitSphere은 회전각의 방향을 랜덤하게 만듬
	}


}
