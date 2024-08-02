using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_CharacterSelect.UI
{
    [RequireComponent(typeof(Image))]
    public class FadeInEffect : MonoBehaviour
    {

        public float FadeTime;
        public Color FadeColor;
        public Ease FadeEase;
        public bool PlayOnStart;

        private Image _img;

        private void Awake()
        {
            _img = GetComponent<Image>();
        }

        private void Start()
        {
            if (PlayOnStart)
                PlayEffect();
            else
                _img.enabled = false;
        }

        public void PlayEffect()
        {
            _img.color = new Color(FadeColor.r, FadeColor.g, FadeColor.b, 1f);
            _img.enabled = true;

            DOTween.Sequence()
                .Append(_img.DOFade(0f, FadeTime).SetEase(FadeEase))
                .AppendCallback(() => _img.enabled = false);
        }
    }
}