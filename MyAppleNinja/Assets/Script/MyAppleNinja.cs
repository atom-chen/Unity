using UnityEngine;
using System.Collections;

public class MyAppleNinja : MonoBehaviour
{


	public GUISkin customSkin ;



	public GameObject appleReference;
	public GameObject splashReference;
	private Vector3 throwForce = new Vector3(0, 18, 0);
	public int mCounter=20;
	public int mScore=0;
	private bool isGameOver=false;
	public Texture TextureClock;
	public Texture TextureScore;
	//
	public Color c1 = Color.yellow;
	public Color c2 = Color.red;
	
	private ArrayList lstNumbers = new ArrayList();
	private GameObject lineGO;
	private LineRenderer lineRenderer;
	private int i = 0;

	void Start()
	{
		isGameOver=false;

		mScore = 0;
		/////
		InvokeRepeating("ReduceTime", 1, 1);   // Counter

		///////////////////
		

		InvokeRepeating("SpawnFruit", 0.5f, 6);  // add apple

		
		//
		LineInit ();

	}
	void LineInit(){

		lineGO = new GameObject("Line");
		lineGO.AddComponent<LineRenderer>();
		lineRenderer = lineGO.GetComponent<LineRenderer>();
	//	lineRenderer.material = new Material(Shader.Find("Mobile/Particles/Additive"));
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));

		lineRenderer.SetColors(c1, c2);
		lineRenderer.SetWidth(0.02f, 0.01f);
		lineRenderer.SetVertexCount(0);



	}
	
	void Update()
	{


		if (Input.GetMouseButton(0))
		{
		

			/*
			lineRenderer.SetVertexCount(i+1);
			//Vector3 mPosition = new Vector3(Input.mousePosition.x, 
			                  //              Input.mousePosition.y, -1);

			Vector3 mousePos=Input.mousePosition;
			
			mousePos.z = 1f;
			Vector3 mPosition = Camera.main.ScreenToWorldPoint(mousePos);

			//mPosition.z=1f;
			Debug.Log("x:"+mPosition.x+"   ,y:"+mPosition.y+"   ,z:"+mPosition.z);
		
			/*
			int i2 = 0;
			while (i2 < 20) {

				if(i2>10){
					mPosition = new Vector3(i2 * 0.5F, Mathf.Sin(i2 + Time.time), -1);
				}
				lineRenderer.SetPosition(i2, mPosition);
				i2++;
			}

		*/

			EventMouseDown(); //mPosition);
		}
		if (Input.GetMouseButtonUp(0)) {
			
			EventMouseUp();
		}

		DestoryAppls ();
	}
	void Drawline() {       
		//LineRenderer lineRenderer = GetComponent<LineRenderer>();     
		int t_len=lstNumbers.Count;
		
		if(t_len>0){
			lineRenderer.SetVertexCount(t_len);//lengthOfLineRenderer);
			
			//lineRenderer.Size=t_len;
			for(int a=0;a<t_len;a++){    
				Vector3 t1=(Vector3)lstNumbers[a];
				//t1.z=0;
				lineRenderer.SetPosition(a,t1);
			}
			
			
			if(t_len>20){
				lstNumbers.RemoveAt(0);
			}
			
		}
		
		
		
	}
	void DestoryAppls(){
		
		GameObject[] respawns;
		respawns = GameObject.FindGameObjectsWithTag("fruit");

		// GameObject	respawns[] = GameObject.FindGameObjectsWithTag("fruit");
		
		foreach (GameObject respawn in respawns) {
			
			Vector3 position = respawn.transform.position;
			if(position.y<-20){
				Destroy(respawn);
			}

		//	Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation) as GameObject;
		}
	}
	void EventMouseDown(){ //Vector3 mPosition){
		
		
		
		Vector3 mousePos=Input.mousePosition; //iPhoneInput.GetTouch(0).deltaPosition;
		// lineArray.Push(touchDeltaPosition);
		
		
		
		mousePos.z = 1f;
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		//Vector3 worldPos = ray.
		
		lstNumbers.Add(worldPos);//452.35);
		
		
		
		Drawline();


		/*
		int t_max=10;
		myPoints[i] = mPosition;
		i++;
		if (myPoints.Count > t_max) {
			for(int i3=t_max;i3<myPoints.Count;i3++){
				myPoints.RemoveAt(0);
			}
			EventMouseUp();
			i=0;
			for(int i4=0;i4<t_max;i4++){
				lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(myPoints[i4]));
			}
			i=10;
		}else{
			lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));
		}
		*/
	//	lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));


		/*

		lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));
		i++;
		*/
		// Add Collider 
		/*
		if (lstNumbers.Count > 0) {
			BoxCollider bc = lineGO.AddComponent<BoxCollider> ();
			bc.transform.position = lineRenderer.transform.position;
			bc.size = new Vector3 (1f, 1f, 1f);
		
			BoxCollider[] lineColliders = lineGO.GetComponents<BoxCollider> ();
		
			foreach (BoxCollider b in lineColliders) {
				Destroy (b);
			}
		}*/

		CheckgetFruit ();

	}
	
	void EventMouseUp(){
		/* Remove Line */
		CheckgetFruit ();

		
		lstNumbers.Clear ();
		lineRenderer.SetVertexCount(0);
		i = 0;
		
		/* Remove Line Colliders */

	}

	void SpawnFruit()
	{
		for (byte i2 = 0; i2 <  Random.Range(1, 7); i2++)
		{
			GameObject fruit = Instantiate(appleReference, new Vector3(Random.Range(-9, 9), Random.Range(-6, -11), 0), Quaternion.identity) as GameObject;
			fruit.GetComponent<Rigidbody>().AddForce(throwForce, ForceMode.Impulse);

			fruit.transform.Rotate(  Random.Range(-360, 360)  ,Random.Range(-360, 360)
			                       ,Random.Range(-360, 360) );


		}
	} 

	void ReduceTime()
	{
		if (mCounter >= 1) {
			mCounter = mCounter - 1; // (int.Parse(mCounter) - 1).ToString();

		} else {
			CancelInvoke();
			mCounter=0;
			isGameOver=true;
		}
	}
	
	void Reload()
	{
		Application.LoadLevel (Application.loadedLevel);
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
				// Print some text to the debug console
				Debug.Log("Thanks!");
			}
		}

		GUI.Label(new Rect( 80, 25, 100, 60 ), mCounter.ToString() );
		GUI.Label(new Rect( Screen.width-35, 25, 100, 60 ), mScore.ToString() );
		GUI.DrawTexture(new Rect(10, 10, 60, 60), TextureScore , ScaleMode.ScaleToFit, true, 1.0F);
		GUI.DrawTexture(new Rect(Screen.width-100, 10, 60, 60), TextureClock, ScaleMode.ScaleToFit, true, 1.0F);


	}


	void CheckgetFruit(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		
		
		if (Physics.Raycast (ray, out hit, 100f)) {
			//Debug.DrawRay (ray.origin, hit.point);
		//	Debug.Log("111");// (hit.collider.gameObject.name);
		//	Destroy (GameObject.Find (hit.collider.gameObject.name));
			if(hit.collider.tag=="fruit"){
				Destroy (hit.collider.gameObject);
				Vector3 randomPos=hit.collider.gameObject.transform.position;
				randomPos.z=-0.01f;
				mScore=mScore+1;
				Instantiate(splashReference, randomPos, hit.collider.gameObject.transform.rotation);
			}
		}
	}


}
