using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Miscelatore : SerializedMonoBehaviour
{
    public GameObject spawn;
    private int firstAddition;
    private int secondAddition;

    [SerializeField]
    public Dictionary<int, GameObject> MeteorDic = new Dictionary<int, GameObject>();
    public int SecondAddition {
        get => secondAddition;
        set {
            secondAddition = value;
            GiveObj();
        }
    }

    private void GiveObj()
    {
        
        if (MeteorDic.TryGetValue(CheckAddition(), out GameObject purlpleObj)) {
            Instantiate(purlpleObj, spawn.transform.position, Quaternion.identity);
        }
        firstAddition = 0;
        secondAddition = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RepairTools"))
        {
            Destroy(gameObject);
        }
    }
    private int CheckAddition() { 
        if (firstAddition == 0 && SecondAddition == 4) {
            return 3;
        }

        if (firstAddition == 0 && SecondAddition == 5) {
            return 1;
        }

        if (firstAddition == 4 && SecondAddition == 5) {
            return 2;
        }

        if (firstAddition == SecondAddition) {
            return -1;
        }
        if (firstAddition == 4 && SecondAddition == 0) {
            return 3;
        }

        if (firstAddition == 5 && SecondAddition == 0) {
            return 1;
        }

        if (firstAddition == 5 && SecondAddition == 4) {
            return 2;
        }
        return -1;
    }

    public void InsertMaterial(int a) {
        Debug.Log("Inserted");
        if (firstAddition <= 0) {
            firstAddition = a;
        }
        else if(SecondAddition<=0) {
            SecondAddition = a;
        }
    }
}
