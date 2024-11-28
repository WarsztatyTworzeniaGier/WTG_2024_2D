using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Window : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float tweenDuration = 0.2f;

    [SerializeField]
    private Ease showEase, hideEase;

    public void Show()
    {
        canvasGroup.alpha = 0f;
        gameObject.SetActive(true);
        DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 1f, tweenDuration).SetEase(showEase);
    }

    public void Hide()
    {
        DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 0f, tweenDuration)
        .SetEase(hideEase)
        .OnComplete(() => gameObject.SetActive(false));
        
        //gameObject.SetActive(false);
    }

    public void Toggle(bool toggle)
    {
        if (toggle)
        {
            Show();
        }
        else Hide();
        //animator.SetBool("IsShown", toggle);
    }


    private void Awake()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

}
