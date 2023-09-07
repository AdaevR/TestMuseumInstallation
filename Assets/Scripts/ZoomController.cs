using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZoomController : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _lable;
	[SerializeField] private Slider _zoomSlider;
	[Space(10)]
	[SerializeField] private float _toTargetTime = 0.5f;
	[SerializeField] private float _buttonStep = 0.05f;
	[SerializeField] private float _maxZoom = 1.5f;
	[SerializeField] private float _minZoom = 0.5f;

	private Camera _camera;
	private TouchMovement _touchMovement;

	private Tween _cameraTween;
	private float _cameraInitialSize;
	private float _targetZoom = 1f;

	private void Awake()
	{
		_camera = FindObjectOfType<Camera>();
		_touchMovement = _camera.GetComponent<TouchMovement>();
	}

	private void Start()
	{
		_cameraInitialSize = _camera.orthographicSize;

		_zoomSlider.maxValue = _maxZoom;
		_zoomSlider.minValue = _minZoom;
		_zoomSlider.value = ReverseZoomValue(_targetZoom);
	}

	public void OnSliderValueChanged()
	{
		_targetZoom = ReverseZoomValue(_zoomSlider.value);
		Zoom();
		UpdateLable();
	}

	public void OnButtonPressed(int sign)
	{
		_targetZoom += _buttonStep * sign;
		_targetZoom = Mathf.Clamp(_targetZoom, _minZoom, _maxZoom);
		_zoomSlider.value = ReverseZoomValue(_targetZoom);
	}

	private void Zoom()
	{
		_cameraTween?.Kill();
		_cameraTween = _camera.DOOrthoSize(_cameraInitialSize * _targetZoom, _toTargetTime).OnUpdate(()=> 
		{
			_touchMovement.ClampCameraInBorders(_camera.transform.position);
		});
	}

	private void UpdateLable()
	{
		_lable.text = (int)Math.Round(_targetZoom * 100) + "%";
	}

	private float ReverseZoomValue(float value)
	{
		return -value + _maxZoom + _minZoom;
	}
}
