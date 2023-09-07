using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class TouchMovement : MonoBehaviour
{
	[SerializeField] private Image _imageBorders;
	
	private Camera _camera;

	private Vector3 _startPosition;
	private bool _isInMovement = false;
	private Vector3 borders;

	private void Awake()
	{
		_camera = GetComponent<Camera>();
	}

	private void Start()
	{
		borders = new Vector3();
		borders.x = _imageBorders.rectTransform.rect.width / 2;
		borders.y = _imageBorders.rectTransform.rect.height / 2;
	}

	private void Update()
    {
		if (Input.touches.Length == 1)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
			{
				_startPosition = Camera.main.ScreenToWorldPoint(touch.position);
				_isInMovement = true;
			}

			if (touch.phase == TouchPhase.Moved && _isInMovement)
			{
				Vector3 currentPosition = Camera.main.ScreenToWorldPoint(touch.position);
				Vector3 movedPosition = transform.position + (_startPosition - currentPosition);
				ClampCameraInBorders(movedPosition);
			}

			if (touch.phase == TouchPhase.Ended && _isInMovement)
			{
				_isInMovement = false;
			}
		}
    }

	public void ClampCameraInBorders(Vector3 newPosition)
	{
		float aspect = (float)Screen.width / Screen.height;
		float worldHeight = _camera.orthographicSize * 2;
		float worldWidth = worldHeight * aspect;

		newPosition.x = Mathf.Clamp(newPosition.x, -borders.x + worldWidth / 2, borders.x - worldWidth / 2);
		newPosition.y = Mathf.Clamp(newPosition.y, -borders.y + worldHeight / 2, borders.y - worldHeight / 2);
		transform.position = newPosition;

	}
}
