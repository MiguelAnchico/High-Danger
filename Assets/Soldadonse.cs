using UnityEngine;
using System.Collections;

public class Soldadonse : MonoBehaviour {
	public float tiempoDeSoldadura;
	[SerializeField] bool estaSoldandose = false;
	[SerializeField] bool arreglado;

	void OnEnable()
    {
		tiempoDeSoldadura = Random.Range(4.0f, 8.0f);
	}
	// Use this for initialization
	void Start () {
		arreglado = false;
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
				GameController.Instance.SongController.stopSound(GameController.Instance.SongController.SonidoSoldar); //detener soldadua
				guantes Hapxel = GameController.Instance.HapxelController;
				Hapxel.VibrateEspc(Hapxel.Acc_Indices, Hapxel.VibracionCorta, 0); //vibración de aprobado
				GameController.Instance.SongController.playSound(5);
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
			GameController.Instance.SongController.playSound(GameController.Instance.SongController.SonidoSoldar);
			guantes Hapxel = GameController.Instance.HapxelController;
			Hapxel.VibrateEspc(Hapxel.Acc_Indices, Hapxel.VibracionCorta, 0);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.gameObject.CompareTag("Soldador")){
			estaSoldandose = false;
			GameController.Instance.SongController.stopSound(GameController.Instance.SongController.SonidoSoldar);
			
		}
	}
}
