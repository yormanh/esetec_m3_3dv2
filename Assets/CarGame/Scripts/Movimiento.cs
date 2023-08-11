using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Movimiento : MonoBehaviour
{
    [SerializeField] WheelCollider ruedaDI, ruedaDD, ruedaTI, ruedaTD;
    [SerializeField] float aceleracion = 100;
    [SerializeField] float desaceleracion = 80;
    [SerializeField] float anguloGiro = 20;
    [SerializeField] Transform neumaticoDI, neumaticoDD;
    float velocidad;
    float velocidadMaxima = 200;
    
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {

        if (Mathf.Abs(velocidad) < velocidadMaxima)
        {
            //aceleracion
            ruedaTI.motorTorque = aceleracion * Input.GetAxis("Vertical");
            ruedaTD.motorTorque = aceleracion * Input.GetAxis("Vertical");
        }
        else
        {
            ruedaTI.motorTorque = 0;
            ruedaTD.motorTorque = 0;

        }

        if (Input.GetAxis("Vertical") == 0)
        {
            ruedaTI.brakeTorque = desaceleracion;
            ruedaTD.brakeTorque = desaceleracion;
        }
        else
        {
            ruedaTI.brakeTorque = 0;
            ruedaTD.brakeTorque = 0;

        }


        //giro
        ruedaDI.steerAngle = anguloGiro * Input.GetAxis("Horizontal");
        ruedaDD.steerAngle = anguloGiro * Input.GetAxis("Horizontal");
    }

    private void Update()
    {
        neumaticoDD.localEulerAngles = new Vector3(0, ruedaDD.steerAngle, 0);
        neumaticoDI.localEulerAngles = new Vector3(0, ruedaDI.steerAngle, 0);

        
        velocidad = 2 * Mathf.PI * ruedaDI.radius * ruedaDI.rpm / 60 ;
        velocidad = Mathf.Round(velocidad);
        //Debug.Log(velocidad);
    }


    //void OnMove()
    //{
    //    Debug.Log("OnMove");
    //}

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        float movementX = movementVector.x;
        float movementY = movementVector.y;

        Debug.Log(movementVector);
    }



    //public void OnMove(InputValue value)
    //{
    //    // Read value from control. The type depends on what type of controls
    //    // the action is bound to.
    //    var v = value.Get<Vector2>();

    //    // IMPORTANT: The given InputValue is only valid for the duration of the callback.
    //    //            Storing the InputValue references somewhere and calling Get<T>()
    //    //            later will not work correctly.

    //    Debug.Log(v);
    //}

    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    var value = context.ReadValue<Vector2>();
    //    Debug.Log(value);
    //}

}
