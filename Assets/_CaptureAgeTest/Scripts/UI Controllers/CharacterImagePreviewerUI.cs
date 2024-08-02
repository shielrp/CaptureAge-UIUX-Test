using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_CharacterSelect.UI
{
    public class CharacterImagePreviewerUI : MonoBehaviour
    {

        [Header("Data")]
        public float ImageFadeTime;
        [SerializeField] private Sprite _previewingImage;

        [Header("Components")] 
        [SerializeField] private Image _previewImg1;
        [SerializeField] private Image _previewImg2;

        private Sprite _currentlyShowingImage;

        private void Start()
        {
            if (_previewingImage != null)
                SwitchToImage(_previewingImage);
        }

        private void OnValidate()
        {
            if (!Application.isPlaying) return;
            
            SwitchToImage(_previewingImage);
        }

        private void SwitchToImage(Sprite spr)
        {
            if (spr == null || spr == _currentlyShowingImage) return;

            _currentlyShowingImage = spr;
            
            Image newImg =
                _previewImg1.transform.GetSiblingIndex() < _previewImg2.transform.GetSiblingIndex()
                    ? _previewImg1 : _previewImg2;

            newImg.color = new Color(1f, 1f, 1f, 0f);
            newImg.sprite = _currentlyShowingImage;
            newImg.transform.SetAsLastSibling();

            newImg.DOFade(1f, ImageFadeTime);
        }
        
        public Sprite PreviewingImage
        {
            get => _previewingImage;
            set
            {
                _previewingImage = value;
                SwitchToImage(_previewingImage);
            }
        }

    }
}
