using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerHandsFull : IPlayerState
{
    private PlayerController m_owner;
    public float Speed;
    
    
    public PlayerControllerHandsFull(PlayerController owner) {
        m_owner = owner;
    }

    public void Enter() {
    }

    public void Execute() {
   
        if (m_owner.player.GetButtonDown("Interact")) {
           CheckFrontal();
        }
    }
    
    private void CheckFrontal() {
        RaycastHit hit; 
        RaycastHit hit2; 
        Physics.Raycast(m_owner.transform.position+Vector3.up/2,m_owner.transform.TransformDirection(Vector3.forward),out hit,m_owner.ElentsLayerMask);
        if (hit.collider) {
            Section sectionHit = hit.collider.gameObject.GetComponent<Section>();
            if (sectionHit != null) {
                Debug.Log("trovataaa");
                sectionHit.Interact(m_owner.actualResource.source.ID);
                m_owner.ChangeState(new PlayerControllerStateInside(m_owner));
            }
        }
        else {
            Debug.Log("Cerco la melder");
            Physics.Raycast(m_owner.transform.position+Vector3.up/2,m_owner.transform.TransformDirection(Vector3.forward),out hit2,m_owner.MachineLayerMask);
            if (hit.collider) {
                Miscelatore miscelatore = hit.collider.GetComponent<Miscelatore>();
                Debug.Log("Colpito miscelatore");
                miscelatore.InsertMaterial(m_owner.actualResource.source.ID);
                m_owner.ChangeState(new PlayerControllerStateInside(m_owner));
            }
        }
        
    }
    private void Throw() {
        m_owner.actualResource.gameObject.SetActive(true);
        m_owner.actualResource.transform.position = m_owner.transform.position + Vector3.forward+ Vector3.up;
        m_owner.Rb.AddForce(m_owner.transform.TransformDirection(Vector3.forward) * (100*m_owner.strength * Time.fixedDeltaTime), ForceMode.Impulse);
        m_owner.actualResource = null;
        m_owner.ChangeState(new PlayerControllerStateInside(m_owner));
    }
    
    public void Exit() {
        
    }
}
