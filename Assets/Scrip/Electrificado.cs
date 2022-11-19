using UnityEngine;
using System.Collections;

public class Electrificado : MonoBehaviour {
	public float tiempoCargaElectrica, tiempoDescanso;
	float descansoMax = 16f, descansoMin = 10f;
	float cargaMax = 3f, cargaoMin = 1.5f;

	public bool isElectrificado, isHandsInside, isDanado;
	private SongController SongController;

	// Use this for initialization
	void Start () {
		tiempoDescanso = Random.Range(descansoMin, descansoMax);
		tiempoCargaElectrica = Random.Range(cargaoMin, cargaMax);
		isElectrificado = isHandsInside = isDanado = false;
		SongController = GameController.Instance.SongController.GetComponent<SongController> ();
	}
	
	// Update is called once per frame
	void Update () {
        if(isDanado){
			tiempoDescanso -= Time.deltaTime;
			if(tiempoDescanso < 3 && tiempoDescanso > -1.5f) {
				guantes Hapxel = GameController.Instance.HapxelController;
				Hapxel.VibrateEspc(Hapxel.Acc_Centro, Hapxel.VibracionCorta, 0);
			}
			if (tiempoDescanso < 0) {
				tiempoCargaElectrica -= Time.deltaTime;
				SongController.playSound(SongController.SonidoElectrocucion);

				if (isHandsInside)
				{
					SongController.stopSound(SongController.SonidoElectrocucion);
					SongController.playSound(SongController.SonidoDeMuerte);
					GameController.Instance.gameOver();
					GameController.Instance.HapxelController.checkVibrar = true;
				}
				if (tiempoCargaElectrica < 0)
				{
					SongController.stopSound(SongController.SonidoElectrocucion);
					tiempoDescanso = Random.Range(descansoMin, descansoMax);
					tiempoCargaElectrica = Random.Range(cargaoMin, cargaMax);
				}


			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Hand")) {
			isHandsInside = true;
		}


	}

	private void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Hand")) {
			isHandsInside = false;
		}

	}
}
