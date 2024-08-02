using System;
using UnityEngine;

namespace RPG_CharacterSelect.UI
{
    public class AbilitiesReadoutUI : MonoBehaviour
    {

        [Header("Data")]
        [SerializeField] private RPGCharacter _currentlyRepresentedCharacter;

        [Header("Components")]
        [SerializeField] private SingleAbilityReadoutUI _str;
        [SerializeField] private SingleAbilityReadoutUI _dex;
        [SerializeField] private SingleAbilityReadoutUI _con;
        [SerializeField] private SingleAbilityReadoutUI _int;
        [SerializeField] private SingleAbilityReadoutUI _wis;
        [SerializeField] private SingleAbilityReadoutUI _cha;

        private void OnValidate()
        {
            if (!Application.isPlaying || _currentlyRepresentedCharacter == null) return;
            
            SetFields(_currentlyRepresentedCharacter);
        }

        private void Start()
        {
            if (_currentlyRepresentedCharacter != null)
                SetFields(_currentlyRepresentedCharacter);
        }

        private void SetFields(RPGCharacter chara)
        {
            _str.SetValues(chara.AbilityScores.STR, chara.RaceAbilityModifier.STR);
            _dex.SetValues(chara.AbilityScores.DEX, chara.RaceAbilityModifier.DEX);
            _con.SetValues(chara.AbilityScores.CON, chara.RaceAbilityModifier.CON);
            _int.SetValues(chara.AbilityScores.INT, chara.RaceAbilityModifier.INT);
            _wis.SetValues(chara.AbilityScores.WIS, chara.RaceAbilityModifier.WIS);
            _cha.SetValues(chara.AbilityScores.CHA, chara.RaceAbilityModifier.CHA);
        }
        
        public RPGCharacter RepresentedCharacter
        {
            get => _currentlyRepresentedCharacter;
            set
            {
                _currentlyRepresentedCharacter = value;
                SetFields(_currentlyRepresentedCharacter);
            }
        }
        
    }
}
