using System.Collections;
using UnityEngine;
using UnityEngine.Events;

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
        private UnityEvent _restart = new UnityEvent();

        public GameUI Init(UnityAction restart)
        {
            _interactableStyle = new GUIStyle();
            _gameResultStyle = new GUIStyle();
            _interactableStyle.normal.textColor = Color.white;
            _interactableStyle.fontSize = 20;
            _interactableStyle.alignment = TextAnchor.MiddleCenter;
            _gameResultStyle.normal.textColor = Color.white;
            _gameResultStyle.fontSize = 34;
            _gameResultStyle.alignment = TextAnchor.MiddleCenter;
            _restart.AddListener(restart);

            return this;
        }

        public void GameResult(string result)
        {
            _gameEnded = true;
            _gameResult = result;
        }

        public void HideResult()
        {
            _gameEnded = false;
        }

        public void Interactable(bool active)
        {
            _interactableActive = active;
        }

        private void OnGUI()
        {
            if (_interactableActive)
            {
                var interactable = new Rect(Screen.width / 2 - _interactableWidth / 2, Screen.height - _interactableHeight * 2, _interactableWidth, _interactableHeight);
                GUI.Label(interactable, "Press \"E\" to interact", _interactableStyle);
            }

            if (_gameEnded)
            {
                var resultLabel = new Rect(Screen.width / 2 - _gameResultWidth / 2, Screen.height / 2 - _gameResultHeight / 2, _gameResultWidth, _gameResultHeight);
                GUI.Label(resultLabel, _gameResult, _gameResultStyle);

                var resultBtn = new Rect(Screen.width / 2 - _gameResultWidth / 2, Screen.height / 2 + _gameResultHeight * 2, _gameResultWidth, _gameResultHeight);
                if (GUI.Button(resultBtn, "Retry"))
                {
                    _restart.Invoke();
                }
            }
        }
    }
}