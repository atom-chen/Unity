using UnityEngine;
using System.Collections;

public class MyMusicHero : MonoBehaviour {

	int[,] array2D = new int[,]
	         {{1,1,1 },
		      {1,0,0 },
		      {0,1,0 },
		      {0,0,1 },
		      {1,1,0 },
		      {0,0,1 }};
	public static MyMusicHero SP;

	public GUISkin customSkin ;
	public int mCounter=0;
	public int mScore=0;
	private bool isGameOver=false;
	public Texture TextureClock;
	public Texture TextureScore;
	private AudioSource audioSource;
	public AudioClip audio1;
	public AudioClip audio2;
	public AudioClip audio3;


	void Awake () {
		SP = this;

	}

	// Use this for initialization
	void Start () {
		mScore = 0;
		mCounter = 0;
		audioSource = gameObject.AddComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray,out hit, 100)){
				//Vector3 screenPos =Input.mousePosition;
				GameObject otherObj= hit.collider.gameObject;
				if(otherObj.tag=="point"){
					if(otherObj.transform.position.z<1 && 
					   otherObj.transform.position.z>-1){
						mScore=mScore+1;
						if(otherObj.name=="Prefab_Red(Clone)"){
							audioSource.PlayOneShot(audio1); 
						}else if(otherObj.name=="Prefab_Green(Clone)"){
							audioSource.PlayOneShot(audio2); 
						}else if(otherObj.name=="Prefab_Blue(Clone)"){
							audioSource.PlayOneShot(audio3); 
						}

						
						Destroy(otherObj);      

					}
				}
			}
		}
	}
	public int CheckMusic(int Row, int ColorNumer){
		int t_row = array2D.GetLength(0);
		Debug.Log (t_row);
		Debug.Log (Row);
		if (Row >= t_row) {
			return 0;
		} 
		if(array2D[Row,ColorNumer]==1){
			mCounter=mCounter+1;
		}
		return array2D[Row,ColorNumer];
	}
	void OnGUI(){
		GUI.skin = customSkin;
		if (isGameOver == true){
			int buttonWidth = 100;
			int buttonHeight = 50;
			int buttonX = (Screen.width - buttonWidth ) / 2;
			int buttonY = (Screen.height - buttonHeight ) / 2;
			if ( GUI.Button(new Rect( buttonX, buttonY, buttonWidth,
			                         buttonHeight ), "Game Over" ) )
			{
				Application.LoadLevel(Application.loadedLevelName);
			}
		}
		GUI.Label(new Rect( 80, 25, 100, 60 ), mCounter.ToString() );
		GUI.Label(new Rect( Screen.width-35, 25, 100, 60 ),mScore.ToString() );
		GUI.DrawTexture(new Rect(10, 10, 60, 60), TextureScore,ScaleMode.ScaleToFit, true, 1.0F);
		GUI.DrawTexture (new Rect (Screen.width - 100, 10, 60, 60), TextureClock, ScaleMode.ScaleToFit, true, 1.0F);
	}
}
