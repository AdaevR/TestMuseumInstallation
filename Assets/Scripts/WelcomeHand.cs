using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeHand : MonoBehaviour
{
	private ResetTimer _resetTimer;
	private Image _background;
	private Image _hand;

	private void Awake()
	{
		_background = GetComponent<Image>();
		_hand = transform.GetChild(0).GetComponent<Image>();

		_resetTimer = FindObjectOfType<ResetTimer>();
	}

	public void OpenMap()
	{
		Color transparent = new Color(1, 1, 1, 0);
		_background.DOColor(transparent, 0.5f).OnComplete(() => gameObject.SetActive(false));
		_hand.DOColor(transparent, 0.5f);
		_resetTimer.isActive = true;
	}
}
