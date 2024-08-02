using System;
using TMPro;
using UnityEngine;

namespace RPG_CharacterSelect.UI
{
    public class CharacterStatsReadoutUI : MonoBehaviour
    {

        [Header("Data")] 
        [SerializeField] private RPGCharacter _previewCharacter;

        [Header("Components")]
        [SerializeField] private TMP_Text _nameTmp;
        [SerializeField] private TMP_Text _subtitleTmp;
        [SerializeField] private TMP_Text _hitPointsTmp;
        [SerializeField] private TMP_Text _startingGoldTmp;
        [SerializeField] private TMP_Text _descTmp;
        [SerializeField] private TMP_Text _racialAbilityTmp;
        [SerializeField] private TMP_Text _primaryStatTmp;

        [SerializeField] private AbilitiesReadoutUI _abilitiesReadout;
        [SerializeField] private CharacterImagePreviewerUI _imagePreviewer;

        private string _hpFormat, _goldFormat, _racialAblFormat, _primaryStatFormat;
        
        private void OnValidate()
        {
            if (!Application.isPlaying || _previewCharacter == null) return;
            SetPreviewedCharacter(_previewCharacter);
        }

        private void Awake()
        {
            _hpFormat = _hitPointsTmp.text;
            _goldFormat = _startingGoldTmp.text;
            _racialAblFormat = _racialAbilityTmp.text;
            _primaryStatFormat = _primaryStatTmp.text;
        }

        private void Start()
        {
            if (_previewCharacter != null)
                SetPreviewedCharacter(_previewCharacter);
        }

        public RPGCharacter PreviewedCharacter => _previewCharacter;
        
        public void SetPreviewedCharacter(RPGCharacter chara)
        {
            _nameTmp.text = chara.Name;
            _subtitleTmp.text = $"{chara.RaceName} {chara.ClassName}";
            _hitPointsTmp.text = string.Format(_hpFormat, chara.HitPoints);
            _startingGoldTmp.text = string.Format(_goldFormat, chara.StartingGold);
            _descTmp.text = chara.Description;

            string raceAbl = string.IsNullOrEmpty(chara.RacialAbilityName) ? "None" : chara.RacialAbilityName;
            _racialAbilityTmp.text = string.Format(_racialAblFormat, raceAbl);

            _primaryStatTmp.text = string.Format(_primaryStatFormat, chara.PrimaryStat);

            _abilitiesReadout.RepresentedCharacter = chara;
            _imagePreviewer.PreviewingImage = chara.PreviewImage;
            
            _previewCharacter = chara;
        }

    }
}
