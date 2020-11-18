using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceObj : MonoBehaviour {
    
    public ResourceInside source;
    
    public void Take(out ResourceObj obj) {
        obj = this;
        gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Section")) {
            Debug.Log("Colpisco");
            if (other.GetComponent<Section>().Interact(source.ID)) {
                Destroy(gameObject);
            }
        }
    }
}
