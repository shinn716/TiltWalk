public var tX: float = 0;
public var tY: float = 0;
public var tZ: float = 0;

public var xs: float = 0;
public var ys: float = 0;
public var zs: float = 0;

public var vx: float = 0;
public var vy: float = 0;
public var vz: float = 0;

public var a: float = 0.03;

public var targetTrans: Transform;

private var trans: Transform;

public var dd: float = 0.96;

function Awake()
{
	trans = this.gameObject.transform;
	a =  0.03 + Random.value * 0.03;
}

function FixedUpdate () {
	tX = targetTrans.position.x;
	tY = targetTrans.position.y;
	tZ = targetTrans.position.z;
	
	xs += vx += (tX - xs ) * a;
	ys += vy += (tY - ys ) * a;
	zs += vz += (tZ - zs ) * a;
	vx *= dd;
    vy *= dd;
    vz *= dd;
}
function Update()
{
	trans.position = new Vector3(xs, ys, zs);
}