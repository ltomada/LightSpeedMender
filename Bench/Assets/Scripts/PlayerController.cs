using System;
using Rewired;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private IPlayerState m_currentState;
	public Player player;
	private int playerId = 0;
	private Rigidbody rb;
	public ResourceObj actualResource;
	public float hitDistance;
	public LayerMask ElentsLayerMask;
	public LayerMask MachineLayerMask;

	public float speed;
	public float strength;
	Vector3 input;

	public Rigidbody Rb {
		get => rb;
		set => rb = value;
	}

	private void Start() {
		Rb = GetComponent<Rigidbody>();
		player = ReInput.players.GetPlayer(playerId);
		m_currentState = new PlayerControllerStateInside(this);
	}

	private void Update() {
		float hori = player.GetAxis("Move Horizontal");
		float vert = player.GetAxis("Move Vertical");

		input = new Vector3(hori, 0, vert);

		if (input != Vector3.zero) {
			Turn(input);
		}
		Move(input);
		Physics.IgnoreLayerCollision(8, 9);

		m_currentState?.Execute();
	}

	private void Move(Vector3 input) {
		Rb.velocity = input.normalized * (speed * Time.fixedDeltaTime);
	}

	private void Turn(Vector3 input) {
		Quaternion rotation = Quaternion.LookRotation(input.normalized);
		transform.rotation = rotation;
	}

	public void ChangeState(IPlayerState newState) {
		if (m_currentState != null) {
			m_currentState.Exit();
			m_currentState = newState;
			m_currentState.Enter();
		}
	}

	// private void OnDrawGizmos() {
	// 	Gizmos.color= Color.red;
	// 	Gizmos.DrawRay(transform.position+Vector3.up,transform.TransformDirection(Vector3.forward));
	// }
}