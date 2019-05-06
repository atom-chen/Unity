using UnityEngine;
using System.Collections;

public class spwan_array : MonoBehaviour {

	public float spawnTime = 1f;            // How long between each spawn.
	public GameObject appleReference;
	public int mColorInt = 1;
	//public static spwan_array SP;
	int mCounter=0;
	void Awake () {
	//	SP = this;	
		mCounter = 0;

	//	int t1 = MyMusicHero.SP.CheckMusic(1,1);


	}

	void Start () {		
		InvokeRepeating("SpawnFruit", spawnTime, spawnTime);  // add apple
	}

	void Update () {
	
	}


	void SpawnFruit()
	{
		if (MyMusicHero.SP.CheckMusic(mCounter,mColorInt)==1) {
			Vector3 t1 = transform.position;
			GameObject fruit = Instantiate (appleReference, t1, Quaternion.identity) as GameObject;
		}
		mCounter = mCounter + 1;
	} 

}
