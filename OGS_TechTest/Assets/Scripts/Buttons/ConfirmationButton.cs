using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConfirmationButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [Header("Charging Bar Variables")]
    [SerializeField] private Image _chargeBar;
    [SerializeField] private float _lerpDuration = 0.25f;
    [SerializeField] private Image _bttnImage;

    // Observer pattern events
    [Header("Operation Events")]
    [SerializeField] UnityEvent fusionOperation;
    [SerializeField] UnityEvent discoverOperation;
    [SerializeField] UnityEvent forgeOperation;
    [SerializeField] UnityEvent mixOperation;

    private bool _enabled = true;

    // Disable/Enable image
    public void ButtonEnable(bool enable)
    {
        _enabled = enable;

        if (!enable)
        {
            // Increase transparency to show disabled
            _bttnImage.color = new Color(1, 1, 1, 0.3f);
            return;
        }

        // Change transparency to show enabled button
        _bttnImage.color = new Color(1, 1, 1, 1f);
    }

    // Stop charge and empty the bar
    public void ReleaseCharge()
    {
        StopAllCoroutines();
        _chargeBar.fillAmount = 0;
    }

    private IEnumerator LerpBar()
    {
        float current = _chargeBar.fillAmount;
        float target = 1f;
        float timer = 0f;
        float duration = _lerpDuration;

        // Charge the bar
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;
            float lerped = Mathf.Lerp(current, target, progress);
            _chargeBar.fillAmount = lerped;

            yield return null;
        }

        // Invoke operation according to the selected one
        UpdateOptionUI();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_enabled)
        {
            // Start charging
            StartCoroutine(LerpBar());
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_enabled)
        {
            // Stop charging
            ReleaseCharge();
        }
    }

    // Operation event caller
    private void UpdateOptionUI()
    {
        switch (AlchemyMenuManager.Instance.OptionSelected)
        {
            case SELECTEDOPTION.FORGE:
                forgeOperation.Invoke();
                break;
            case SELECTEDOPTION.DISCOVER:
                discoverOperation.Invoke();
                break;
            case SELECTEDOPTION.FUSION:
                fusionOperation.Invoke();
                break;
            default:
                mixOperation.Invoke();
                break;
        }
    }
}
