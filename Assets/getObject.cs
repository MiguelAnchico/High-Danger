using UnityEngine;
using System.Collections;

public class getObject : MonoBehaviour {

	public GameObject objectToTake;

	// Use this for initialization
	void Start () {
		objectToTake = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Agarrable") && objectToTake == null){
			objectToTake = other.gameObject;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(GameObject.ReferenceEquals(objectToTake, other.gameObject)){
			objectToTake = null;
		}
	}
}
