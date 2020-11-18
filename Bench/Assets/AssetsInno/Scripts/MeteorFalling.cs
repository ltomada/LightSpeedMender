using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider))]
public class MeteorFalling : MonoBehaviour {
    
    public GameObject[] meteors;
    public float spawnRate;
    
    private GameObject brokenShip;
    private BoxCollider box;
    private bool meteorFalls = true;

    public float spawnTimer = 5f;
    public float resetSpawnTimer;
    private void Awake() {
        box = GetComponent<BoxCollider>();
    }

    private void Start() {
        StartCoroutine(FallingMeteor());
        resetSpawnTimer = spawnTimer;
    }

    private void Update() {
        spawnTimer -= Time.deltaTime; 
        if (spawnTimer <= 0) { 
            spawnRate -= 1f;
            spawnTimer = resetSpawnTimer;
            if (spawnRate <= 1f) {
                spawnRate = 1;
            }
        }
    }

    private IEnumerator FallingMeteor() {
        while (meteorFalls) {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, meteors.Length);
            Instantiate(meteors[randomIndex], RandomSpawn(), Quaternion.identity);
            
        }
    }
    
    private Vector3 RandomSpawn() {
        Vector3 randomPos;
        randomPos.x = Random.Range(box.bounds.min.x, box.bounds.max.x);
        randomPos.y = Random.Range(box.bounds.min.y, box.bounds.max.y);
        randomPos.z = Random.Range(box.bounds.min.z, box.bounds.max.z);
        return randomPos;
    }
}
