using UnityEngine;

namespace IronPirate.PoseTheCat {
    [RequireComponent(typeof(Collider))]
    public class PosePoint : MonoBehaviour {
        [SerializeField] Transform target;

        Vector3 startPos;
        Vector3 startTouch;

        private const string GoalTag = "PoseGoal";
        private const string WallTag = "Wall";
        private const int PoseCountTarget = 6;
        private static int poseFitCount;

        private bool touchAble;

        private void Start() {
            touchAble = true;
            poseFitCount = -1;
            EventsDefine.onFitStart += OnFitStart;
        }

        private void OnDestroy() {
            EventsDefine.onFitStart -= OnFitStart;
        }

        private void OnFitStart() {
            touchAble = false;
        }

        private void OnMouseDown() {
            if (!touchAble) return;
            if (poseFitCount < 0) {
                poseFitCount = 0;
                GameEvents.Trigger(EventsDefine.onPoseStart);
            }

            startPos = target.transform.position;
            startTouch = Input.mousePosition;
        }

        private void OnMouseUp() {
            if (!touchAble) return;
            Vector3 delta = Input.mousePosition - startTouch;
            if (delta.magnitude < 0.2f) return;
        }

        private void OnMouseDrag() {
            if (!touchAble) return;
            Vector3 pos = Vector3.Lerp(target.transform.position, startPos + (Input.mousePosition - startTouch)/100, 0.5f);
            target.transform.position = pos;
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag(GoalTag)) {
                DisableCollider();
                poseFitCount++;
                if (poseFitCount >= PoseCountTarget) {
                    GameEvents.Trigger(EventsDefine.onEndGame, true);
                }
            }
            else if (other.CompareTag(WallTag)) {
                DisableCollider();
                GameEvents.Trigger(EventsDefine.onEndGame, false);
            }
        }

        private void DisableCollider() {
            GetComponent<Collider>().enabled = false;
        }
    }
}