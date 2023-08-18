using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cofee : MonoBehaviour
{



    
    void Start()
    {
        //this.transform.DOMoveX(100, 2);
        this.transform.DORotate(new Vector3(0,180,0), 2f).SetLoops(10);
    }

    
    void Update()
    {
        
    }
}
