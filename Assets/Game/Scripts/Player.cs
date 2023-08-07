using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _muzzleFlash;
    [SerializeField] GameObject _hitMarkerPrefab;

    InputActionAsset _actionAsset = null;

    private void Awake()
    {
        _actionAsset = GetComponent<PlayerInput>().actions;
        _muzzleFlash.SetActive(false);
    }

    void Start()
    {
        InputAction triggerPress = _actionAsset.FindActionMap("Player").
            FindAction("Attack");
        triggerPress.Enable();
        //Creamos los eventos de las funciones
        triggerPress.performed += OnTriggerPress;
        triggerPress.canceled += OnTriggerPress;

    }

    private void OnTriggerPress (InputAction.CallbackContext context)
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
        Debug.Log("Player::PressTrigger");
        _muzzleFlash.SetActive(true);
        //Attack();
        InvokeRepeating("Attack", 0, 0.1f);
    }

    /// <summary>
    /// Al soltar el click del raton
    /// </summary>
    private void ReleaseTrigger()
    {
        _muzzleFlash.SetActive(false);
        CancelInvoke("Attack");
    }
    

    
    void Update()
    {
        
    }


    public void Attack()
    {
        //Debug.Log("OnAttack");
        //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log("Hit: " + hit.transform.gameObject.name);
            GameObject hitMarker = Instantiate(_hitMarkerPrefab, hit.point, Quaternion.LookRotation(hit.normal)); //Quaternion.identity);
            Destroy(hitMarker, 0.5f);
        }

    }
}
