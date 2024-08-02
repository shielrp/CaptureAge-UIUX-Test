using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_CharacterSelect.UI
{
    [RequireComponent(typeof(Button))]
    public class UIButtonSoundPlayer : MonoBehaviour
    {

        public AudioClip ButtonClickSound;

        [SerializeField] private AudioSource _source;

        private Button _btn;

        private void Awake()
        {
            _btn = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _btn.onClick.AddListener(PlaySound);
        }

        private void OnDisable()
        {
            _btn.onClick.RemoveListener(PlaySound);
        }

        public void PlaySound()
        {
            _source.PlayOneShot(ButtonClickSound);
        }
    }
}
