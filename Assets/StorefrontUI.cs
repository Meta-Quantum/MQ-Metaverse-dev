using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorefrontUI : MonoBehaviour
{
	[SerializeField] private GameObject _landPrefab;
	[SerializeField] private VerticalLayoutGroup _landVerticalLayoutGroup;
	
	public void PopulateUI(List<Land> lands)
	{
		foreach (var land in lands)
		{
			var landGO = Instantiate(_landPrefab, _landVerticalLayoutGroup.transform);
		}
	}
}
