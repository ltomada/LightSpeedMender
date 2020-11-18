using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	public float shakeDuration = 0f;
	public float shakeAmount = 0.3f;
	public float decreaseFactor = 1f;

	Vector3 originalPosition;

	private IEnumerator Shake(Camera camera)
	{
		originalPosition = transform.localPosition;
		float amount = shakeAmount;
		while(amount > 0)
		{
			transform.localPosition = originalPosition + Random.insideUnitSphere * amount;
			amount -= Time.deltaTime * decreaseFactor;
			yield return null;
		}
		transform.localPosition = originalPosition;
	}

	public void StartShake(Camera cam) {
		StartCoroutine(Shake(cam));
	}
   
}