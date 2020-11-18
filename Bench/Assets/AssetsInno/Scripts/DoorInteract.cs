using UnityEngine;
using System.Collections;
public class DoorInteract : MonoBehaviour
{
    public Vector3 direction;
    
    public Transform openPivot;
    public Transform door;
    
    public float animationTime = 0.5f;
    private bool isArrived = false;
    private Vector3 openPosition;
    private Vector3 startPosition;
    private float timer;
    
    private void Awake()
    {
        openPosition = openPivot.position;
        startPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(MoveTo(door.transform.position, openPosition));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(MoveTo(door.transform.position, startPosition));
        }
    }

    private IEnumerator MoveTo(Vector3 start, Vector3 end)
    {
        timer = 0;
        while(timer < animationTime)
        {
            timer += Time.deltaTime;
            door.transform.position = Vector3.Lerp(start, end, timer / animationTime);        
            yield return null;
        }
    }
    
}
