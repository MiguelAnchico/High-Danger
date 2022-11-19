using UnityEngine;
using System.Collections;

public class GeneratorCauticLogic : MonoBehaviour {

	public GameObject Cautic;
	public Vector3 gap;

	// Use this for initialization
	void Start () {
		Generate ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Generate(){
		GameObject obj = Instantiate (Cautic);
		Vector3 newRotation = -this.gameObject.transform.rotation.eulerAngles;
		obj.transform.position = this.gameObject.transform.position + gap;
		obj.transform.eulerAngles = newRotation;
	}
}
