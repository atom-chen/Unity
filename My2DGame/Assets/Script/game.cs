// 柯博文老師 www.powenko.com
using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {
	public int Score=0;
	public GameObject bulet_Sprite;
	public GameObject enemy_Sprite;
	// Use this for initialization
	void Start () {
		mMainCamera = GameObject.Find("Main Camera");
		for(int i=0;i<40;i++){
			Vector3 position =new Vector3(Random.Range(5.0f, 52.0f), Random.Range(3.3f, -2.5f),0);
			GameObject enemy  = Instantiate(enemy_Sprite, position, Quaternion.identity )  as GameObject;
			enemy.transform.Rotate(0,180f,0);
			
		}
	}
	GameObject mMainCamera;
	//	GameObject projectile ;
	public float fireRate = 1f;
	float nextFire  = 2f;
	
	Vector2 speed = new Vector2(200, 200);
	float CameraSpeed=0.5f;
	// 2 - Store the movement
	private Vector2 movement;
	
	void Update()
	{
		
		if(Score>=0){
			float inputX = Input.GetAxis("Horizontal");
			float inputY = Input.GetAxis("Vertical");
			
			movement = new Vector2(
				speed.x * inputX *Time.deltaTime,
				speed.y * inputY*Time.deltaTime);

			if (Input.GetButton ("Fire1") && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				GameObject clone  = Instantiate(bulet_Sprite, transform.position, transform.rotation) as GameObject;
				clone.name="bulet_Sprite";
			}
			Fun_MoveCamera();
		}
		
	}
	void Fun_MoveCamera(){
		if(mMainCamera!=null){
			Vector3 tMainCameraVector3=mMainCamera.gameObject.transform.position;
			Vector3 tgameObjectaVector3=gameObject.transform.position;
			tMainCameraVector3.z=-8;
			
			float t1=tMainCameraVector3.x;
			
			t1=t1+(CameraSpeed *Time.deltaTime);
			tMainCameraVector3.x=t1;
			
			tMainCameraVector3.y=tgameObjectaVector3.y;
			mMainCamera.gameObject.transform.position=tMainCameraVector3;
			
		}
	}
	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = movement;
		Vector3 tgameObjectaVector3=gameObject.transform.position;
		if(tgameObjectaVector3.y>3.3f){
			tgameObjectaVector3.y=3.3f;
		}
		if(tgameObjectaVector3.y<-2.9f){
			tgameObjectaVector3.y=-2.9f;
		}
		
		Vector3 tMainCameraVector3=mMainCamera.gameObject.transform.position;
		if(tgameObjectaVector3.x>(tMainCameraVector3.x+3.8f)){
			tgameObjectaVector3.x=(tMainCameraVector3.x+3.8f);
		}
		if(tgameObjectaVector3.x<(tMainCameraVector3.x-6f)){
			tgameObjectaVector3.x=(tMainCameraVector3.x-6f);
		}
		
		
		gameObject.transform.position=tgameObjectaVector3;
	}
	
	void OnGUI(){
		if(Score<0){
			GUI.Label (new Rect (10, 10, 100, 20), "Game Over");
		}else{
			GUI.Label (new Rect (10, 10, 100, 20), "Score:"+Score);
		}
	}
}
