using System;
using UnityEngine;

namespace IronPirate.PoseTheCat {
    public class RunStraight : MonoBehaviour {
        [SerializeField] float speed;
        [SerializeField] bool runForward = true;   

        private bool running = false;
        private int dir;

        private void Start() {
            EventsDefine.onFitStart += StartRun;
            EventsDefine.onEndGame += OnEndGame;
        }

        private void OnDestroy() {
            EventsDefine.onFitStart -= StartRun;
            EventsDefine.onEndGame -= OnEndGame;
        }

        private void OnEndGame(bool win) {
            StopRun();
        }

        public void StartRun() {
            running = true;
            dir = runForward ? 1 : -1;
        }

        public void StopRun() {
            running = false;
        }

        private void Update() {
            if (!running) return;
            transform.Translate(Vector3.forward * dir * speed * Time.deltaTime);
        }
    }
}
