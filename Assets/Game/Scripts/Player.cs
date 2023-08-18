using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _muzzleFlash;
    [SerializeField] GameObject _hitMarkerPrefab;
    [SerializeField] AudioSource _weaponAudio;
    [SerializeField] int currentAmmo;
    int maxAmmo = 30;
    bool _isReloading = false;
    float tiempodeRecarga = 1.5f;

    InputActionAsset _actionAsset = null;
    private UIManager _uiManager;

    public bool HasCoin { get; set; }

    [SerializeField] GameObject _weapon;

    //[Header("Inventory Prefabs")]
    //[SerializeField] GameObject coinPrefab;

    private Vector3 _initPositionPlayer;

    [SerializeField] GameObject talkPrefab;
    [SerializeField] GameObject canvasUI;

    public void EnableWeapon()
    {
        _weapon.SetActive(true);
    }

    public bool GetWeapon()
    {
        return _weapon.activeSelf;
    }

    //bool _coin;
    //public bool GetCoin ()
    //{ 
    //    return _coin; 
    //}
    //public void SetCoin (bool value) 
    //{ 
    //    _coin = value; 
    //}

    private void Awake()
    {
        _actionAsset = GetComponent<PlayerInput>().actions;
        _muzzleFlash.SetActive(false);
        //HasCoin = true;
        //SetCoin(true);
    }

    void Start()
    {
        InputAction triggerPress = _actionAsset.FindActionMap("Player").
            FindAction("Attack");
        triggerPress.Enable();
        //Creamos los eventos de las funciones
        triggerPress.performed += OnTriggerPress;
        triggerPress.canceled += OnTriggerPress;

        currentAmmo = maxAmmo;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        _initPositionPlayer = this.transform.position;
        if (PlayerPrefs.GetInt("NuevaPartida", 0) == 0) //false es cargar partida
            Init();
    }

    void Init()
    {
        HasCoin = GameManager.Singleton.LoadGameCoin();
        _weapon.SetActive(GameManager.Singleton.LoadGameWeapon());
    }

    void InitPlayer()
    {
        this.transform.position = _initPositionPlayer;
    }

    private void OnTriggerPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Debug.Log("context.performed");
            PressTrigger();
        }
        if (context.canceled)
        {
            //Debug.Log("context.canceled");
            ReleaseTrigger();
        }
    }

    /// <summary>
    /// Este metodo sirve para al darle al click entre
    /// </summary>
    private void PressTrigger()
    {
        if (_weapon.activeSelf == false)
            return;

        if (GameManager.Singleton.isFriend)
            return;

        //Debug.Log("Player::PressTrigger");
        _muzzleFlash.SetActive(true);
        //Attack();
        InvokeRepeating("Attack", 0, 0.1f);
        //if (_weaponAudio.isPlaying == false)
        _weaponAudio.Play();

    }

    /// <summary>
    /// Al soltar el click del raton
    /// </summary>
    private void ReleaseTrigger()
    {
        _muzzleFlash.SetActive(false);
        CancelInvoke("Attack");
        _weaponAudio.Stop();
        //_weaponAudio.loop = false;
    }



    void Update()
    {
        _uiManager.UpdateAmmo(currentAmmo);

        if (this.transform.position.y < -100)
        {
            InitPlayer();
        }
    }


    public void Attack()
    {
        if (currentAmmo <= 0)
        {
            ReleaseTrigger();
            return;
        }
        //Debug.Log("OnAttack");
        //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Debug.Log("Hit: " + hit.transform.gameObject.name);
            GameObject hitMarker = Instantiate(_hitMarkerPrefab, hit.point, Quaternion.LookRotation(hit.normal)); //Quaternion.identity);
            Destroy(hitMarker, 0.5f);

            Destructable item = hit.transform.GetComponent<Destructable>();
            if (item != null)
            {
                item.DestroyItem();
            }

        }
        currentAmmo--;
    }

    public void OnReload() 
    {
        if (_isReloading)
            return;
        
        //currentAmmo = maxAmmo;
        Debug.Log("1");
        StartCoroutine(Reload());
        Debug.Log("2");
    }

    IEnumerator Reload()
    {
        _isReloading = true;
        ReleaseTrigger();
        Debug.Log("3");
        yield return new WaitForSeconds(tiempodeRecarga);
        currentAmmo = maxAmmo;
        Debug.Log("4");
        _isReloading = false;
        //PressTrigger();
    }

    public void OnUse()
    {
        //Debug.Log("OnUse");
        GameManager.Singleton.isUseKey = true;
        StartCoroutine(TeclaPulsada("Use"));
    }

    IEnumerator TeclaPulsada(string tecla)
    {
        yield return new WaitForSeconds(0.1f);
        if (tecla=="Use")
            GameManager.Singleton.isUseKey = false;
        if (tecla == "Talk")
            GameManager.Singleton.isTalkKey = false;

    }

    public void OnTalk()
    {
        //Debug.Log("OnTalk");

        if (GameManager.Singleton.isFriend)
        {
            Debug.Log("talk y amigo");
            GameObject talk = Instantiate(talkPrefab, canvasUI.transform);
            talk.transform.SetParent(canvasUI.transform);
            Destroy(talk, 2f);
        }

    }


}
