using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private GameObject circlesPrefab;
    [SerializeField] private int numberOfCircles;

    [Header("Spawn Position")]
    [SerializeField] private float minXPosition;
    [SerializeField] private float maxXPosition;
    [SerializeField] private float minYPosition;
    [SerializeField] private float maxYPosition;

    private GameObject[] circles;
    //singleton pattern
    public static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start(){
        circles = new GameObject[numberOfCircles];
        InstantiateCircles();
    }

    private void InstantiateCircles(){
        
        for (int i = 0; i < numberOfCircles; i++)
        {
            circles[i] = Instantiate(circlesPrefab);
            circles[i].SetActive(false);
        }
        spawnCircles();
    }

    private void spawnCircles(){
        for(int i = 0; i < numberOfCircles; i++){
            float xPosition = Random.Range(minXPosition, maxXPosition);
            float yPosition = Random.Range(minYPosition, maxYPosition);
            Vector3 spawnPosition = new Vector3(xPosition, yPosition, 0);
            circles[i].transform.position = spawnPosition;
            circles[i].SetActive(true);
        }
    }


}
