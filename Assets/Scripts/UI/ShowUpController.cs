using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShowUpController : MonoBehaviour
{
    [SerializeField] public float fadeTime = 1.0f;
    [SerializeField] private GameObject showPlayer;
    [SerializeField] private GameObject showUI;
    [SerializeField] private GameObject vfx;

    public void Showup()
    {
        vfx.SetActive(true);
        vfx.transform.DOScale(0.1f, fadeTime).SetEase(Ease.Linear);
        showPlayer.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
        showPlayer.transform.DORotate(new Vector3(0,250,0), fadeTime, RotateMode.FastBeyond360).SetEase(Ease.InOutCubic);

    }
    public void Showdown()
    {
        StartCoroutine(nameof(AnimationCoroutine));
        
        
    }

    IEnumerator AnimationCoroutine()
    {
        vfx.transform.DOScale(0f, fadeTime/3).SetEase(Ease.Linear);
        
        Tween tween = showPlayer.transform.DOScale(0f, fadeTime).SetEase(Ease.InFlash);
        showPlayer.transform.DORotate(new Vector3(0,-360,0), fadeTime, RotateMode.FastBeyond360).SetEase(Ease.InSine);
        yield return tween.WaitForCompletion();
        vfx.SetActive(false);
        showUI.SetActive(false);
    }
}
