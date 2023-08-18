using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _ammoText;
    [SerializeField] GameObject _coin;

    [SerializeField] Image _mirilla;

    
    void Start()
    {
        
    }

    private void Update()
    {
        ColorPuntero();
    }

    void ColorPuntero()
    {
        if (GameManager.Singleton.isFriend)
            _mirilla.color = Color.blue;
        else
            _mirilla.color = Color.red;

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
