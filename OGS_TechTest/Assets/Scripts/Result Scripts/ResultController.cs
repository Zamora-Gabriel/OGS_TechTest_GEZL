using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    [SerializeField] private GameObject _resultImageContainer;

    [SerializeField] private float _durationOfParticleEffects;

    [SerializeField] private GameObject[] _particlesPrefabs;

    [SerializeField] private GameObject[] _itemPrefabs;

    [SerializeField] private GameObject _resultDialogBox;

    void OnEnable()
    {
        ActivateDialogBox(false);
        InstantiateResultingItem();
    }

    void OnDisable()
    {
        StopAllCoroutines();
        foreach (Transform child in _resultImageContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void InstantiateResultingItem()
    {
        if (AlchemyMenuManager.Instance.OptionSelected == SELECTEDOPTION.FUSION)
        {
            StartCoroutine(ResultingItemDisplay(true));
            return;
        }

        StartCoroutine(ResultingItemDisplay(false));
    }

    IEnumerator ResultingItemDisplay(bool isFusion)
    {
        float timeElapsed = 0;
        int itemIndex = isFusion? 0 : (int)AlchemyMenuManager.Instance.ItemSelected + 1;

        // Instantiate the particles
        Instantiate(_particlesPrefabs[itemIndex], _resultImageContainer.transform);

        while (timeElapsed < _durationOfParticleEffects)
        {
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Instantiate the selected item prefab
        Instantiate(_itemPrefabs[itemIndex], _resultImageContainer.transform);
        ActivateDialogBox(true);
    }

    private void ActivateDialogBox(bool option)
    {
        _resultDialogBox.SetActive(option);
    }
}
