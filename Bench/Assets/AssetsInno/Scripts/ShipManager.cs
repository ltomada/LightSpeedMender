using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour {
	
	public GameObject Bullet;
	public float speed = 1;
	private Rigidbody rb;
	Ray thugRay;
	RaycastHit hit;
	private IShipController controllerState;
	public ResourceObj actualResource;
	public LayerMask resMask;
	public float hitDistance=2f;

	void Start() {
		controllerState=new ShipNothingCarrying(this);
	}

	void Update() {
		controllerState?.Execute();
		if (Input.GetMouseButtonDown(0))
		{
			var instance = Instantiate(Bullet, transform.position, Quaternion.identity);
			instance.GetComponent<BulletSpeed>().dir = transform.forward * speed;
		}
	}
	public void ChangeState(IShipController newState) {
		if (controllerState != null) {
			controllerState.Exit();
			controllerState = newState;
			controllerState.Enter();
		}
	}
}