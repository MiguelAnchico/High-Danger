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
		//asignar controladores hijos
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
	void startAnimacionInicio()
	{

	}
	void endAnimacionInicio() { 
	
	}
	void startAnimacionFinal()
	{

	}
	void endAnimacionFinal()
	{

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

	void onFixed()
    {
		aisladorActual.GetComponent<Renderer>().material = ceramica;
		dañarSiguiente();
    }

	void ganoJuego()
    {
		Debug.Log("GANASTE");
		//desactivar cautil
		//audio de ganador
		//animacion salida
    }

	void gameOver()
    {
		Debug.Log("PERDISTE");
		//sonido electrocutado
		//active menu gameover
	}
}
