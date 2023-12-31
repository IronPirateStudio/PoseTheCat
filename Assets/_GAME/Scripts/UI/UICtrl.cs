using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace IronPirate.PoseTheCat {
    public class UICtrl : MonoBehaviour {
        [SerializeField] TMPro.TextMeshProUGUI stageText;
        [SerializeField] Button fitButton;
        [SerializeField] GameObject ingameUI;
        [SerializeField] GameObject winUI;
        [SerializeField] GameObject loseUI;

        void Start() {
            winUI.SetActive(false);
            loseUI.SetActive(false);
            fitButton.gameObject.SetActive(false);
            fitButton.onClick.AddListener(StartFit);
            stageText.text = string.Format("Stage {0}", UserData.CurrentLevel);

            EventsDefine.onPoseStart += OnStartGame;
            EventsDefine.onEndGame += OnEndGame;
        }

        private void OnDestroy() {
            EventsDefine.onPoseStart -= OnStartGame;
            EventsDefine.onEndGame -= OnEndGame;
        }

        private void OnStartGame() {
            ShowFitButton();
        }

        void StartFit() {
            fitButton.gameObject.SetActive(false);
            GameEvents.Trigger(EventsDefine.onFitStart);
        }

        private void OnEndGame(bool win) {
            Show(win ? winUI : loseUI);
            
            if (win) {
                UserData.CurrentLevel++;
                if (UserData.CurrentLevel > Define.MaxLevel) {
                    UserData.CurrentLevel = 1;
                }
            }
        }

        private void ShowFitButton() {
            fitButton.gameObject.SetActive(true);
        }

        private void Show(GameObject ui, bool closeAll = true) {
            if (closeAll) HideAll();
            ui.SetActive(true);
        }

        private void HideAll() {
            ingameUI.SetActive(false);
            winUI.SetActive(false);
            loseUI.SetActive(false);
        }

        public void LoadNewGame() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}