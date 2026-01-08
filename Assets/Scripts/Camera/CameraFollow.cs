using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetPosition;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetPosition.position.x, transform.position.y , transform.position.z);
    }
}
