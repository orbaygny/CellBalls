using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ButtonControl : MonoBehaviour
{
    public static ButtonControl Instance { get; private set; }

    public Button btnBall;
    public Button btnInc;
    [Space]
    public TextMeshProUGUI  incCost;
    public TextMeshProUGUI ballCost;
    [Space]
    public TextMeshProUGUI incLvl;
    public TextMeshProUGUI ballLvl;
    [Space]
    
    public TextMeshProUGUI moneyText;

    private int _money;
    private int _incCost;
    private int _ballCost;
    private int _ballLvl;
    private int _incLvl;

    [HideInInspector]public int incomeMoney;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //values are put in corresponding fields
        _money = PlayerPrefs.GetInt("money", 0);

        _incCost = PlayerPrefs.GetInt("incCost", 10);
        _ballCost = PlayerPrefs.GetInt("ballCost", 10);

        _ballLvl = PlayerPrefs.GetInt("ballLvl", 1);
        _incLvl = PlayerPrefs.GetInt("incLvl", 1);

        // values are put in corresponding text
        moneyText.text = _money.ToString(); 

        incCost.text = _incCost.ToString();
        ballCost.text = _ballCost.ToString();

        ballLvl.text = _ballLvl.ToString();
        incLvl.text = _incLvl.ToString();

        incomeMoney = PlayerPrefs.GetInt("incomeMoney",1);


        if(_incCost <= _money)
        {
            Color color;
            btnBall.interactable = true;
            color = btnBall.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color;
            color.a = 255;
            btnBall.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = color;
        }
        if(_ballCost <= _money)
        {
            btnInc.interactable = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (_ballCost <= _money && _money>0)
        {
            Color color;
            btnBall.interactable = true;
            color = btnBall.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color;
            color.a = 1f;
            btnBall.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = color;

            color = btnBall.transform.GetChild(1).GetComponent<Image>().color;
            color.a = 1f;
            btnBall.transform.GetChild(1).GetComponent<Image>().color = color;

            color = btnBall.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color;
            color.a = 1f;
            btnBall.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = color;

            color = btnBall.transform.GetChild(2).GetComponent<Image>().color;
            color.a = 1f;
            btnBall.transform.GetChild(2).GetComponent<Image>().color = color;
        }

        else
        {
            Color color ;
            btnBall.interactable = false;
            color = btnBall.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color;
            color.a = 0.3f;
            btnBall.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = color;

            color = btnBall.transform.GetChild(1).GetComponent<Image>().color;
            color.a = 0.3f;
            btnBall.transform.GetChild(1).GetComponent<Image>().color = color;

            color = btnBall.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color;
            color.a = 0.3f;
            btnBall.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = color;

            color = btnBall.transform.GetChild(2).GetComponent<Image>().color;
            color.a = 0.3f;
            btnBall.transform.GetChild(2).GetComponent<Image>().color = color;

        }   
        if (_incCost <= _money && _money > 0)
        {
            Color color;
            btnInc.interactable = true;
            color = btnBall.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color;
            color.a = 1f;
            btnInc.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = color;

            color = btnBall.transform.GetChild(1).GetComponent<Image>().color;
            color.a = 1f;
            btnInc.transform.GetChild(1).GetComponent<Image>().color = color;

            color = btnBall.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color;
            color.a = 1f;
            btnInc.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = color;

            color = btnBall.transform.GetChild(2).GetComponent<Image>().color;
            color.a =1f;
            btnInc.transform.GetChild(2).GetComponent<Image>().color = color;
        }
        else
        {
            Color color;
            btnInc.interactable = false;
            color = btnBall.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color;
            color.a = 0.3f;
            btnInc.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = color;

            color = btnBall.transform.GetChild(1).GetComponent<Image>().color;
            color.a = 0.3f;
            btnInc.transform.GetChild(1).GetComponent<Image>().color = color;

            color = btnBall.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color;
            color.a = 0.3f;
            btnInc.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = color;

            color = btnBall.transform.GetChild(2).GetComponent<Image>().color;
            color.a = 0.3f;
            btnInc.transform.GetChild(2).GetComponent<Image>().color = color;
        }
    }

    public void Income()
    {
        if(_money >= _incCost)
        {
            incomeMoney++;
            PlayerPrefs.SetInt("incomeMoney", incomeMoney);

            _money -= _incCost;
            moneyText.text = _money.ToString();

            _incCost += 25;
            PlayerPrefs.SetInt("incCost", _incCost);
            incCost.text = _incCost.ToString();

            _incLvl++;
            PlayerPrefs.SetInt("incLvl", _incLvl);
            incLvl.text = _incLvl.ToString();


        }
    }

    public void AddBall()
    {
        
        BallControlSystem.Instance.balls[0].GetComponent<BallCollider>().EnableBall();
        PlayerPrefs.SetInt("startBall", PlayerPrefs.GetInt("startBall", 0) + 1);
        _money -= _ballCost;
        moneyText.text = _money.ToString();

        _ballCost += 25;
        PlayerPrefs.SetInt("ballCost", _ballCost);
        ballCost.text = _ballCost.ToString();

        _ballLvl++;
        PlayerPrefs.SetInt("ballLvl", _ballLvl);
        ballLvl.text = _ballLvl.ToString();
    }

    public void GetMoney(int x)
    {
        _money += x * incomeMoney;
        PlayerPrefs.SetInt("money", _money);
        moneyText.text = _money.ToString();

        
    }
}
