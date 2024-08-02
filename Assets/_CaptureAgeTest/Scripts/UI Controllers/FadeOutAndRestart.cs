using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG_CharacterSelect.UI
{
    public class FadeOutAndRestart : MonoBehaviour
    {

        public float EffectLength;
        public FadeEffect Fader;

        public void DoEffect()
        {
            Fader.FadeTime = EffectLength;
            
            Fader.EffectFinished.AddListener(FinishEffect);
            Fader.FadeOut();
        }

        private void FinishEffect()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
