using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {
    public GameObject[] mats;

    private void OnTriggerEnter(Collider other) {
        switch (other.tag) {
            case "BlueMeteor":
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Instantiate(mats[0], this.transform.position, Quaternion.identity);
                break;
            case "RedMeteor":
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Instantiate(mats[1], this.transform.position, Quaternion.identity);
                break;
            case "YellowMeteor":
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Instantiate(mats[2], this.transform.position, Quaternion.identity);
                break;
            case "OrangeMeteor":
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Instantiate(mats[3], this.transform.position, Quaternion.identity);
                break;
            case "PurpleMeteor":
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Instantiate(mats[4], this.transform.position, Quaternion.identity);
                break;
            case "GreenMeteor":
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Instantiate(mats[5], this.transform.position, Quaternion.identity);
                break;
        }
    }
}
