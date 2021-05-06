using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Gobject;
    public Text textS;
    public int totalScore;
    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
	textS.text = totalScore.ToString();
    }
    public void GameOver()
    {
	Gobject.SetActive(true);
    }
}
