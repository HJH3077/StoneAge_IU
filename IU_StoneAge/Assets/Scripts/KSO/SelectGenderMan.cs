using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectGenderMan : MonoBehaviour
{
    public GameObject Camera;
    public GameObject ManDetail;
    public GameObject WomanDetail;
    public GameObject Man;

    public void OnClickMan()
    {
        Camera.transform.localPosition = new Vector3(2, 1, 2);
        ManDetail.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void OnClickWoman()
    {
        Man.SetActive(false);
        WomanDetail.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
