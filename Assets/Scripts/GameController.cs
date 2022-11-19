using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController Instance;
	public guantes HapxelController;
	public bool activo = false;

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
		//iniciar animación
		//ejecutar audio historia
		//activar entorno (preparar aleatorios)
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


}
