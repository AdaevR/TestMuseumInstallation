using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InfoPanelData")]
public class InfoPanelData : ScriptableObject
{
	public Sprite infoPhoto;
	[TextArea]
	public string infoText;
	public List<Sprite> galleryPhotos;
}