using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class GameController : MonoBehaviour {

	[Header("Settings")]
	public GameObject player;
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

	void Awake() {
		if (Instance == null )
		{
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this);
		}
	}
	void Start () {
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
		//start audio guia
	
	}
	void startAnimacionFinal()
	{
		player.GetComponent<Animator>().SetTrigger("end");
	}
	public void duringAnimacionFinal()
	{
		//audio de ganador
	}

	//game repair
	void repairStart()
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
		//sonido electrocutado
		//active menu gameover
	}
}
