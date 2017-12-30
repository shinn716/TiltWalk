using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Motion{

	public GameObject whichobj;
	public GameObject target;
	public float time;

	public void init(){
		whichobj.AddComponent<LineScript_CS> ();
		whichobj.GetComponent<LineScript_CS> ().target = target.transform;
		whichobj.GetComponent<LineScript_CS> ().time = time;

	}

}

public enum tiltshader{
	Stream,
	Fire,
	ChormaticWave,
	Disco,
	Electricity,
	Highlighter,
	HyperGrid,
	Ink,
	NeonPulse,
	Plasma,
	Rainbow,
	SoftHighlighter,
	Waveform,
	None
}


public class MainController : MonoBehaviour {

	public tiltshader _tilt;
	public List<Motion> Movelines;
	Material _mat;
	public Material[] shader;
	public Transform target;

	Vector3 pos;

	void Start () {

		for(int i=0; i<Movelines.Count; i++){
			Movelines [i].init();
		}
			

	}

	void Update(){


		pos = Vector3.Lerp (pos, target.position, Time.deltaTime);
		this.transform.LookAt (pos);


		ShaderSelect ();
		for(int i=0; i<Movelines.Count; i++)
			Movelines [i].whichobj.GetComponent<TrailRenderer> ().material = _mat;
	}



	void ShaderSelect(){
		switch(_tilt){
			
		default:
			_mat = shader[13];
			break;

		case tiltshader.Stream:
			_mat = shader[0];
			break;
		case tiltshader.Fire:
			_mat = shader[1];
			break;
		case tiltshader.ChormaticWave:
			_mat = shader[2];
			break;
		case tiltshader.Disco:
			_mat = shader[3];
			break;
		case tiltshader.Electricity:
			_mat = shader[4];
			break;
		case tiltshader.Highlighter:
			_mat = shader[5];
			break;
		case tiltshader.HyperGrid:
			_mat = shader[6];
			break;
		case tiltshader.Ink:
			_mat = shader[7];
			break;
		case tiltshader.NeonPulse:
			_mat = shader[8];
			break;
		case tiltshader.Plasma:
			_mat = shader[9];
			break;
		case tiltshader.Rainbow:
			_mat = shader[10];
			break;
		case tiltshader.SoftHighlighter:
			_mat = shader[11];
			break;
		case tiltshader.Waveform:
			_mat = shader[12];
			break;

		}
	}
}
