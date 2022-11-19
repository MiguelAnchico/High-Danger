using UnityEngine;
using System.Collections;

public class SongController : MonoBehaviour {
	public static SongController Instance;
	public AudioSource[] audios;
	public AudioClip[] songs;

	private int SonidoAmbiente;
	private int SonidoElectrocucion;
	private int SonidoDeMuerte;
	private int SonidoSoldar;
	private int SonidoViento;

	// Use this for initialization
	void Start () {
		SonidoAmbiente = 0;
		SonidoElectrocucion = 1;
		SonidoDeMuerte = 2;
		SonidoSoldar = 3;
		SonidoViento = 4;

		audios [SonidoAmbiente].clip = songs [SonidoAmbiente];
		audios [SonidoElectrocucion].clip = songs [SonidoElectrocucion];
		audios [SonidoDeMuerte].clip = songs [SonidoDeMuerte];
		audios [SonidoSoldar].clip = songs [SonidoSoldar];
		audios [SonidoViento].clip = songs [SonidoViento];

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void playSound(int audioPosition){
		
		audios [audioPosition].Play ();
	}

	void stopSound(int audioPosition){
		audios[audioPosition].Stop ();
	}
}
