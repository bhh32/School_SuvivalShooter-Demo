﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertiesDemo : MonoBehaviour
{
    [SerializeField] Text messageText;

    private string message;

    public string Message
    {
        set
        {
            message = value;
        }
        get
        {
            return message;
        }
    }
    // Use this for initialization
    void Start()
    {
        message = "You Haven't Hit Anything Yet!";
    }

    private void Update()
    {
        messageText.text = message;
    }
}
