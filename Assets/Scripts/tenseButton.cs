using UnityEngine;
//needed to access button
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
//needed to do scene thing
using DG.Tweening;

public class tenseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    private Vector3 initScale;
    [SerializeField] AudioSource newAudio;
    private Tween tween;
    private float scaleBy = 1.1f;
    private float duration = 0.5f;
    private RectTransform rect;
    private Vector3 scaleTo;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rect = GetComponent<RectTransform>();
        initScale = transform.localScale;
        //newAudio.SetActive(false);
        //scaleTo = initPos * scaleBy;
    }

    void pulse()
    {
        tween = transform.DOScale(scaleBy * initScale, duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    public void OnPointerEnter(PointerEventData pointerData)
    {
        pulse();
        newAudio?.Play();
    }

    public void OnPointerExit(PointerEventData pointerData)
    {
        tween?.Kill();
        tween = transform.DOScale(initScale, duration).SetEase(Ease.OutBack);
        //newAudio.SetActive(false);
        newAudio?.Stop();
    }

}
