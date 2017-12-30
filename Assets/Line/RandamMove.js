
private var moveObj: GameObject;

function Start()
{
	moveObj = this.gameObject;
	
	_startRandomMov();
}

function Update () {
	if(Input.GetKey("r")){
		_randomPosTween();
	}
}

private function _startRandomMov()
{
	_randomPosTween();
}

private function _randomPosTween(): void
{
	var easeType = iTween.EaseType.easeInOutSine;
	var toVec: Vector3 = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));

	iTween.MoveTo(moveObj, {
		"position":toVec, "time":0.5, "easetype":easeType,
		"oncompletetarget":this.gameObject, "oncomplete":"_postionComplete"
	});
	
}

private function _postionComplete()
{
	_randomPosTween();
}
