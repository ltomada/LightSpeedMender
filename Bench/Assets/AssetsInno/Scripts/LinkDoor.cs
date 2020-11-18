using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkDoor : MonoBehaviour {
   
   public Transform destination;
   
   public void Take(ResourceObj resource) {
      resource.gameObject.SetActive(true);
      resource.transform.position = destination.position;
      Rigidbody rb=resource.GetComponent<Rigidbody>();
      rb.useGravity = true;
      var constraints = rb.constraints;
      constraints = RigidbodyConstraints.FreezePositionY;
      constraints = RigidbodyConstraints.FreezeRotationY;
      rb.constraints = constraints;
   }
}
