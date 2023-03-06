
    using TMPro;
    using UnityEngine;

    public class PlayerUI: MonoBehaviour
    {
        public TMP_Text countText;
        public TMP_Text hpText;
        public TMP_Text finalText;


        public void AttachPlayer(PlayerStats playerStats)
        {
            playerStats.OnCountUpdate += UpdateCount;
            playerStats.OnHpUpdate += UpdateHp;
            playerStats.OnWin += WinUpdate;
            playerStats.OnDie += Die;
        }

        private void UpdateHp(int hp)
        {
            hpText.text = "Blue Team Lives: " + hp;
        }

        private void UpdateCount(int count)
        {
            countText.text = "Blue Team Points: " + count;
        }

        private void Die()
        {
            // Move this line to some game manager
            Time.timeScale = 0f;
            finalText.text = "You died";
        }

        private void WinUpdate()
        {
            // Move this line to some game manager
            Time.timeScale = 0f;
            finalText.text = "You got all the coins!";
        }

        
        
    }
