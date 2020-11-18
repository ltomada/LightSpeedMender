using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour {
	private static GameManager GameManager;

	private void Start() {
		if (!GameManager) {
			GameManager = FindObjectOfType<GameManager>();
		}
	}

	private void OnCollisionEnter(Collision other) {
		if (other.collider.CompareTag("Meteor")) {
			GameManager.Hp--;
			Destroy(other.gameObject);
		}
	}
}