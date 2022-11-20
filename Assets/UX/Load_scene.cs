using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Load_scene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void star(string scena)
	{
		SceneManager.LoadScene (scena);
	}
	public void opciones()
	{
		SceneManager.LoadScene ("");
	}

	public void exit()
	{
		Debug.Log("salir");
		Application.Quit ();
	}
}
