using System.Collections.Generic;
using Com.MyCompany.MyGame;
using UnityEngine;

public class ArcadeManager : MonoBehaviour, Interactable
{
    static public ArcadeManager Instance;
    
    [SerializeField]
    private EmulatorManager _emulatorManager;
    [SerializeField]
    private List<string> _gameList;
    
    [SerializeField]
    private EmulatorGameSelectionUI _emulatorGameSelectionUI;
    
    [SerializeField]
    private GameObject _selectGameButtonPrefab;

    private bool isInTrigger;

    private void Start()
    {
        Instance = this;
        PopulateVerticalLayoutGroup();
    }

    private void PopulateVerticalLayoutGroup()
    {
        foreach (var gameName in _gameList)
        {
            var buttonGameObject = Instantiate(_selectGameButtonPrefab, _emulatorGameSelectionUI.verticalLayoutGroup.transform);
            var myButton = buttonGameObject.GetComponent<MyButton>();
            myButton.SetText(gameName);
            myButton.AddListener(() => StartArcade(gameName));
        }
    }

    //On trigger enter with the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInTrigger = false;
        }
    }

    private void Update()
    {
        //if its in the trigger and the player presses the interact button
        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("ArcadeManager - Interacting");
            Interact();
        }
    }

    public void Interact()
    {
        EnterArcade();
    }
    
    public void EnterArcade()
    {
        GameManager.Instance.EnterArcade();
        UIManager.Instance.EnterArcade();
        _emulatorGameSelectionUI.gameObject.SetActive(true);
        _emulatorManager.EnterArcade();
    }
    
    public void StartArcade(string fileName)
    {
        _emulatorManager.StartArcade(fileName);
        _emulatorGameSelectionUI.gameObject.SetActive(false);
    }
    
    public void ExitArcade()
    {
        GameManager.Instance.ExitArcade();
        UIManager.Instance.ExitArcade();
        _emulatorManager.StopArcade();
    }
}
