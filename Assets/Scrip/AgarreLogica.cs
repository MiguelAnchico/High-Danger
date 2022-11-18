using UnityEngine;
using System.Collections;

public class AgarreLogica : MonoBehaviour {

	private int contadorHembras;
	private GameObject Object;
	private GameObject ObjectTaken;
	public GameObject parentExit;
	public GameObject LeftHandTrigger;

	void Start () {
		contadorHembras = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("AgarreHembra")){
			contadorHembras++;
			Debug.Log ("Ajustado");
		}

		Object = LeftHandTrigger.GetComponent<getObject>().objectToTake;

		if (contadorHembras > 0) {
			if (Object != null) {
				Object.transform.parent = this.gameObject.transform;
				Object.GetComponent<BoxCollider> ().isTrigger = true;
				ObjectTaken = Object;
				Destroy (Object.GetComponent<Rigidbody> ());
			}
			//Destroy(this.gameObject.GetComponent<Rigidbody>());
		}
	}

	private void OnTriggerExit(Collider other)
	{
		
		if(other.CompareTag("AgarreHembra")){
			contadorHembras--;
		}



		if (contadorHembras == 0) {
			ObjectTaken.transform.parent = parentExit.transform;
			ObjectTaken.GetComponent<BoxCollider> ().isTrigger = false;
			ObjectTaken.AddComponent<Rigidbody> ();
			ObjectTaken = null;
		}

	}
}
