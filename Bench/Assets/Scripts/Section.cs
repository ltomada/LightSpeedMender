using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Random = UnityEngine.Random;

public class Section : MonoBehaviour {

	[SerializeField]private int dangerId=0;
	public Light pLight;
	
	
	private static GameManager gameManager;

	private Color normalStateLightColor;
	public float glowSpeed;
	

	public int DangerId {
		get => dangerId;
		set {
			dangerId = value;
			ManageLight();
		}
	}

	private void Start() {
		if (gameManager == null) {
			gameManager = FindObjectOfType<GameManager>();
		}
		normalStateLightColor = pLight.color;
	}

	public bool Interact(int resourceId) {
		if (resourceId == DangerId) {
			Debug.Log("Problem Solved");
			DangerId = 0;
			return true;
		}
		else {
			Debug.Log("Wrong Element");
			return false;
		}
	}

	public void AssignRandomDanger() {
		int id = Random.Range(1, 5);
		if (dangerId != id) {
			DangerId = id;
		}
	}

	private void ManageLight() {
		if (dangerId != 0) {
			GameManager.Danger dngr = gameManager.dangerList.Find(x => x.dangerID == DangerId);
			pLight.color = dngr.dangerColor;
			StartCoroutine(LightGlowing());
		}
		else {
			pLight.color = normalStateLightColor;
		}
	}

	private IEnumerator LightGlowing() {
		bool isDecreasing = true;
		float t=0;
		while (DangerId!=0) {
			if (isDecreasing) {
				while (t < 1) {
					t += Time.deltaTime / glowSpeed;
					pLight.intensity = Mathf.Lerp(10, 0, t);
					yield return null;
				}
				if (pLight.intensity <= 0.01f) {
					isDecreasing = false;
					t = 0;
				}
				yield return null;
			}
			else {
				while (t < 1) {
					t += Time.deltaTime / glowSpeed;
					pLight.intensity = Mathf.Lerp(0, 10, t);
					yield return null;
				}
				if (pLight.intensity >= 9.98f) {
					isDecreasing = true;
					t = 0;
				}
				yield return null;
			}
			yield return null;
		}

	}
}