using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DropdownOptions : MonoBehaviour
{
    public GameObject[] gameObjects;

    [SerializeField]
    private TMP_Dropdown dropdown;
    protected List<string> optionList = new List<string>();

    private void Start()
    {
        dropdown = this.GetComponent<TMP_Dropdown>();

        dropdown.ClearOptions();
        int count = gameObjects.Length;
        for (int i = 0; i < count; i++)
        {
            optionList.Add(gameObjects[i].name);
        }

        dropdown.AddOptions(optionList);
    }
}
