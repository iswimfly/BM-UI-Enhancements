using System.Collections.Generic;
using Flash2;
using Framework.UI;
using Il2CppSystem;
using Il2CppSystem.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using Object = UnityEngine.Object;


namespace MoveRankingTimer
{
    public static class Main
    {
        public static float RankingChallengePositionX { get; set; } = 365;
        public static float RankingChallengePositionY { get; set; } = 860;
        public static bool PauseBackground { get; set; } = false;
        public static bool PauseCharacter { get; set; } = false;
        public static void OnModLoad(Dictionary<string, object> settings)
        {
            RankingChallengePositionX = (float)settings["RankingChallengePositionX"];
            RankingChallengePositionY = (float)settings["RankingChallengePositionY"];
            PauseBackground = (bool)settings["PauseBackground"];
            PauseCharacter = (bool)settings["PauseCharacter"];
        }
        private static GameObject timer = null;
        private static GameObject pausebg = null;
        private static GameObject pausechara = null;
        private static GameObject blackbg = null;
        public static void OnModUpdate()
        {
            // change the position
            if (timer != null)
            {
                timer.GetComponent<TimeAttackView>().m_TimerObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(RankingChallengePositionX, RankingChallengePositionY);
            }
            // look for the timer
            else
            {
                timer = GameObject.Find("c_time_attack_0");
            }
            // Remove the Yellow BG and add black tint
            if (pausebg != null)
            {
                pausebg.SetActive(false);
                blackbg.GetComponent<Image>().GetComponent<Graphic>().color = new Color(0, 0, 0, (float)0.75);
                blackbg.GetComponent<RectTransform>().localScale = new Vector3(1, 40, 0);
            }
            else
            {
                pausebg = GameObject.Find("pause_bg");
                blackbg = GameObject.Find("bg_00_00");

            }
            // Remove Character Portrait
            if (pausechara != null)
            {
                pausechara.SetActive(false);
            }
            else
            {
                pausechara = GameObject.Find("pause_chara");
            }
        }
    }
}   