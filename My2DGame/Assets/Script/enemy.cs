// 柯博文老師 www.powenko.com
using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	public float speed=1f;
	public int  score=1;


	void Update () {
		Vector3 t_position=gameObject.transform.position;
		t_position.x=t_position.x-(speed *Time.deltaTime);
		gameObject.transform.position=t_position;

	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.name=="player_Sprite"){
			FunSetScore(-1);
		}else if(other.gameObject.name=="bulet_Sprite"){
			FunSetScore(score);
			Destroy(other.gameObject);
		}
		Destroy(gameObject);
	}
	void FunSetScore(int t_num){
		GameObject t_player_Sprite = GameObject.Find("player_Sprite");
		if(t_player_Sprite!=null){
			game t_game = t_player_Sprite.GetComponent<game>(); 
			if(t_num==-1){
				t_game.Score=-1;
			}else{
				t_game.Score++;
			}
		}
	}
}
