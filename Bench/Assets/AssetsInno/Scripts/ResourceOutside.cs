using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceOutside : MonoBehaviour {
    public ResourceInside source;
    public void Take(out ResourceOutside obj) {
        obj = this;
        gameObject.SetActive(false);
    }
}
