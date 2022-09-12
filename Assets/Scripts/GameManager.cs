using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    
    [HideInInspector] public bool firstStart;

    [HideInInspector] public bool gameEnd;

    
    
    public List<GameObject> levels = new List<GameObject>();

    [Space]
    [Space]
    public GameObject CurrentLevel;
    public bool isTesting = false;

    public Material skybox_1;
    public Material skybox_3;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
        Screen.sleepTimeout = -SleepTimeout.NeverSleep;

        
        
       
        if (isTesting == false)
        {
            if (levels.Count == 0)
            {
                foreach (Transform level in transform)
                {
                    levels.Add(level.gameObject);
                }
            }

            CurrentLevel = levels[PlayerPrefs.GetInt("level") % levels.Count];
            levels[PlayerPrefs.GetInt("level") % levels.Count].SetActive(true);

        }
        else
        {
            CurrentLevel.SetActive(true);
        }

        switch (PlayerPrefs.GetInt("level") % 2)
        {
            case 0:
                RenderSettings.skybox = skybox_1;
                break;
            case 1:
                RenderSettings.skybox = skybox_3;
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        firstStart = true;
        gameEnd = false;
      



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        //StartCoroutine(LevelUp());
        if ((levels.IndexOf(CurrentLevel) + 1) == levels.Count)
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            //  GameHandler.Instance.Appear_TransitionPanel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            CurrentLevel = levels[(PlayerPrefs.GetInt("level") + 1) % levels.Count];
            levels[(PlayerPrefs.GetInt("level")) % levels.Count].SetActive(false);
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            levels[PlayerPrefs.GetInt("level") % levels.Count].SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

   


    public void GameStart()
    {
        SwerveSystem.Instance.isMoveForward = true;
    }
}
