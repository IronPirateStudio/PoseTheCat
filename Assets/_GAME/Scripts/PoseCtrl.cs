using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace IronPirate.PoseTheCat {
    public class PoseCtrl : MonoBehaviour {
        
        void Start() {
            EventsDefine.onEndGame += OnEndGame;
        }

        void OnDestroy() {
            EventsDefine.onEndGame -= OnEndGame;
        }

        private void OnEndGame(bool win) {
            if (win) return;
            DoLoseAnim();
        }

        private void DoLoseAnim() {
            transform.DORotate(new Vector3(-90, 0, 0), .2f).SetEase(Ease.InOutBounce);
        }
    }
}