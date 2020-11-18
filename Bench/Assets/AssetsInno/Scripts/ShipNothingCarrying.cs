using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipNothingCarrying : IShipController {
	
	private ShipManager owner;

	public ShipNothingCarrying(ShipManager droppedResource) {
		this.owner = droppedResource;
	}

	public void Enter() {
		if (owner != null && owner.actualResource != null) {
			owner.actualResource = null;
		}
	}

	public void Execute() {
		if (Input.GetKeyDown(KeyCode.E)) {
			CheckFrontal();
		}
	}

	public void Exit() {
	}
	
	private void CheckFrontal() {
		Debug.Log("Checked Frontal");
		RaycastHit hit;
		Debug.DrawRay(owner.transform.position, owner.transform.TransformDirection(Vector3.forward) * (owner.hitDistance * 10f), Color.yellow);
		Physics.Raycast(owner.transform.position,owner.transform.TransformDirection(Vector3.forward)*owner.hitDistance,out hit,owner.resMask);
		if (hit.collider) {
			ResourceObj sectionHit = hit.collider.gameObject.GetComponent<ResourceObj>();
			if (sectionHit != null) {
				//
				owner.ChangeState(new ShipHandsFull(owner));
			}
		}
	}
}
