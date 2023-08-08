using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    /*
     * Detectar colision
     * comprobar si es el player
     * comprobar si le ha dado a la tecla e o usar
     *   obtener la moneda
     *   destruir la moneda
     */
    [SerializeField] AudioClip _audioPickup;

    //bool _isInside;
    //private void OnTriggerEnter(Collider other)
    //{
    //    _isInside = true;
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    _isInside = false;
    //}

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
                player.HasCoin = true;
                AudioSource.PlayClipAtPoint(_audioPickup, transform.position);

                UIManager uiManager = GameObject.Find("Canvas").
                    GetComponent<UIManager>();
                if (uiManager)
                    uiManager.CollectedCoin();
                Destroy(this.gameObject);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

