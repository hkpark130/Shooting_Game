using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	GameObject gameController;

	void Start () {
		gameController = GameObject.Find ("GameController");
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "enemy"){
			return;
		}

		if(explosion != null){
			Instantiate (explosion, transform.position, transform.rotation);
		}

		if(other.gameObject.tag == "player"){
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GetComponent<GameController> ().gameOver ();
		}
			
		gameController.GetComponent<GameController> ().addScore (10);

		Destroy (gameObject);		//자기 자신 삭제
		Destroy (other.gameObject);	//부딪친 객체 삭제

	}//충돌이 발생할 때 누구와 했는지 알려줌.

}
