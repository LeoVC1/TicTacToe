using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIModal : MonoBehaviour
{
    [SerializeField] protected Image blackBackground;
    [SerializeField] protected RectTransform modalTransform;

    [SerializeField] protected bool openInStart;

    protected virtual void Start()
    {
        if (openInStart)
            OpenModal();
    }

    public virtual void OpenModal()
    {
        blackBackground.raycastTarget = true;
        StartCoroutine(Fade(1, 0.4f));
    }

    public virtual void CloseModal()
    {
        blackBackground.raycastTarget = false;
        StartCoroutine(Fade(0, 0.4f));
    }

    protected virtual IEnumerator Fade(float scale, float duration)
    {
        blackBackground.DOFade(scale * 0.6f, duration);

        Tweener t = modalTransform.DOScale(Vector3.one * scale, duration);

        yield return t.WaitForCompletion();
    }
}
