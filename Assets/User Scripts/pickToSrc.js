#pragma strict

var objectPos : Vector3;
var objectRot : Quaternion;
var pickObj : GameObject;

var canpick=true;
var picking=false;
var carrying=false;
var guipick = false;
var pickref : GameObject;

function Start () {
    pickref = GameObject.FindWithTag("pickUpRef");
    pickObj = pickref;
}

function Update () {
    var raycheck: Ray=Camera.main.ScreenPointToRay(Input.mousePosition);
    var hitcheck: RaycastHit;

    if(Physics.Raycast(raycheck,hitcheck,3) && hitcheck.collider.gameObject.tag == "pickUp") {
        guipick=true;
    }

    if(Physics.Raycast(raycheck,hitcheck) && hitcheck.collider.gameObject.tag!="pickUp"){
        guipick=false;
    }

    objectPos = transform.position;
    objectRot = transform.rotation;

    if(Input.GetKeyDown("e") && canpick) {
        picking=true;
        
        var ray: Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        var hit: RaycastHit;

        if(Physics.Raycast(ray,hit,3) && hit.collider.gameObject.tag=="pickUp"){
            pickObj=hit.collider.gameObject;
            hit.rigidbody.useGravity=false;
            hit.rigidbody.isKinematic=true;
            hit.collider.isTrigger=true;
            hit.transform.parent=gameObject.transform;
            hit.transform.position=objectPos;
            hit.transform.rotation=objectRot;
            carrying=true;
        }
    }

    if(Input.GetKeyUp("e") && picking && carrying) {
        picking=false;
        canpick=false;
    }

    if(Input.GetKeyUp("e") && picking)
    {
        picking=false;
    }

    if(Input.GetKeyDown("e") && !canpick && pickObj.GetComponent(pickedUpObj).refusethrow!=true && carrying) {
        canpick=true;
        pickObj.GetComponent.<Rigidbody>().useGravity=true;
        pickObj.GetComponent.<Rigidbody>().isKinematic=false;
        pickObj.transform.parent=null;
        pickObj.GetComponent.<Collider>().isTrigger=false;
        pickObj=pickref;
        carrying=false;
    }
}


function OnGUI() {
    GUI.Label (Rect(Screen.width/2,Screen.height/2+10,Screen.width/2,Screen.height/2), "X");

    if(guipick && canpick){
        GUI.Label(Rect(Screen.width/2,Screen.height/2+20,Screen.width/2,Screen.height/2),"Pick Up");
    }
}
