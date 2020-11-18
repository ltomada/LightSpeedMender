using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Resource", menuName = "Custom/Resource", order = 2)]
public class ResourceInside : ScriptableObject {
    public int ID;
    public GameObject obj;
}
