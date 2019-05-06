using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;


using System; //This allows the IComparable Interface

public class MyCrossyRoad : MonoBehaviour {
	public float moveSpeed;

	
	//public void Awake() { enabled = false; }
	
	float ClocKStartTime;
	float startTime, duration;
	Vector3 startPoint; //, endPoint;
	bool isMoving=false;
	Vector3 endPoint=new Vector3(0,0,0);
	Vector3 endPointMath=new Vector3(0,0,0);
	private bool isGameOver=false;
	private ArrayList lstNumbers = new ArrayList();

	private float tolerance=1;
	
	public int mCounter=0;
	public int mScore=0;

	public GUISkin customSkin ;
	public Texture TextureClock;
	public Texture TextureScore;

	// left , right
	Vector3 fingerStart;
	Vector3 fingerEnd;
	public enum Movement
	{
		Left,
		Right, 
		Up,
		Down
	};




	public List<Movement> movements = new List<Movement>();


	public void StartMove(Vector3 endPoint) {
		// pre calc all the lerp parameters
		isMoving=true;
		startPoint = transform.position;
		this.endPoint = endPoint;
		duration = (endPoint - startPoint).magnitude/moveSpeed;
		startTime = Time.time;
		
	//	enabled = true; // start updating the lerp
	}

	public void Moving() {

		float time = Time.time-startTime; // time since start
		//if(isGameOver==false){
		//	mCounter=(int) time;
		//}

		if(time/duration<1 && isMoving==true){
			//Debug.Log(time/duration);
			Vector3 t1 = Vector3.Lerp(startPoint, endPoint, time/duration);
			float t2=Mathf.Sin((time/duration)*4);
			if(t2<0) t2=0;
			transform.position =new Vector3(t1.x,t1.y+t2 , t1.z);
		}else if(isMoving==true){
			transform.position = Vector3.Lerp(startPoint, endPoint, time/duration);
			isMoving=false;
		}


		// full interpolation achieved
	//	if(time > duration) enabled = false;
	}  


	// Use this for initialization
	void Start () {
		gameObject.transform.position=new Vector3(0,1,0);
		endPointMath=new Vector3(0,0,0);
		isGameOver=false;
		isMoving=false;
		ClocKStartTime = Time.time;
	//	rigidbody.AddForce (Vector3.forward * 200);
	//	rigidbody.AddForce (Vector3.up  * 200);
		
	}
	public void JumpTo(Vector3 movePos){
		//Vector3 endPoint2=endPoint; //gameObject.transform.position;
		endPointMath.x=endPointMath.x+movePos.x;
		endPointMath.y=endPointMath.y+movePos.y;
		endPointMath.z=endPointMath.z+movePos.z;
		lstNumbers.Add(endPointMath);//452.35);
		
		/*
		JumpTo();
		
		if(isMoving==false){
			isMoving=true;
			StartMove(endPoint);
			
		}
*/
		
		
		
	}
	// Update is called once per frame
	void Update () {
		if(isGameOver==false){
			float t2=Time.time-ClocKStartTime; 
			mCounter =(int)t2; // time since start

			this.mScore=(int)gameObject.transform.position.z;
			Moving();

			if(isMoving==false){
				if(lstNumbers.Count>0){
					isMoving=true;
					Vector3 t1=(Vector3)lstNumbers[0];
					StartMove(t1);
					lstNumbers.RemoveAt(0);
				}
			}

			/////////left , right
			if (Input.GetMouseButtonDown(0)) {
				fingerStart = Input.mousePosition;
				fingerEnd  = Input.mousePosition;
			}
			//GetMouseButton instead of TouchPhase.Moved
			//This returns true if the LMB is held down in standalone OR
			//there is a single finger touch on a mobile device
			if(Input.GetMouseButton(0)) {
				fingerEnd = Input.mousePosition;
				
				//There was some movement! The tolerance variable is to detect some useful movement
				//i.e. an actual swipe rather than some jitter. This is the same as the value of 80
				//you used in your original code.
				if(Mathf.Abs(fingerEnd.x - fingerStart.x) > tolerance || 
				   Mathf.Abs(fingerEnd.y - fingerStart.y) > tolerance) {
					
					//There is more movement on the X axis than the Y axis
					if(Mathf.Abs(fingerStart.x - fingerEnd.x) > Mathf.Abs(fingerStart.y - fingerEnd.y)) {
						// left , right
						//Right Swipe
						if((fingerEnd.x - fingerStart.x) > 0){
							movements.Add(Movement.Right);
						//	Debug.Log("Right");
						//Left Swipe
						} else {
							movements.Add(Movement.Left);
						//	Debug.Log("Left");
						}
					}
					
					//More movement along the Y axis than the X axis
					else {
						// up , down
						//Upward Swipe
						if((fingerEnd.y - fingerStart.y) > 0){
							movements.Add(Movement.Up);
						//Downward Swipe
						}else{
							movements.Add(Movement.Down);
						}
					}
					
					//After the checks are performed, set the fingerStart & fingerEnd to be the same
					fingerStart = fingerEnd;
					
					//Now let's check if the Movement pattern is what we want
					//In this example, I'm checking whether the pattern is Left, then Right, then Left again
				}
			}
			
			//GetMouseButtonUp(0) instead of TouchPhase.Ended
			if(Input.GetMouseButtonUp(0)) {

				if((CheckForPatternMove(0, 3, new List<Movement>() { Movement.Left, Movement.Left, Movement.Left } ))==true){
					Debug.Log("Left");
					JumpTo(new Vector3(-2,0,0));
				}else if((CheckForPatternMove(0, 3, new List<Movement>() { Movement.Right, Movement.Right, Movement.Right } ))==true){
					Debug.Log("Right");
					
					JumpTo(new Vector3(2,0,0));
				}else if((CheckForPatternMove(0, 3, new List<Movement>() { Movement.Down, Movement.Down, Movement.Down } ))==true){
					Debug.Log("down");
					JumpTo(new Vector3(0,0,-2));
				}else{
					
					JumpTo(new Vector3(0,0,2));
				}


				fingerStart = Vector2.zero;
				fingerEnd = Vector2.zero;
				movements.Clear();
			}
			//////////////////



		}
	
	}


	
	private bool CheckForPatternMove (int startIndex, int lengthOfPattern, List<Movement> movementToCheck) {
		
		//If the currently stored movements are fewer than the length of the pattern to be detected
		//it can never match the pattern. So, let's get out
		if(lengthOfPattern > movements.Count){
			
			Debug.Log("a");
			return false;
		}
		
		//In case the start index for the check plus the length of the pattern
		//exceeds the movement list's count, it'll throw an exception, so lets get out
		if(startIndex + lengthOfPattern > movements.Count){
			
			Debug.Log("b");
			return false;
		}

		//Populate a temporary list with the respective elements
		//from the movement list
		List<Movement> tMovements = new List<Movement>();
		for(int i = startIndex; i < startIndex + lengthOfPattern; i++){
			tMovements.Add(movements[i]);
		}
		
		//Now check whether the sequence of movements is the same as the pattern you want to check for
		//The SequenceEqual method is in the System.Linq namespace
		return tMovements.SequenceEqual(movementToCheck);
	}




