#pragma strict

var refusethrow=false;

function Start () {

}

function Update () {

}

function OnTriggerEnter(other : Collider) {
    if(other.gameObject.tag != "Player" && other.gameObject.tag!="pickTo")
        refusethrow=true;
}

    function OnTriggerExit (other : Collider) {
        if(other.gameObject.tag != "Player" && other.gameObject.tag!="pickTo")
            refusethrow=false;
    }