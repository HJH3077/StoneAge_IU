using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropdownSettings : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropdown;

    [SerializeField]
    private TextMeshProUGUI text;

    private void Awake()
    {
        dropdown.onValueChanged.AddListener(OnDropdownEvent);
    }

    public void OnDropdownEvent(int index)
    {
        text.text = $"{index}";
    }

    /*private void Awake()
    {
        Debug.Log(text.text);
        dropdown.onValueChanged.AddListener(OnDropdownEvent);
    }

    public void OnDropdownEvent(int index)
    {
        Debug.Log("Call OnDropdownEvent");
        int count = gameObjects.Length;
        for (int i = 0; i < count; i++)
        {
            Debug.Log(gameObjects[i]);
            if (gameObjects[i] != text.GetComponent<TMP_Dropdown>())
            {
                gameObjects[i].SetActive(false);
                Debug.Log("change Active");
            }
            else
            {
                gameObjects[i].SetActive(true);
                Debug.Log("SetActive");
            }
        }
    }*/
}
