using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrillBridge : MonoBehaviour
{
    Transform frontBridge;
    Transform backBridge;
    public Sequence seq;
    // Start is called before the first frame update
    void Start()
    {
        frontBridge = transform.parent.GetChild(0);
        backBridge = transform.parent.GetChild(1);
        seq = DOTween.Sequence();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBridge()
    {
        
       // seq.Append(frontBridge.DOLocalRotate(new Vector3(75, 0, 0), 0.5f).SetEase(Ease.InOutQuint));
        //seq.Join(backBridge.DOLocalRotate(new Vector3(-75, 0, 0), 0.5f).SetEase(Ease.InOutQuint));
    }

   
}
