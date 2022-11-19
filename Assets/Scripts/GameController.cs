using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class GameController : MonoBehaviour {

	public static GameController Instance;
	public guantes HapxelController;
	public GameObject SongOBJ;
	SongController SongController;
	public bool activo = false;
	// Game
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
		HapxelController = gameObject.GetComponent<guantes>();
		SongController = SongOBJ.GetComponent<SongController>();
		//iniciar animación
		//ejecutar audio historia
		//activar entorno 
		//preparar aleatorios
		repairStart();

		//activar cautil

	}
	
	void Update () {
	}

	void iniciar()
    {
		//comenzar animación
		//comenzar audio - 3 segundos de pausa
    }
	public void endAnimacion() { 
	
	}
	public void prueba()
    {
		Debug.Log("Prueba exitosa");
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

	void dañarSiguiente() {
		//extraemos el ultimo indice
		int index = escogidos.Last();

		escogidos.RemoveAt(escogidos.Count-1);
		aisladorActual = aisladores[index];
		aisladorActual.GetComponent<Renderer>().material = dañado;
		aisladorActual.AddComponent<Soldadonse>();
	}

}
