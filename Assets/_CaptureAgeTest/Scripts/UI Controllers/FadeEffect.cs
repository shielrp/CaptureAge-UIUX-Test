using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RPG_CharacterSelect.UI
{
    [RequireComponent(typeof(Image))]
    public class FadeEffect : MonoBehaviour
    {

        public float FadeTime;
        public Color FadeColor;
        public Ease FadeEase;
        public bool PlayOnStart;

        private Image _img;

        public UnityEvent EffectFinished;

        private void Awake()
        {
            _img = GetComponent<Image>();
        }

        private void Start()
        {
            if (PlayOnStart)
                FadeIn();
            else
                _img.enabled = false;
        }

        public void FadeIn()
        {
            _img.color = new Color(FadeColor.r, FadeColor.g, FadeColor.b, 1f);
            _img.enabled = true;
            IsPlaying = true;

            DOTween.Sequence()
                .Append(_img.DOFade(0f, FadeTime).SetEase(FadeEase))
                .AppendCallback(() => _img.enabled = false)
                .AppendCallback(() => EffectFinished?.Invoke())
                .AppendCallback(() => IsPlaying = false);
        }

        public void FadeOut()
        {
            _img.color = new Color(FadeColor.r, FadeColor.g, FadeColor.b, 0f);
            _img.enabled = true;
            IsPlaying = true;

            DOTween.Sequence()
                .Append(_img.DOFade(1f, FadeTime).SetEase(FadeEase))
                .AppendCallback(() => EffectFinished?.Invoke())
                .AppendCallback(() => IsPlaying = false);
        }
        
        public bool IsPlaying { get; private set; }
    }
}
