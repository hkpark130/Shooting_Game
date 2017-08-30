using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject[] hazards;
	public float startWait = 1;
	public float spawnWait = 0.75f;
	public float waveWait = 2;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	int score;
	bool isGameOver = false;
	bool reStart = false;

	void Start () {
		StartCoroutine (SpawnWaves());
		restartText.text = "";
		gameOverText.text = "";
		updateScore ();
		reStart = false;

	}

	public void gameOver(){
		gameOverText.text = "Game Over";
		isGameOver = true;
	}

	public void addScore(int newScore){
		score += newScore;
		updateScore ();
	}

	void updateScore(){
		scoreText.text = "Score : "+score;
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		//1초 대기
		while(true){
			for(int i = 0; i<10 ;i++)
			{
				GameObject hazard = hazards[Random.Range(0,hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range(-5,5),5,16);
				Quaternion spawnRotation = Quaternion.Euler (new Vector3 (0, 180, 0));
				//적 비행기 180도 회전해서 생성
				Instantiate(hazard,spawnPosition,spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if(isGameOver){
				restartText.text = "다시 시작하시려면 \n'R'키를 눌러주세요. \n Press 'R' for Restart";
				reStart = true;
				break;
			}
		}
	}


	void Update () {
		if(reStart){
			if(Input.GetKeyDown(KeyCode.R) ){
				Application.LoadLevel (Application.loadedLevel);
			}//키보드 R키를 눌렀을 때
		}
	}
}
