using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GOtomenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseUI;
    void Start()
    {
        PauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseUI.SetActive(true);
        }
    }
}
