using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using System.Linq;
using Sirenix.Utilities;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : SerializedMonoBehaviour
{
    public List<Section> sections = new List<Section>();
    [SerializeField]public List<Danger> dangerList = new List<Danger>();
    public Dictionary<int, GameObject> IdToObject = new Dictionary<int,GameObject>();
    
    public event Action HpModified; 
    public event Action SectionRepaired;

    private int repairedSections = 0;
    public int[] randomIndex;
    public int dangerIndex = 0;
    
    [System.Serializable]
    public struct Danger {
        [SerializeField]public int dangerID;
        [ColorPalette]public Color dangerColor;
    }

    private bool matchIsGoing;

    private int hp=5;
    
    public int Hp {
        get => hp;
        set {
            hp = value; 
            HpModified?.Invoke();
        }
    }
    public int RepairedSections {
        get => repairedSections;
        set {
            repairedSections = value;
            SectionRepaired?.Invoke();
        }
    }

    private void Start() {
        matchIsGoing = true;
        SetRandomIndex();
        StartCoroutine(DangerTimer());
        HpModified += UpdateUI;
        HpModified += ScreeShake;
        HpModified += CheckMatch;
        SectionRepaired += CheckForVictory;
    }

    private void CheckForVictory() {
        if (repairedSections >= 6) {
            SceneManager.LoadScene(2);
        }
    }

    private void CheckMatch() {
        if (Hp <= 0) {
            SceneManager.LoadScene(3);
        }
    }

    private void ScreeShake() {
        
    }

    private void UpdateUI() {
    }

    private void SetRandomIndex() {
        randomIndex = new int[sections.Count];
        // fill with some data
        for (int i = 0; i < randomIndex.Length; i++)
        {
            randomIndex[i] = i;
        }
        System.Array.Sort(randomIndex, RandomSort);
    }
 
    int RandomSort(int a, int b)
    {
        return Random.Range(-1, 2);
 
    }
    
    private void ChooseRoomForDanger() {
        var sectionIndex = randomIndex[dangerIndex++];
        sections[sectionIndex].AssignRandomDanger();
    }
    

    private IEnumerator DangerTimer() {
        while (matchIsGoing) {
            Debug.Log("Sono entrato");
            ChooseRoomForDanger();
            yield return new WaitForSeconds(5);
        }
    }
    
}
