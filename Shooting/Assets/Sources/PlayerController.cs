using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	float speed = 7;
	float tilt = 5;
	public GameObject shot;
	public Transform firePosition;

	void Start () {

	}

	void Update(){
		if(Input.GetButtonDown("Fire1") ){
			Instantiate (shot,firePosition.position,firePosition.rotation);
		}
		//Fire1이 오른쪽 ctrl키 임


	}//키보드 입력 이벤트 담당

	void FixedUpdate () {
		float dirX = Input.GetAxis("Horizontal");
		float dirY = Input.GetAxis("Vertical");

		//Rigidbody컴포넌트에 접근
		Vector3 movement = new Vector3(dirX, 0, dirY);	//x,y,z순으로 매개변수 입력

		GetComponent<Rigidbody>().velocity = movement * speed;	//이동 = 방향 * spreed
		GetComponent<Rigidbody>().rotation = Quaternion.Euler(0,0,GetComponent<Rigidbody>().velocity.x * -tilt);

	}//물리이동 처리함수
}
