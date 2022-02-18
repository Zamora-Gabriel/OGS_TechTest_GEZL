using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RouletteController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // Roulette GameObject
    [SerializeField] private int _rotationSpeed = 1;
    // Speed for auto adjustment
    [SerializeField] private int _autoRotationSpeed = 2;
    [SerializeField] private bool isOptionRoulette = true;
    [SerializeField] private float[] _rouletteItemCenters;

    [Header("Outer Wheel Game Object")]
    [SerializeField] private GameObject _outerWheel;

    // Float value for the rotation velocity of the roulette
    private float _rotationVelocity;
    private float _angleToAdjust;

    private void Awake()
    {
        // Check the number of items and the centers given
        if(isOptionRoulette && _rouletteItemCenters.Length != AlchemyMenuManager.Instance.numberOfOptions)
        {
            // Print an error to show that the number of items and centers should be equal
            Debug.LogError("the number of angle centers given is not equal to the number of options of the wheel");
        }

        if (!isOptionRoulette && _rouletteItemCenters.Length != AlchemyMenuManager.Instance.numberOfFamilies)
        {
            // Print an error to show that the number of items and centers should be equal
            Debug.LogError("the number of angle centers given is not equal to the number of families of the wheel");
        }
    }

    // Being dragged
    public void OnDrag(PointerEventData eventData)
    {
        // Translate pointer drag to rotation
        _rotationVelocity = eventData.delta.x * _rotationSpeed;
        transform.Rotate(Vector3.forward, -_rotationVelocity, Space.Self);
    }

    // When the item is dragged
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Stop Positioning coroutines
        StopAllCoroutines();
    }

    // Item released from drag
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!AlchemyMenuManager.Instance.IsOptionSelected)
        {
            SetOptionAngle();
        }
        else if(!AlchemyMenuManager.Instance.IsFamilySelected)
        {
            SetFamilyAngle();
        }
        else
        {
            SetItemWheelAngle();
        }
        CenterRoulette();
    }

    // Center the roulette to the item/option is touching
    private void CenterRoulette()
    {
        StartCoroutine(CenterToAngle());
    }

    // Option angles
    private void SetOptionAngle()
    {
        switch (AlchemyMenuManager.Instance.OptionSelected)
        {
            case SELECTEDOPTION.FUSION:
                _angleToAdjust =  _rouletteItemCenters[0];
                return;
            case SELECTEDOPTION.DISCOVER:
                _angleToAdjust = _rouletteItemCenters[1];
                return;
            case SELECTEDOPTION.FORGE:
                _angleToAdjust = _rouletteItemCenters[2];
                return;
            default:
                _angleToAdjust = _rouletteItemCenters[3];
                return;
        }
    }

    // Rune Family angles
    private void SetFamilyAngle()
    {
        switch (AlchemyMenuManager.Instance.FamilySelected)
        {
            case SELECTEDFAMILY.RED:
                _angleToAdjust = _rouletteItemCenters[0];
                break;
            case SELECTEDFAMILY.YELLOW:
                _angleToAdjust = _rouletteItemCenters[1];
                break;
            case SELECTEDFAMILY.GREEN:
                _angleToAdjust = _rouletteItemCenters[2];
                break;
            case SELECTEDFAMILY.CYAN:
                _angleToAdjust = _rouletteItemCenters[3];
                break;
            case SELECTEDFAMILY.BLUE:
                _angleToAdjust = _rouletteItemCenters[4];
                break;
            default:
                _angleToAdjust = _rouletteItemCenters[5];
                break;
        }
    }

    // Rune Fitem angles
    private void SetItemWheelAngle()
    {
        _angleToAdjust = _rouletteItemCenters[AlchemyMenuManager.Instance.SelectedItemIndex];
    }

    IEnumerator CenterToAngle()
    {
        bool rotating = true;

        // Coroutine to center to the selected item
        while (rotating)
        {
            Vector3 adjustedAngle = new Vector3(0, 0, _angleToAdjust);
            if (Vector3.Distance(transform.eulerAngles, adjustedAngle) > 0.01f)
            {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, adjustedAngle, Time.deltaTime * _autoRotationSpeed);
            }
            else
            {
                transform.eulerAngles = adjustedAngle;
                rotating = false;
            }

            yield return null;
        }
    }

    // Rotate the outer wheel to match selected option
    public void SetOuterWheelRotation()
    {
        Vector3 outerAngle = new Vector3(0, 0, _angleToAdjust);
        _outerWheel.transform.eulerAngles = outerAngle;
    }
}
