using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;

    public bool isUseKey { get; set; } //Tecla E
    public bool isFriend { get; set; }
    public bool isTalkKey { get; set; } //Tecla E

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

    public void ResetGame()
    {
        PlayerPrefs.SetInt("Moneda", 0);
        PlayerPrefs.SetInt("Weapon", 0);
        //PlayerPrefs.SetString("JuegoSalvado1", "Moneda: true, Weapon: false");
        //PlayerPrefs.SetString("JuegoSalvado2", "Moneda: true, Weapon: true");

    }

    public void SaveGame(bool moneda, bool weapon)
    {
        PlayerPrefs.SetInt("Moneda", moneda == true ? 1 : 0);
        PlayerPrefs.SetInt("Weapon", weapon == true ? 1 : 0);
    }

    public bool LoadGameCoin()
    {
        int moneda = PlayerPrefs.GetInt("Moneda", 0);
        return moneda == 1 ? true : false;

        //return PlayerPrefs.GetInt("Moneda", 0) ? false : 1;
    }
    public bool LoadGameWeapon()
    {
        int weapon = PlayerPrefs.GetInt("Weapon", 0);
        return weapon == 1 ? true : false;
    }


}
