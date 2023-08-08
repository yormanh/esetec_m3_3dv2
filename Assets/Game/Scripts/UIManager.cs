using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _ammoText;
    [SerializeField] GameObject _coin;

    
    void Start()
    {
        
    }

    public void CollectedCoin()
    {
        _coin.SetActive(true);
    }
    public void RemoveCoin()
    {
        _coin.SetActive(false);
    }


    public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo: " + count;
    }
}
