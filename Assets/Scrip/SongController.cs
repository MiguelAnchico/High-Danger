using UnityEngine;
using System.Collections;

public class SongController : MonoBehaviour {
	public static SongController Instance;
	public AudioSource[] audios;

	public int SonidoAmbiente;
	public int SonidoElectrocucion;
	public int SonidoDeMuerte;
	public int SonidoSoldar;
	public int SonidoViento;

	// Use this for initialization
	void Start () {
		audios = this.GetComponents<AudioSource> ();
		SonidoAmbiente = 0;
		SonidoElectrocucion = 1;
		SonidoDeMuerte = 2;
		SonidoSoldar = 3;
		SonidoViento = 4;

		Debug.Log (this.GetComponents<AudioSource> ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playSound(int audioPosition){
		Debug.Log (audios[audioPosition].clip);
		//audios [audioPosition].Play ();
	}

	public void stopSound(int audioPosition){
		audios[audioPosition].Stop ();
	}
}
