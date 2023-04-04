using System.Collections.Generic;
using Com.MyCompany.MyGame;
using UnityEngine;

public class Storefront : MonoBehaviour
{
	[SerializeField] private StorefrontUI _storefrontUI;
	[SerializeField] private List<Land> _lands;
	private bool _isInTrigger;
	
	private void Start()
	{
		_storefrontUI.gameObject.SetActive(false);
		_storefrontUI.PopulateUI(_lands);
	}
	
	private void Update()
	{
		//if its in the trigger and the player presses the interact button
		if (_isInTrigger && Input.GetKeyDown(KeyCode.E))
		{
			UIManager.Instance.EnterStoreFrontMode();
			GameManager.Instance.EnterMouseUIMode();
		}
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			_isInTrigger = true;
		}
	}
	
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			_isInTrigger = false;
		}
	}
}
