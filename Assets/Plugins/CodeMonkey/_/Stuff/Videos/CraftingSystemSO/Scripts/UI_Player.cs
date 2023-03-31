﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CodeMonkey.CraftingSystem {

    public class UI_Player : MonoBehaviour {

        private TextMeshProUGUI goldText;
        private TextMeshProUGUI healthPotionText;

        private void Awake() {
            goldText = transform.Find("goldText").GetComponent<TextMeshProUGUI>();
            healthPotionText = transform.Find("healthPotionText").GetComponent<TextMeshProUGUI>();
        }

        private void Start() {
            UpdateText();

            MonkeyPlayer.Instance.OnGoldAmountChanged += Instance_OnGoldAmountChanged;
            MonkeyPlayer.Instance.OnHealthPotionAmountChanged += Instance_OnHealthPotionAmountChanged;
        }

        private void Instance_OnHealthPotionAmountChanged(object sender, System.EventArgs e) {
            UpdateText();
        }

        private void Instance_OnGoldAmountChanged(object sender, System.EventArgs e) {
            UpdateText();
        }

        private void UpdateText() {
            goldText.text = MonkeyPlayer.Instance.GetGoldAmount().ToString();
            healthPotionText.text = MonkeyPlayer.Instance.GetHealthPotionAmount().ToString();
        }

    }

}