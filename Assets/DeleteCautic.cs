using UnityEngine;
using System.Collections;

public class DeleteCautic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("DeleteZone")){
			GameObject.Find ("GeneratorCautic").GetComponent<GeneratorCauticLogic>().Generate();
			Destroy (this.gameObject);
		}
	}
}
