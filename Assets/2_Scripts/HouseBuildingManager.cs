using System.Collections;
using System.Collections.Generic;
using Photon.Pun.Demo.PunBasics;
using Plugins.CodeMonkey.HouseBuildingSystem.Scripts;
using UnityEngine;
using GameManager = Com.MyCompany.MyGame.GameManager;

public class HouseBuildingManager : MonoBehaviour
{
    static public HouseBuildingManager Instance;
    
    [SerializeField] private HouseBuildingSystem houseBuildingSystem;
    
    private void Start()
    {
        Instance = this;
    }
    
    public void EnterBuildingMode()
    {
        houseBuildingSystem.UpdateHouseBuildingSystemStatus(true);
        GameManager.Instance.EnterBuildingMode();
        UIManager.Instance.EnterBuildingMode();
    }
    
    public void ExitBuildingMode()
    {
        houseBuildingSystem.UpdateHouseBuildingSystemStatus(false);
        GameManager.Instance.ExitBuildingMode();
        UIManager.Instance.ExitBuildingMode();
    }
    
    public bool IsInBuildingMode => houseBuildingSystem.IsHouseBuildingSystemActive();
}
