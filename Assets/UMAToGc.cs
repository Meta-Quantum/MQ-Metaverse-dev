using GameCreator.Runtime.Characters;
using UnityEngine;

public class UMAToGc : MonoBehaviour
{
    [SerializeField] private GameObject _umaPrefab;
    [SerializeField] private Character _character;

    void Start()
    {
        _character.ChangeModel(_umaPrefab, new Character.ChangeOptions());
    }
}
