using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwat : MonoBehaviour
{
    [SerializeField]Animator animator;
    
    void Start()
    {
        //_animator.GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

    }
}
