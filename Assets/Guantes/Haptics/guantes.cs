using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using System;

public class guantes : MonoBehaviour {

	public string Puerto_DERECHA = "COM5"; //puerto up
	public string Puerto_IZQUIERDA = "COM4"; //puerto down
	SerialPort arduino; SerialPort arduino2;
	public string[] Acc_Todos = new string[] { "I", "K", "M", "G", "A", "B"};
	public string[] Acc_Medios = new string[] { "I" };
	public string[] Acc_Corazones = new string[] { "K" };
	public string[] Acc_Indices = new string[] { "M" };
	public string[] Acc_Chiquitos = new string[] { "G" };
	public string[] Acc_Pulgares = new string[] { "A" };
	public string[] Acc_Centro = new string[] { "B" }; //solo derecha
	public int VibracionLarga = 9, VibracionCorta = 3, VibracionBreve= 5;
	public Thread internalThread;
	private bool isAlive = true;
	public bool checkVibrar = false;

	void Start () {
		arduino = new SerialPort(Puerto_DERECHA, 9600);
		arduino2 = new SerialPort(Puerto_IZQUIERDA, 9600);


		try
		{
			arduino.Open();
        }
        catch { Debug.LogError("No se detectan el puerto derecha"); }
		try
		{
			arduino2.Open();
		}
		catch { Debug.LogError("No se detectan el puerto izquierda"); }

		internalThread = new Thread (StartVibrate);
		internalThread.Start ();
	}
	
	void Update () {

	}

	public void VibrateAll(string[] referencias, int rep, int mano = 0)
	{
		SerialPort[] ardu;
		ardu = mano >= 1 ? new SerialPort[] { arduino } : mano <= -1 ? new SerialPort[] { arduino2 }  : new SerialPort[] { arduino, arduino2 };
		for (int j = 0; j < rep; j++) 
			{
				for (int i = 0; i < referencias.Length; i++)
				{
					for (int k = 0; k < ardu.Length; k++)
					{
						ardu[k].Write(referencias[i]);
						ardu[k].Write(referencias[i]);
						ardu[k].Write(referencias[i]);
						ardu[k].Write(referencias[i]);
						ardu[k].Write(referencias[i]);
						ardu[k].Write(referencias[i]);
						ardu[k].Write(referencias[i]);
						ardu[k].Write(referencias[i]);
					}
				}
			}
	}

	public void VibrateEspc(string[] referencias, int rep, int mano = 0)
	{
		SerialPort[] ardu;
		ardu = mano >= 1 ? new SerialPort[] { arduino } : mano <= -1 ? new SerialPort[] { arduino2 }  : new SerialPort[] { arduino, arduino2 };
		for (int j = 0; j < rep; j++) 
		{
			for (int i = 0; i < referencias.Length; i++)
			{
				for (int k = 0; k < ardu.Length; k++)
				{
					ardu[k].Write(referencias[i]);
				}
			}
		}
	}

	public void StartVibrate(){
		//Debug.Log ("Corriendo en otro hilo..");
		while (isAlive) {
			if (checkVibrar)
			{
				//Debug.Log ("Q..");
				if (arduino.IsOpen)
				{
					VibrateAll (Acc_Todos, VibracionLarga, 0);
				}
				if (arduino2.IsOpen)
				{
					VibrateAll (Acc_Todos, VibracionLarga, 0);
					//StartCoroutine(VibrateAll(Acc_Todos, VibracionLarga, 0));
				}
				checkVibrar = false;
			}

		}
	}

	private void OnApplicationQuit() {
		isAlive = false;
	}
}
