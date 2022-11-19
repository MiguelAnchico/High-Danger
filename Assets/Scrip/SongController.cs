using UnityEngine;
using System.Collections;

public class SongController : MonoBehaviour {
	public AudioSource[] audios;

	public int SonidoAmbiente;
	public int SonidoElectrocucion;
	public int SonidoDeMuerte;
	public int SonidoSoldar;
	public int SonidoViento;
	public int SonidoSucces;

	// Use this for initialization
	void Start () {
		audios = this.GetComponents<AudioSource> ();
		SonidoAmbiente = 0;
		SonidoElectrocucion = 1;
		SonidoDeMuerte = 2;
		SonidoSoldar = 3;
		SonidoViento = 4;
		SonidoSucces = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playSound(int audioPosition){
		if (!audios [audioPosition].isPlaying) {
			audios [audioPosition].Play ();
		}

	}

	public void stopSound(int audioPosition){
		audios[audioPosition].Stop ();
	}
}
