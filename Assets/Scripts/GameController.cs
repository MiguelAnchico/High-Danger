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
	}
	
	void Update () {
	}

	public void prueba()
    {
		Debug.Log("Prueba exitosa");
    }
}
