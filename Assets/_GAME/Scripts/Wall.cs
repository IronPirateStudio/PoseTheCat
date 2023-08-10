using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IronPirate.PoseTheCat {
    public class Wall : MonoBehaviour {

        private void Start() {
            LoadCurrentLevel();
        }

        private void LoadCurrentLevel() {
            var obj = Resources.Load<GameObject>(string.Format("Stages/PoseGoal{0}", UserData.CurrentLevel));
            if (obj == null) {
                UserData.CurrentLevel = 1;
                LoadCurrentLevel();
                return;
            }

            var lv = Instantiate(obj, transform);
            lv.transform.localPosition = Vector3.zero;
            lv.transform.localRotation = Quaternion.identity;
        }

    }
}