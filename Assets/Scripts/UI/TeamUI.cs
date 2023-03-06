using TMPro;
using UnityEngine;

    public class TeamUI: MonoBehaviour
    {
        public TMP_Text countText;
        public TMP_Text hpText;
        public TMP_Text finalText;

        [SerializeField] private string teamName;
        [SerializeField] private string dieText;
        [SerializeField] private string winText;


        public void Attach(Stats stats)
        {
            stats.OnCountUpdate += UpdateCount;
            stats.OnHpUpdate += UpdateHp;
            stats.OnWin += WinUpdate;
            stats.OnDie += Die;

        }

        private void UpdateHp(int hp)
        {
            hpText.text = $"{teamName} Team Lives: {hp}" ;
        }

        private void UpdateCount(int count)
        {
            countText.text = $"{teamName} Team Points: {count}";
        }

        private void Die()
        {
            // Move this line to some game manager
            Time.timeScale = 0f;
            finalText.text = dieText;
        }

        private void WinUpdate()
        {
            // Move this line to some game manager
            Time.timeScale = 0f;
            finalText.text = winText;
        }

    }
