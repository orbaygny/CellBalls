using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoneyMoves : MonoBehaviour
{
    public bool single; 
    public RectTransform target;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(target.position, 0.75f).OnComplete(DisableObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisableObject()
    {
        if (single)
        {
            gameObject.SetActive(false);
        }
    }
}
