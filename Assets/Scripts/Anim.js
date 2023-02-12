#pragma strict
var frames : Texture2D[];
var framesPS = 12.0;
function Update () {
	var index : int = Time.time*framesPS;
	index = index % frames.length;
	GetComponent.<Renderer>().material.mainTexture = frames[index];
}
