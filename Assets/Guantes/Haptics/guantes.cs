using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using System;

public class guantes : MonoBehaviour {

	 string DERECHA ="COM5"; //puerto up
	 string IZQUIERDA = "COM4"; //puerto dow
	SerialPort arduino; SerialPort arduino2;
	public string Accionador;

	void Start () {
		arduino = new SerialPort(DERECHA, 9600);
		arduino2 = new SerialPort(DERECHA, 9600);
		arduino.Open();
		arduino2.Open();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q))
		{
			if (arduino.IsOpen)
			{
				arduino.Write(Accionador);
				arduino.Write(Accionador);
				arduino.Write(Accionador);
				arduino.Write(Accionador);
				arduino.Write(Accionador);
				arduino.Write(Accionador);
				arduino.Write(Accionador);
				arduino.Write(Accionador);
				arduino.Write(Accionador);
			}
			if (arduino2.IsOpen)
			{
				arduino2.Write(Accionador);
				arduino2.Write(Accionador);
				arduino2.Write(Accionador);
				arduino2.Write(Accionador);
				arduino2.Write(Accionador);
				arduino2.Write(Accionador);
				arduino2.Write(Accionador);
				arduino2.Write(Accionador);
				arduino2.Write(Accionador);
			}
		}
	}
}
