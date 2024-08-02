using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RPG_CharacterSelect.UI
{
    [RequireComponent(typeof(Button))]
    public class CharacterSelectButtonUI : MonoBehaviour
    {

        [Header("Data")]
        public bool SelectOnStart = false;
        [SerializeField] private RPGCharacter _associatedCharacter;

        [Header("Components")] 
        [SerializeField] private Image _portraitImage;
        [SerializeField] private TMP_Text _nameTmp;
        [SerializeField] private TMP_Text _descTmp;

        public UnityEvent<RPGCharacter> OnSelected;
        
        private Button _btn;

        private void OnValidate()
        {
            FormatFor(_associatedCharacter);
        }

        private void Awake()
        {
            _btn = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _btn.onClick.AddListener(Select);
        }

        private void OnDisable()
        {
            _btn.onClick.RemoveListener(Select);
        }

        private void Start()
        {
            if (SelectOnStart) Select();
        }

        private void FormatFor(RPGCharacter chara)
        {
            if (chara == null) return;
            
            _portraitImage.sprite = chara.PortraitIcon;
            _nameTmp.text = chara.Name;
            _descTmp.text = $"{chara.RaceName} {chara.ClassName}";
        }
        
        public RPGCharacter AssociatedCharacter
        {
            get => _associatedCharacter;
            set
            {
                _associatedCharacter = value;
                FormatFor(_associatedCharacter);
            }
        }

        public void Select()
        {
            OnSelected?.Invoke(_associatedCharacter);
        }

    }
}
