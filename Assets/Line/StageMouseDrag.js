public var camTransform: Transform;
public var lookTarget: Vector3 = new Vector3(0,0,0);

public var distance: float = 100;
public var distanceY: float = 5;


function Update () {
	// Mouse Interactive
	var _camera: Vector3 = new Vector3();
	 easePitch += (cameraPitch - easePitch) * 0.2;
	 easeYaw += (cameraYaw - easeYaw) * 0.2;
	 _camera.x = distance * Mathf.Sin(easeYaw * Mathf.PI/180);
	 _camera.z = distance * Mathf.Cos(easeYaw * Mathf.PI/180);
	 _camera.y = distanceY * easePitch;
	 
	 camTransform.position = _camera;
	 camTransform.LookAt(lookTarget);
	
}

function OnGUI()
{

	// mouse
	var currentEvent: Event = Event.current;
	if(currentEvent.isMouse){
		if(currentEvent.type == EventType.MouseDown){
			Debug.Log("MOUSE_DOWN");
			_OnMouseDown(currentEvent);
		}
		if(currentEvent.type == EventType.MouseUp){
			_OnMouseUp();
		}
		
		if(_isMouseDown){
			_OnMouseMove(currentEvent);
		}
	}
}


 // ----------------------------------------------
 // Mouse Interactive
 // ----------------------------------------------
 
private var isOribiting: boolean;
private var cameraPitch: float = 10;
private var cameraYaw: float = 90;
private var previousMouseX: float;
private var previousMouseY: float;
private var easePitch: float = 270;
private var easeYaw: float = 90;

public var minCameraPitch: float = -10.0;

private var _isMouseDown: boolean = false;
 
function _OnMouseDown(currentEvent: Event) {
	var stageX: float = currentEvent.mousePosition.x;
	var stageY: float = currentEvent.mousePosition.y;
	isOribiting = true;
	previousMouseX = stageX;
	previousMouseY = stageY;

	_isMouseDown = true;
}

function _OnMouseUp():void {
	isOribiting = false;
	
	_isMouseDown = false;
}

private function _OnMouseMove(currentEvent: Event):void {
	
	var stageX: float = currentEvent.mousePosition.x;
	var stageY: float = currentEvent.mousePosition.y;
	var differenceX: float = stageX - previousMouseX;
	var differenceY: float = stageY - previousMouseY;
	
	if(isOribiting) {
	    cameraPitch += differenceY * 0.25;
	    cameraYaw += differenceX * 0.25;
	    
	    cameraPitch = Mathf.Max(minCameraPitch, Mathf.Min(cameraPitch, 360));
	
	    previousMouseX = stageX;
	    previousMouseY = stageY;
	}
}
