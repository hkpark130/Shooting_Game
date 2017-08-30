using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform firePosition;

	void Start () {
		InvokeRepeating ("Fire",1,2);
	}

	void Fire(){
		Instantiate (shot, firePosition.position, firePosition.rotation);
		//여기서 transform.position은 enemyShip의 transform.position임.
		//Instantiate는 복사? 생성?

	}
		
}
