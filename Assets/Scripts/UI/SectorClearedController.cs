﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorClearedController : MonoBehaviour
{
    public void GoToMap()
    {
        var controller = GameObject.FindObjectOfType<GameController>();
        if (controller != null)
        {
            controller.GoToMapScreen();
        }
    }
}