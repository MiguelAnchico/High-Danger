using UnityEngine;
using System.Collections;

public class MoveWithOculus : MonoBehaviour {
	public GameObject oculusReference;
	public Vector3 gap;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.oculusReference.transform.position + gap;
		//this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, oculusReference.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z);
	}
}
