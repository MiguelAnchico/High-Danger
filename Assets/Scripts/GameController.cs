using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[Header("Settings")]
	public GameObject player, electrocutador, pantallago;
	public static GameController Instance;
	public guantes HapxelController;
	public GameObject SongOBJ;
	public SongController SongController;
	public bool activo = false;
	[Header("Game")]
	public GameObject[] aisladores;
	public Material ceramica, dañado;
	[SerializeField] List<int> escogidos = new List<int>();
	public GameObject aisladorActual;
	[Header("Game Control")]
	public bool isGame;

	void Awake() {
		if (Instance == null )
		{
			Instance = this;
			//DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this);
		}
	}
	void Start () {
		//inicializar variables
		isGame = false;
		//asignar controladores hijos
		HapxelController = gameObject.GetComponent<guantes>();
		SongController = SongOBJ.GetComponent<SongController>();

		//ejecutar audio historia
		//activar entorno 
		//preparar aleatorios
		repairStart();

		//activar cautil

	}
	
	void Update () {

	}

	public void durningAnimacionInicio() { 
		SongController.playSound (SongController.SonidoGuia);
	
	}
	public void endAnimacionInicio()
	{
		isGame = true;
		electrocutador.GetComponent<Electrificado> ().isDanado = true;
	}


		
	void startAnimacionFinal()
	{
		player.GetComponent<Animator>().SetTrigger("end");
	}
	public void duringAnimacionFinal()
	{
		SongController.playSound (SongController.SonidoHectorHambr);
	}

	//game repair
	public void repairStart()
    {
		//seleccionar los aleatorios malos
        int cant = (int)Mathf.Floor(aisladores.Length / 3);
		for (int i = 0; i < cant; i++)
		{
			int Rand = UnityEngine.Random.Range(0, cant); // escogidos.Add();
			while (escogidos.Contains(Rand))
			{
				Rand = UnityEngine.Random.Range(0, cant);
			}
			escogidos.Add(Rand);
		}
		//setear todas las cerámicas
        for (int i = 0; i < aisladores.Length; i++)
        {
			aisladores[i].GetComponent<Renderer>().material = ceramica;
		}
		//dañamos la primera cerámica
		dañarSiguiente();

	}

	void repairEnd()
	{
		//limpiar los aleatorios malos
		escogidos.Clear();
		//setear todas las cerámicas
		for (int i = 0; i < aisladores.Length; i++)
		{
			aisladores[i].GetComponent<Renderer>().material = ceramica;
			if(aisladores[i].GetComponent<Soldadonse>())
            {
				Destroy(aisladores[i].GetComponent<Soldadonse>());
            }
		}
	}

	void dañarSiguiente() {
		if (escogidos.Count > 0)
		{
			//extraemos el ultimo indice
			int index = escogidos.Last();

			escogidos.RemoveAt(escogidos.Count - 1);
			aisladorActual = aisladores[index];
			aisladorActual.GetComponent<Renderer>().material = dañado;
			aisladorActual.AddComponent<Soldadonse>();
        }
        else
        {
			ganoJuego();
        }
	}

	public void onFixed()
    {
		aisladorActual.GetComponent<Renderer>().material = ceramica;
		dañarSiguiente();
    }

	void ganoJuego()
    {
		repairEnd();
		startAnimacionFinal();
		//desactivar cautil
    }

	public void gameOver()
    {
		SongController.stopSound (1);SongController.stopSound (3);SongController.stopSound (4);SongController.stopSound (5);SongController.stopSound (6);SongController.stopSound (7);
		repairEnd ();
		electrocutador.GetComponent<Electrificado> ().isDanado = false;
		pantallago.SetActive (true);
	}
	public void resetear(){
		SceneManager.LoadScene (0);
	}
}
