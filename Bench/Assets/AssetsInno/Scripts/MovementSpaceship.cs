using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class MovementSpaceship : MonoBehaviour
{
    public float actualVel = 1;
    public float friction = 0.1f;
    public Vector3 oldPos;
    Rigidbody rb;

    public KeyCode up, down, left, right;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        oldPos = GetDirection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePhysics();
        Turn(GetDirection());
        if(GetDirection().magnitude > 0.01f)
        {
            oldPos = GetDirection();
        }
    }

    private void Turn(Vector3 input)
    {
        Quaternion rotation = Quaternion.LookRotation(oldPos);
        transform.rotation = rotation;

    }


    private void MovePhysics()
    {
        rb.velocity += GetDirection() * actualVel;
        rb.velocity -= Vector3.Scale(rb.velocity, new Vector3(friction, 0, friction ));
        rb.angularVelocity *= friction;
    }

    public Vector3 GetDirection()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        if(Input.GetKey(up))
        {
            dir += new Vector3(0, 0, 1);
        }
        if(Input.GetKey(down))
        {
            dir += new Vector3(0, 0, -1);
        }
        if(Input.GetKey(left))
        {
            dir += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(right))
        {
            dir += new Vector3(1, 0, 0);
        }
        dir.Normalize();
        return dir;
    }
    
}
