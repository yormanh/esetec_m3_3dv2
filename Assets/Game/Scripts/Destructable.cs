using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] GameObject _itemDestroyed;

    public void DestroyItem()
    {
        Instantiate(_itemDestroyed, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
