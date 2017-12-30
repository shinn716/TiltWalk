using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove_CS : MonoBehaviour {

	public GameObject Target;
	public float time;
	public iTween.EaseType easeType;
	public Vector2 MoveRange_X;
	public Vector2 MoveRange_Y;
	public Vector2 MoveRange_Z;

	[Space]
	[Header ("Random")]
	public bool isRandom;


	[Space]
	[Header ("PerlinNoise")]
	public bool isPerlinNoise;
	public float scalex = 1;
	public float scaley = 2;
	public float scalez = 3;
	public float seed;
	Vector3 toVec;

	void OnEnable () {
		Target = this.gameObject;
		_startRandomMov();
	}

	void _startRandomMov()
	{
		_randomPosTween();
	}

	void _randomPosTween()
	{

		if (isRandom && isPerlinNoise) {
			Debug.LogError("Both isRandom and isPerlinNoise is true. Please Reset. ");
			toVec = Vector3.zero;
		}

		else if (isRandom)
			toVec = new Vector3 (Random.Range (MoveRange_X.x, MoveRange_X.y), 
							     Random.Range (MoveRange_Y.x, MoveRange_Y.y), 
								 Random.Range (MoveRange_Z.x, MoveRange_Z.y));
		
		else if (isPerlinNoise) {
			Vector3 BaseValue = new Vector3(MoveRange_X.x, MoveRange_Y.x, MoveRange_Z.x);


			if(BaseValue.x> 0 )
				BaseValue.x =  MoveRange_X.x + (MoveRange_X.y-MoveRange_X.x)  * Mathf.PerlinNoise (seed + Time.time * scalex, seed + 0.0f);
			else
				BaseValue.x = MoveRange_X.x + MoveRange_X.y * Mathf.PerlinNoise (seed + Time.time * scalex, seed + 0.0f);
				


			if(BaseValue.y> 0 )
				BaseValue.y = MoveRange_Y.x + (MoveRange_Y.y-MoveRange_Y.x) * Mathf.PerlinNoise (seed + Time.time * scaley, seed + 0.0f);
			else
				BaseValue.y = MoveRange_Y.x + MoveRange_Y.y * Mathf.PerlinNoise (seed + Time.time * scaley, seed + 0.0f);



			if(BaseValue.z > 0 )
				BaseValue.z = MoveRange_Z.x + (MoveRange_Z.y-MoveRange_Z.x)  * Mathf.PerlinNoise (seed + Time.time * scalez, seed + 0.0f);
			else
				BaseValue.z = MoveRange_Z.x + MoveRange_Z.y  * Mathf.PerlinNoise (seed + Time.time * scalez, seed + 0.0f);


			toVec = new Vector3 (BaseValue.x, BaseValue.y, BaseValue.z);
		}
		else
			toVec = Vector3.zero;


		iTween.MoveTo (Target, iTween.Hash (
			"position", toVec, 
			"time", time, 
			"easetype", easeType,
			"oncompletetarget", this.gameObject, 
			"oncomplete", "_postionComplete"
		));

	}

	void _postionComplete()
	{
		_randomPosTween();
	}

}