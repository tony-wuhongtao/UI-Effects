using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] public float fadeTime = 1.0f;
    [SerializeField] public CanvasGroup canvasGroup;
    [SerializeField] public RectTransform rectTransform;
    [SerializeField] private List<GameObject> items = new List<GameObject>();
    private AudioSource _audioSource;
    [SerializeField] private AudioClip popupSFX;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PanelFadeIn()
    {
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0f, -1300f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
        StartCoroutine(nameof(ItemsAnimationCoroutine));
    }
    
    public void PanelFadeOut()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1300f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(1, fadeTime);
    }

    IEnumerator ItemsAnimationCoroutine()
    {
        foreach (var item in items)
        {
            item.transform.localScale = Vector3.zero;
        }

        foreach (var item in items)
        {
            _audioSource.PlayOneShot(popupSFX);
            Tween tween = item.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
            // yield return new WaitForSeconds(0.25f);
            yield return tween.WaitForCompletion();
        }
    }
}
