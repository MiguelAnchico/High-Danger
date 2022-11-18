using UnityEngine;
using System.Collections;

public class Soldadonse : MonoBehaviour {
	public float tiempoDeSoldadura;
	private bool estaSoldandose;

	// Use this for initialization
	void Start () {
		tiempoDeSoldadura = Random.Range(4.0f, 8.0f);
		estaSoldandose = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (estaSoldandose) {
			tiempoDeSoldadura -= Time.deltaTime;
			//Debug.Log(tiempoDeSoldadura);
		}

		if (tiempoDeSoldadura < 0) {
			GameController.Instance.SendMessage("prueba");
			Destroy (this.gameObject);
		}

	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Soldador")){
			estaSoldandose = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.gameObject.CompareTag("Soldador")){
			estaSoldandose = false;
		}
	}
}
