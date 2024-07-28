using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

namespace Ink.N3DS
{

    public class StoryReader : MonoBehaviour
    {

        Story _inkStory;
        [SerializeField] Text _textDisplayer;

        [SerializeField] List<Button> _buttonList;
        List<RectTransform> _rectButtonList = new List<RectTransform>();

        [SerializeField] GameObject nextTextIndicator;

        [SerializeField] GameObject _ui;


        private enum DecisionState { NoDecision, DecisionIsBeenMade, DecisionWasJustMade }
        private DecisionState _decisionState = DecisionState.NoDecision;

        private enum WritingState { Writing, Finished, AbortedWriting }
        private WritingState _writingState = WritingState.Finished;

        [Range(0f, 0.2f)]
        [SerializeField] float _timeBetweenCharacters = 0.1f;


        private enum DialogState { Open, Closed, JustOpened }
        private DialogState _dialogState = DialogState.Closed;

        public delegate void _OnDialogStart();
        public static event _OnDialogStart OnDialogStart;


        public delegate void _OnDialogEnd();
        public static event _OnDialogEnd OnDialogEnd;

        private void Awake()
        {


            _buttonList[0].onClick.AddListener(delegate
            {
                ChooseOption(0);
            });
            _buttonList[1].onClick.AddListener(delegate
            {
                ChooseOption(1);
            });
            _buttonList[2].onClick.AddListener(delegate { ChooseOption(2); });
            _buttonList[3].onClick.AddListener(delegate { ChooseOption(3); });


            for (int i = 0; i < _buttonList.Count; i++)
            {
                _rectButtonList.Add(_buttonList[i].gameObject.GetComponent<RectTransform>());
                _buttonList[i].gameObject.SetActive(false);
            }

            _ui.SetActive(false);
        }

        void Update()
        {

            if (_dialogState == DialogState.Closed) return;


            //Updates Writing State for finishing on click
            if (_writingState == WritingState.Writing && Input.GetMouseButtonDown(0))
            { _writingState = WritingState.AbortedWriting; }


            if (shouldContinue())
            {
                displayText(_inkStory.Continue());
            }

            if (_inkStory.currentChoices.Count > 0 && _decisionState != DecisionState.DecisionIsBeenMade)
            {
                displayDecisionButtons();

                _decisionState = DecisionState.DecisionIsBeenMade;
                nextTextIndicator.SetActive(false);

            }

            updateStates();

            if (!_inkStory.canContinue && _inkStory.currentChoices.Count == 0)
            {
                closeDialog();
            }
        }

        private bool shouldContinue()
        {
            bool triggerReasons = Input.GetMouseButtonDown(0)
                || _decisionState == DecisionState.DecisionWasJustMade
                || _dialogState == DialogState.JustOpened;


            bool stateReasons = _decisionState != DecisionState.DecisionIsBeenMade
                && _writingState != WritingState.AbortedWriting;

            return _inkStory.canContinue
                && triggerReasons
                && stateReasons;
        }

        private void displayDecisionButtons()
        {
            float heigth = 240 / _inkStory.currentChoices.Count;

            for (int i = 0; i < _inkStory.currentChoices.Count; ++i)
            {
                Choice choice = _inkStory.currentChoices[i];
                _buttonList[i].GetComponentInChildren<Text>().text = choice.text;

                _buttonList[i].gameObject.SetActive(true);
                _rectButtonList[i].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 320);
                _rectButtonList[i].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heigth);
                _rectButtonList[i].anchoredPosition = new Vector2(0, (-heigth / 2) - (i) * heigth);
            }
        }

        private void updateStates()
        {
            if (_decisionState == DecisionState.DecisionWasJustMade) { _decisionState = DecisionState.NoDecision; }
            if (_writingState == WritingState.AbortedWriting) { _writingState = WritingState.Finished; }
            if (_dialogState == DialogState.JustOpened) { _dialogState = DialogState.Open; }
        }

        private void closeDialog()
        {
            _dialogState = DialogState.Closed;
            _ui.SetActive(false);

            if (OnDialogEnd != null)
                OnDialogEnd();
            print("Se acabo");
        }

        private void displayText(string text)
        {
            _writingState = WritingState.Writing;
            StartCoroutine(showText(text));
        }

        IEnumerator showText(string text)
        {
            string textShowed = "";

            foreach (var chara in text)
            {
                if (_writingState == WritingState.Writing)
                {
                    textShowed += chara;
                    _textDisplayer.text = textShowed;
                    yield return new WaitForSeconds(_timeBetweenCharacters);
                }
                else
                {
                    _textDisplayer.text = text;
                    break;

                }
            }

            _writingState = WritingState.Finished;

            yield return null;
        }



        public void StartStory(TextAsset json)
        {
            _inkStory = new Story(json.text);
            _ui.SetActive(true);
            _textDisplayer.text = "";

            if (OnDialogStart != null)
                OnDialogStart();

            _writingState = WritingState.Finished;
            _dialogState = DialogState.JustOpened;
            _decisionState = DecisionState.NoDecision;
        }

        public void ChooseOption(int option)
        {
            _inkStory.ChooseChoiceIndex(option);
            _decisionState = DecisionState.DecisionWasJustMade;

            for (int i = 0; i < _buttonList.Count; i++)
            {
                _buttonList[i].gameObject.SetActive(false);
            }
            nextTextIndicator.SetActive(true);
        }
    }
}
