using UnityEngine;
using System.Collections;

public class GeneratorCauticLogic : MonoBehaviour {

	public GameObject Cautic;

	// Use this for initialization
	void Start () {
		Generate ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Generate(){
		Instantiate (Cautic);
	}
}
