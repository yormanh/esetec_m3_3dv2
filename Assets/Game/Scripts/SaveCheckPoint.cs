using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("OnTriggerStay");
        if ((other.transform.root.tag == "Player") &&
            (GameManager.Singleton.isUseKey)) //==true
        {
            //Debug.Log("OnTriggerStay con tecla E");
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Debug.Log("Save Game");
                GameManager.Singleton.SaveGame(player.HasCoin,
                    player.GetWeapon());
            }
        }
    }
}