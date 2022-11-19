using UnityEngine;
using System.Collections;

public class reintentar : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		GameController.Instance.resetear ();
	}
}
