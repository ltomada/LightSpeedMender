using UnityEngine;
using Rewired;
using UnityEditor;

public class PlayerControllerStateInside : IPlayerState {
	
	private PlayerController m_owner;
	private bool inputIsEnabled = true;

	private float m_moveHori;
	private float m_moveVert;
	
	
	Vector3 lastInput;
	
	public PlayerControllerStateInside(PlayerController owner) {
		m_owner = owner;
	}

	public void Enter() {
		m_owner.actualResource = null;
	}

	public void Execute() {
		
		if (m_owner.player.GetButtonDown("Interact")) {
			if (m_owner.actualResource == null) {
				CheckFrontal();
			}
		}
	}

	private void CheckFrontal() {
		Debug.Log("Checked Frontal");
		RaycastHit hit;
		Debug.DrawRay(m_owner.transform.position +Vector3.up/2, m_owner.transform.TransformDirection(Vector3.forward) * m_owner.hitDistance, Color.yellow);
		Physics.Raycast(m_owner.transform.position+ Vector3.up/2,m_owner.transform.TransformDirection(Vector3.forward)*m_owner.hitDistance,out hit,m_owner.ElentsLayerMask);
		if (hit.collider) {
			ResourceObj sectionHit = hit.collider.gameObject.GetComponent<ResourceObj>();
			if (sectionHit != null) {
				sectionHit.Take(out m_owner.actualResource);
				m_owner.ChangeState(new PlayerControllerHandsFull(m_owner));
			}
		}
	}
	
	public void Exit() {
	}
}
