using UnityEngine;
using System.Collections;

public class Soldadonse : MonoBehaviour {
	public float tiempoDeSoldadura;
	[SerializeField] bool estaSoldandose = false;
	[SerializeField] bool arreglado = false;

	void OnEnable()
    {
		tiempoDeSoldadura = Random.Range(4.0f, 8.0f);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!arreglado)
		{
			if (estaSoldandose)
			{
				tiempoDeSoldadura -= Time.deltaTime;
			}

			if (tiempoDeSoldadura < 0)
			{
				arreglado = true; //flag protección de ejecución
				GameController.Instance.SendMessage("onFixed"); //avisar al controller que se arregló
				Destroy (gameObject.GetComponent<Soldadonse>()); //remueve el componente para evitar más soldadura
				
				
			}
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
			//GameController.Instance.HapxelController.Vibrate(GameController.Instance.HapxelController.Acc_Centro
		}
	}
}
