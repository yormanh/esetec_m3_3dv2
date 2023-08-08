using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    /*
 script del SharkShop.cs
 Ver la colision
 Si es player
 SI se pulso la tecla e
 Si tiene la moneda
   quitarle la moneda
   actualizar el inventario
   reproducir sonido
   conseguir arma
 Else
  debug no tiene moneda


 */
    [SerializeField] AudioClip _audio;

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
                if (player.HasCoin)
                {
                    player.HasCoin = false;
                    AudioSource.PlayClipAtPoint(_audio, transform.position);

                    UIManager uiManager = GameObject.Find("Canvas").
                        GetComponent<UIManager>();
                    if (uiManager)
                        uiManager.RemoveCoin();
                    player.EnableWeapon();
                }
                else
                {
                    Debug.Log("No tienes moneda");
                }
            }
        }
    }



    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
