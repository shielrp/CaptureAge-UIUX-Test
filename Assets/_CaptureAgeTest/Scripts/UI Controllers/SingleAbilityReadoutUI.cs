using TMPro;
using UnityEngine;

namespace RPG_CharacterSelect.UI
{
    public class SingleAbilityReadoutUI : MonoBehaviour
    {

        [Header("Components")]
        [SerializeField] private TMP_Text _baseAblTmp;
        [SerializeField] private TMP_Text _ablModTmp;
        [SerializeField] private TMP_Text _totalAblTmp;

        public void SetValues(int totalScore, int racialMod)
        {
            _totalAblTmp.text = $"{totalScore}";
            _baseAblTmp.text = $"{totalScore - racialMod}";

            if (racialMod < 0)
                _ablModTmp.text = $"{racialMod}";
            else if (racialMod == 0)
                _ablModTmp.text = "";
            else
                _ablModTmp.text = $"+{racialMod}";
        }
        
    }
}
