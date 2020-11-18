using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerPick : IShipController {
	public PlayerPick pickUp;
	public KeyCode pickUpItem;
	private GameObject ship;

	private int rayLayerMask = 1 << 8;
	

	public void Enter() {
	}

	public void Execute() {
		if (Input.GetKeyDown(pickUpItem)) {
			CheckFrontal();
		}
	}

	public void Exit() {
	}
	
	private void CheckFrontal() {
		Debug.Log("Checked Frontal");
		RaycastHit hit; 
		Physics.SphereCast(ship.transform.position,1,ship.transform.TransformDirection(Vector3.forward),out hit,rayLayerMask);
		if (hit.collider) {
			ResourceOutside sectionHit = hit.collider.gameObject.GetComponent<ResourceOutside>();
			if (sectionHit != null) {
				
			}
		}
	}
	
	
}
