using UnityEngine;

namespace RPG_CharacterSelect
{
    
    [CreateAssetMenu(menuName = "CharacterSelect/RPG Character")]
    public class RPGCharacter : ScriptableObject
    {

        [Header("Basic Info")] 
        public string Name;
        [TextArea] public string Description;
        public Sprite PortraitIcon;
        public Sprite PreviewImage;
        
        public int HitPoints;
        public int StartingGold;

        public AbilltyValues AbilityScores;

        [Header("Race")]
        public string RaceName;
        public string RacialAbilityName;
        
        public AbilltyValues RaceMinimumStat;
        public AbilltyValues RaceAbilityModifier;

        [Header("Class")] 
        public string ClassName;
        public int HitDiceAmount;
        public int HitDiceValue;
        public string PrimaryStat;

        public AbilltyValues BaseAbilityScores
        {
            get
            {
                return new AbilltyValues()
                {
                    STR = AbilityScores.STR - RaceAbilityModifier.STR,
                    DEX = AbilityScores.DEX - RaceAbilityModifier.DEX,
                    CON = AbilityScores.CON - RaceAbilityModifier.CON,
                    INT = AbilityScores.INT - RaceAbilityModifier.INT,
                    WIS = AbilityScores.WIS - RaceAbilityModifier.WIS,
                    CHA = AbilityScores.CHA - RaceAbilityModifier.CHA,
                };
            }
        }

    }
}
