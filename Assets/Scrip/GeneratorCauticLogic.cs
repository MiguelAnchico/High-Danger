using UnityEngine;
using System.Collections;

public class GeneratorCauticLogic : MonoBehaviour {
	public float tiempoGenerate;
	private bool canGenerate;
	public GameObject Cautic;
	public Vector3 gap;

	// Use this for initialization
	void Start () {
		canGenerate = true;
	}
	
	// Update is called once per frame
	void Update () {
		tiempoGenerate -= Time.deltaTime;

		if (tiempoGenerate < 0 && canGenerate) {
			Generate ();
			canGenerate = false;
		}
	}

	public void Generate(){
		GameObject obj = Instantiate (Cautic);
		Vector3 newRotation = -this.gameObject.transform.rotation.eulerAngles;
		obj.transform.position = this.gameObject.transform.position + gap;
		obj.transform.eulerAngles = newRotation;
	}
}
