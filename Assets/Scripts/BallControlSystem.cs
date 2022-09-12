using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallControlSystem : MonoBehaviour
{
    public static BallControlSystem Instance { get; private set; }

        public List<GameObject> balls;
     public List<GameObject> openBalls;

    int startBall;

    public bool isTouch;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        balls = new List<GameObject>();
        openBalls = new List<GameObject>();

        foreach(Transform child in transform)
        {
            if(!child.GetComponent<BallCollider>().isMain&& child.GetComponent<BallCollider>().disabled)
            {
                balls.Add(child.gameObject);
                child.GetComponent<SphereCollider>().enabled = false;
                child.GetChild(1).gameObject.SetActive(false);
            }

            if (!child.GetComponent<BallCollider>().isMain && !child.GetComponent<BallCollider>().disabled)
            {
                openBalls.Add(child.gameObject);
            }
        }

        startBall = PlayerPrefs.GetInt("startBall", 0);
        if (startBall > 0)
        {
            for(int i = 0; i < startBall; i++)
            {
                
                balls[0].GetComponent<BallCollider>().EnableBall();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject == null)
        {
            isTouch = true;
            if (GameManager.Instance.firstStart)
            {
                GameManager.Instance.GameStart();
                CanvasController.Instance.GameStart();
                GameManager.Instance.firstStart = false;
               
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;
        }
    }

   
}
