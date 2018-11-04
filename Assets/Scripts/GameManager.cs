using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject Player;
    [SerializeField] private Spawner Spawner;
    [SerializeField] private Text Score;

    public static GameManager Instance { get; private set; }

    private int score = 0;

	// Use this for initialization
	void Start () {

        if (Instance == null)
        { 
            Instance = this; 
        }
        else if (Instance == this)
        { 
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        score = 0;
        Spawner.StartSpawning();
	}
	
	// Update is called once per frame
	void Update () {
		if (!Player.activeSelf)
        {
            Spawner.StopSpawning();
        }
	}

    public void AddScore(int scr)
    {
        score += scr;
        Score.text = string.Format("x{0}", score);
        Score.GetComponent<Animation>().Play("ScoreAnimation");
    }
}
