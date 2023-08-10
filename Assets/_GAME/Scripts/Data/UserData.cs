using System;
using UnityEngine;

namespace IronPirate.PoseTheCat {
    public partial class UserData {
        /// <summary> Level name start = 1 </summary>
        public static int CurrentLevel {
            get => PlayerPrefs.GetInt("CurrentLevel", 1);
            set => PlayerPrefs.SetInt("CurrentLevel", value > 0 ? value : 1);
        }
    }
}
