using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestPoint : MonoBehaviour
{
	[SerializeField] private InfoPanelData panelData;
	private InfoPanelBuilder infoPanelBuilder;

	private void Awake()
	{
		infoPanelBuilder = FindObjectOfType<InfoPanelBuilder>();
	}

	public void Open()
	{
		infoPanelBuilder.Build(panelData);
	}
}
