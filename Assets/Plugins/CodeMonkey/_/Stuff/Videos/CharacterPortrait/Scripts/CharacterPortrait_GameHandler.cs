/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey.MonoBehaviours;

public class CharacterPortrait_GameHandler : MonoBehaviour {

    public static CharacterPortrait_GameHandler instance;
    public Canvas canvas;
    public Transform pfWindow_CharacterPortrait;

    [SerializeField] private CameraFollow cameraFollow = null;
    private Vector3 cameraFollowPosition = new Vector3(-134, -50);
    
    [SerializeField] private Transform characterTransform = null;
    [SerializeField] private Transform secondCharacterTransform = null;

    private MonkeyCharacter _rifleMonkeyCharacter;
    private MonkeyCharacter _swordMonkeyCharacter;

    private void Awake() {
        instance = this;
        cameraFollow.Setup(() => cameraFollowPosition, () => 80f, true, true);
        SetupCharacters();
    }

    private void Start() {
        characterTransform.GetComponent<Button_Sprite>().ClickFunc = () => {
            Window_CharacterPortrait.Show_Static(_rifleMonkeyCharacter);
        };
        secondCharacterTransform.GetComponent<Button_Sprite>().ClickFunc = () => {
            Window_CharacterPortrait.Show_Static(_swordMonkeyCharacter);
        };
    }

    private void Update() {
        HandleCameraMovement();
    }





    private void SetupCharacters() {
        _rifleMonkeyCharacter = new MonkeyCharacter(characterTransform, "Neo");
        _swordMonkeyCharacter = new MonkeyCharacter(secondCharacterTransform, "Leonidas");
    }

    private void HandleCameraMovement() {
        float cameraMoveSpeed = 200f;
        if (Input.GetKey(KeyCode.W)) { cameraFollowPosition.y += cameraMoveSpeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.S)) { cameraFollowPosition.y -= cameraMoveSpeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.A)) { cameraFollowPosition.x -= cameraMoveSpeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.D)) { cameraFollowPosition.x += cameraMoveSpeed * Time.deltaTime; }
    }

}
