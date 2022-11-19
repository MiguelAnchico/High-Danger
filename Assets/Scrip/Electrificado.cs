﻿using UnityEngine;
using System.Collections;

public class Electrificado : MonoBehaviour {
	public float tiempoDeElectrificado;
	public bool isElectrificado;
	public bool isHandsInside;

	// Use this for initialization
	void Start () {
		tiempoDeElectrificado = Random.Range(10.0f, 16.0f);
		isElectrificado = false;
		isHandsInside = false;
	}
	
	// Update is called once per frame
	void Update () {
		tiempoDeElectrificado -= Time.deltaTime;

		if (tiempoDeElectrificado < 0) {
			tiempoDeElectrificado = Random.Range(10.0f, 16.0f);
			if (isHandsInside) {
				GameController.Instance.HapxelController.checkVibrar = true;
			}

		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Hand")) {
			isHandsInside = true;
		}


	}

	private void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Hand")) {
			isHandsInside = false;
		}

	}
}