	void OnTriggerEnter(Collider other) {
		EventOnTrigger(other);
	}
	
	void OnTriggerStay(Collider other) {
		EventOnTrigger(other);
	}
	void EventOnTrigger(Collider other){
		if(isGameOver==false){
		//Destroy(other.gameObject);
		if(other.transform.tag=="car"){
			lstNumbers.Clear();

                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                GetComponent<Rigidbody>().isKinematic = true;

			//rigidbody.velocity = new Vector3(0, 0, 0);
			//rigidbody.isKinematic = true;  // doing phycis
			isMoving=false;
			isGameOver=true;
		//	Destroy(other.gameObject);
		}
		if(other.transform.tag=="tree"){
			
			lstNumbers.Clear();

                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                GetComponent<Rigidbody>().isKinematic = false;

			//rigidbody.velocity = new Vector3(0, 0, 0);
			//rigidbody.isKinematic = false;   // doing phycis
			isMoving=false;
			//rigidbody.AddForce (Vector3.forward * 200);
			//rigidbody.AddForce (Vector3.up  * 200);
		}
		}
		/*
		if(other.transform.name=="Plane_floor"){
			rigidbody.velocity = new Vector3(0, 0, 0);
			rigidbody.isKinematic = true;
			rigidbody.position=new Vector3(0,-0.83f,-6.56f);
		}
		if(other.transform.name=="Cube_Score"){
			mScore=mScore+1;
		}
		*/
	}
	
	void OnGUI(){
		
		
		GUI.skin = customSkin;
		
		
		if (isGameOver == true) {
			int buttonWidth = 100;
			int buttonHeight = 50;
			
			int buttonX = (Screen.width - buttonWidth ) / 2;
			int buttonY = (Screen.height - buttonHeight ) / 2;
			
			// Draw a button control in the center of the screen.
			if ( GUI.Button(new Rect( buttonX, buttonY, buttonWidth, buttonHeight ), "Game Over" ) )
			{
			//	Application.LoadLevel(Application.loadedLevelName);
				// Print some text to the debug console
			//	Debug.Log("Thanks!");
			}else if(GUILayout.Button("Play again"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
		}
		
		GUI.Label(new Rect( 80, 25, 100, 60 ), mCounter.ToString() );
		GUI.Label(new Rect( Screen.width-35, 25, 100, 60 ), mScore.ToString() );
		GUI.DrawTexture(new Rect(10, 10, 60, 60), TextureScore , ScaleMode.ScaleToFit, true, 1.0F);
		GUI.DrawTexture(new Rect(Screen.width-100, 10, 60, 60), TextureClock, ScaleMode.ScaleToFit, true, 1.0F);
		
		
	}

	
}
