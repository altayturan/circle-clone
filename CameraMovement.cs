using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    void FixedUpdate()
    {
        transform.position = new Vector3(target.transform.position.x,0,-10);
    }
}
