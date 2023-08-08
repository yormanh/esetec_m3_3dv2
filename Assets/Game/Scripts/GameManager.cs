using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;

    public bool isUseKey { get;set; } //Tecla E

    private void Awake()
    {
        Singleton = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
