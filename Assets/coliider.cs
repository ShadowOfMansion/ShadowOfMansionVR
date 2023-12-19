using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coliider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
