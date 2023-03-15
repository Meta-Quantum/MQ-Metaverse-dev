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
    private Character _character;
    
    private bool _inArcade;
    private bool _inPainting;

    private void Start()
    {
        GameManager.Instance.localPlayerController = this;
        _character = GetComponent<Character>();
        
        //Set tag to Player
        gameObject.tag = "Player";
        
        //Instantiate the third person camera
        var transform1 = transform;
        _cameraGameObject = Instantiate(thirdPersonCameraPrefab, transform1.position, transform1.rotation);
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

    private void ExitArcade()
    {
        _inArcade = false;
        _character.enabled = true;
        _cameraGameObject.SetActive(true);
        _mannequin.SetActive(true);
    }

    private void EnterArcade()
    {
        _inArcade = true;
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
