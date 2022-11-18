using UnityEngine;
using System.Collections;

public class AdjustPosition : MonoBehaviour {
	public GameObject parent;
	public Vector3 gap;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.parent.transform.position + gap;
	}
}
