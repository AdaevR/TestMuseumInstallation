using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanelBuilder : MonoBehaviour
{
	[SerializeField] private GameObject panel;
	[Space(10)]
	[SerializeField] private Image _photo;
	[SerializeField] private TextMeshProUGUI _text;
	[SerializeField] private Transform _galleryObject;
	[Space(10)]
	[SerializeField] private Image _galleryPhotoPrefab;

	public void Build(InfoPanelData data)
	{
		panel.SetActive(true);
		panel.transform.DOScale(Vector3.one, 0.5f).ChangeStartValue(Vector3.zero);

		_photo.sprite = data.infoPhoto;
		_text.text = data.infoText;

		foreach (Sprite photo in data.galleryPhotos)
		{
			Image photoObject = Instantiate(_galleryPhotoPrefab, _galleryObject);
			photoObject.sprite = photo;
		}
	}

	public void Close()
	{
		while (_galleryObject.childCount > 0)
		{
			DestroyImmediate(_galleryObject.GetChild(0).gameObject);
		}

		panel.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => panel.gameObject.SetActive(false));
	}
}
