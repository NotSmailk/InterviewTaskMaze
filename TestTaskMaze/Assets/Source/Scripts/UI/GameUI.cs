using Assets.Source.Scripts.Signals;
using UnityEngine;

namespace Assets.Source.Scripts.UI
{
    public class GameUI : MonoBehaviour
    {
        private bool _interactableActive = false;
        private bool _gameEnded = false;
        private GUIStyle _interactableStyle;
        private GUIStyle _gameResultStyle;
        private float _interactableWidth = 100f;
        private float _interactableHeight = 50f;
        private float _gameResultWidth = 250f;
        private float _gameResultHeight = 50f;
        private string _gameResult;

        public GameUI Init()
        {
            _interactableStyle = new GUIStyle();
            _gameResultStyle = new GUIStyle();
            _interactableStyle.normal.textColor = Color.white;
            _interactableStyle.fontSize = 20;
            _interactableStyle.alignment = TextAnchor.MiddleCenter;
            _gameResultStyle.normal.textColor = Color.white;
            _gameResultStyle.fontSize = 34;
            _gameResultStyle.alignment = TextAnchor.MiddleCenter;
            EventBus.Instance.Subscribe<InteractSignal>(Interactable);
            EventBus.Instance.Subscribe<VictorySignal>(Victory);
            EventBus.Instance.Subscribe<DefeatSignal>(Defeat);

            return this;
        }

        private void OnDestroy()
        {
            EventBus.Instance.UnSubscribe<InteractSignal>(Interactable);
            EventBus.Instance.UnSubscribe<VictorySignal>(Victory);
            EventBus.Instance.UnSubscribe<DefeatSignal>(Defeat);
        }

        public void Victory(VictorySignal signal)
        {
            _gameEnded = true;
            _gameResult = Constants.KeyWords.WIN_RESULT;
        }

        public void Defeat(DefeatSignal signal)
        {
            _gameEnded = true;
            _gameResult = Constants.KeyWords.LOSE_RESULT;
        }

        public void HideResult()
        {
            _gameEnded = false;
        }

        public void Interactable(InteractSignal signal)
        {
            _interactableActive = signal.interact;
        }

        private void OnGUI()
        {
            if (_interactableActive)
            {
                var interactable = new Rect(Screen.width / 2 - _interactableWidth / 2, Screen.height - _interactableHeight * 2, _interactableWidth, _interactableHeight);
                GUI.Label(interactable, Constants.KeyWords.INTERACTABLE_MSG, _interactableStyle);
            }

            if (_gameEnded)
            {
                var resultLabel = new Rect(Screen.width / 2 - _gameResultWidth / 2, Screen.height / 2 - _gameResultHeight / 2, _gameResultWidth, _gameResultHeight);
                GUI.Label(resultLabel, _gameResult, _gameResultStyle);

                var resultBtn = new Rect(Screen.width / 2 - _gameResultWidth / 2, Screen.height / 2 + _gameResultHeight * 2, _gameResultWidth, _gameResultHeight);
                if (GUI.Button(resultBtn, Constants.KeyWords.RETRY))
                {
                    EventBus.Instance.Invoke(new RestartSignal());
                }
            }
        }
    }
}