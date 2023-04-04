using System;
using Com.MyCompany.MyGame;
using GameCreator.Runtime.Characters;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    private GameObject thirdPersonCameraPrefab;
    [SerializeField]
    private GameObject _mannequin;
    private GameObject _cameraGameObject;
    private ThirdPersonCamera _thirdPersonCamera;
    private Character _character;
    
    private bool _inArcade;
    private bool _inPainting;
    private bool _inBuildingMode;
    private bool _inMouseUIMode;

    private void Start()
    {
        GameManager.Instance.localPlayerController = this;
        _character = GetComponent<Character>();
        
        //Set tag to Player
        gameObject.tag = "Player";
        
        //Instantiate the third person camera
        var transform1 = transform;
        _cameraGameObject = Instantiate(thirdPersonCameraPrefab, transform1.position, transform1.rotation);
        _thirdPersonCamera = _cameraGameObject.GetComponent<ThirdPersonCamera>();
        
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("UIMode"))
        {
            GetInMouseUIMode(true);
        }
        
        if(_inMouseUIMode && Input.GetMouseButtonUp(0) && !UIManager.Instance.IsPointerOverUI())
        {
            GetInMouseUIMode(false);
        }
    }

    public void GetInArcade(bool inArcade)
    {
        if (inArcade)
        {
            EnterArcade();
        }
        else
        {
            ExitArcade();
        }
    }
    
    public void GetInPainting(bool inPainting)
    {
        if (inPainting)
        {
            EnterPainting();
        }
        else
        {
            ExitPainting();
        }
    }
    
    public void GetInBuildingMode(bool inBuildingMode)
    {
        if (inBuildingMode)
        {
            EnterBuildingMode();
        }
        else
        {
            ExitBuildingMode();
        }
    }
    
    public void GetInMouseUIMode(bool inMouseUIMode)
    {
        if (inMouseUIMode)
        {
            EnterMouseUIMode();
        }
        else
        {
            ExitMouseUIMode();
        }
    }

    private void ExitBuildingMode()
    {
        _inBuildingMode = false;
        _character.enabled = true;
        _cameraGameObject.SetActive(true);
        _mannequin.SetActive(true);
    }

    private void EnterBuildingMode()
    {
        _inBuildingMode = true;
        _character.enabled = false;
        _cameraGameObject.SetActive(false);
        _mannequin.SetActive(false);
    }
    
    private void ExitMouseUIMode()
    {
        Cursor.visible = false;
        _inMouseUIMode = false;
        _character.enabled = true;
        _thirdPersonCamera.UpdateCameraStatus(true);
    }

    private void EnterMouseUIMode()
    {
        Cursor.visible = true;
        _inMouseUIMode = true;
        _character.enabled = false;
        _thirdPersonCamera.UpdateCameraStatus(false);
    }

    private void ExitArcade()
    {
        _inArcade = false;
        Cursor.visible = false;
        _character.enabled = true;
        _cameraGameObject.SetActive(true);
        _mannequin.SetActive(true);
    }

    private void EnterArcade()
    {
        _inArcade = true;
        Cursor.visible = true;
        _character.enabled = false;
        _cameraGameObject.SetActive(false);
        _mannequin.SetActive(false);
    } 
    
    private void ExitPainting()
    {
        _inPainting = false;
        _character.enabled = true;
        _cameraGameObject.SetActive(true);
        _mannequin.SetActive(true);
    }

    private void EnterPainting()
    {
        _inPainting = true;
        _character.enabled = false;
        _cameraGameObject.SetActive(false);
        _mannequin.SetActive(false);
    } 
}
