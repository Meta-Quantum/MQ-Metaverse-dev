using GameCreator.Runtime.Characters;
using Photon.Pun;
using UnityEngine;

public class UMAToGc : MonoBehaviour
{
    [SerializeField] private GameObject _umaPrefab;
    [SerializeField] private Character _character;

    void Start()
    {
        var newModel = _character.ChangeModel(_umaPrefab, new Character.ChangeOptions());
        var photonView = GetComponent<PhotonView>();
        var gcPhotonAnimatorView = newModel.GetComponent<PhotonAnimatorView>();
        photonView.ObservedComponents.Add(gcPhotonAnimatorView);
    }
}
