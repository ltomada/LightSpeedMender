using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHandsFull : IShipController {
    private ShipManager owner;

    public ShipHandsFull(ShipManager owner) {
        this.owner = owner;
    }

    public void Enter() {
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
        Physics.Raycast(owner.transform.position,owner.transform.TransformDirection(Vector3.forward) * owner.hitDistance,out hit);
        if (hit.collider) {
            LinkDoor sectionHit = hit.collider.gameObject.GetComponent<LinkDoor>();
            if (sectionHit != null) {
                sectionHit.Take(owner.actualResource);
                owner.ChangeState(new ShipNothingCarrying(owner));
            }
        }
    }
}
