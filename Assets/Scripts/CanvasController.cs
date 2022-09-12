using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ElephantSDK;
public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance { get; private set; }
    public TextMeshProUGUI levelText;
    public GameObject firstText;
    public GameObject winPanel;
    public GameObject failPanel;
    public GameObject buttonPanel;
    public GameObject moneyText;
    public GameObject coinsPanel;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        levelText.text ="LEVEL " +(PlayerPrefs.GetInt("level") + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        Debug.Log("Start");
        Elephant.LevelStarted(PlayerPrefs.GetInt("level") + 1);
        firstText.SetActive(false);
        buttonPanel.SetActive(false);
        moneyText.SetActive(false);
    }

    public void GameWin()
    {
        Debug.Log("Win");
        Elephant.LevelCompleted(PlayerPrefs.GetInt("level") + 1);
        winPanel.SetActive(true);

    }
    public void GameLost()
    {
        Debug.Log("LOST");
        Elephant.LevelFailed(PlayerPrefs.GetInt("level") + 1);
        failPanel.SetActive(true);
    }
}
