using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSW_LookAt_Camera : MonoBehaviour
{

    public Camera CameraToLookAt;
    // Start is called before the first frame update
    void Start()
    {
        CameraToLookAt = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + CameraToLookAt.transform.rotation * Vector3.back,
            CameraToLookAt.transform.rotation * Vector3.up);
    }
}
