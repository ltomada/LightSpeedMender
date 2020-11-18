using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;
using Sirenix.OdinInspector;
using UnityEngine.XR;

public class Meteor : MonoBehaviour {
    public float lateralSpeed;
    private bool cameraCheck;
    private float distanceFromShip;
    public GameObject brokenShip;
    private GameObject spaceShip;
    public MeteorState currentState;
    
    public enum MeteorState {
        Moving,
        Captured,
        Inside,
        Abandoned
    }

    private void Start() {
        distanceFromShip = this.transform.position.x - brokenShip.transform.position.x;
        currentState = MeteorState.Moving;
        spaceShip = GameObject.FindGameObjectWithTag("Spaceship");
    }

    [Button]
    private void Update() {
        switch (currentState) {
            case MeteorState.Moving:
                if (distanceFromShip < 0) {
                    transform.position += transform.right * lateralSpeed * Time.deltaTime;
                }
                if (distanceFromShip> 0) {
                    transform.position += -transform.right * lateralSpeed * Time.deltaTime;
                }
                break;
            case MeteorState.Captured:
                transform.position = spaceShip.transform.position + transform.forward;
                break;
            case MeteorState.Inside:
                break;
            case MeteorState.Abandoned:
                break;
        }
    }

   
}   
