using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Friend")
            {
                Debug.Log("Es Amigo: " + hit.transform.name);
                GameManager.Singleton.isFriend = true;
            }
            else
                GameManager.Singleton.isFriend = false;
        }
    }


}
