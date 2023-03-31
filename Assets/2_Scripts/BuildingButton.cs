using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MyButton
{
    private void Start()
    {
        SetText("Enter Building Mode");
        AddListener(HandleBuildingMode);
    }

    private void HandleBuildingMode()
    {
        if (HouseBuildingManager.Instance.IsInBuildingMode)
        {
            ExitBuildingMode();
        }
        else
        {
            EnterBuildingMode();
        } 
    }

    private void EnterBuildingMode()
    {
        HouseBuildingManager.Instance.EnterBuildingMode();
        SetText("Exit Building Mode");
    }
    
    private void ExitBuildingMode()
    {
        HouseBuildingManager.Instance.ExitBuildingMode();
        SetText("Enter Building Mode");
    }

    private void OnDestroy()
    {
        RemoveAllListeners();
    }
}
