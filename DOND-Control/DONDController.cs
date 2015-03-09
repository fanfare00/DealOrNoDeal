using System;
using System.Collections;
using JamesDOND.Data;
using System.Collections.Generic;

namespace JamesDOND.Controller
{
    public class DONDController
    {
        IMainForm _mainForm;
        IOverlay _overlay;
        IEventForm _eventForm;
        DONDData _gameData;

        public DONDController(IMainForm mainForm, IOverlay overlay, IEventForm eventForm, DONDData gameData)
        {
            _mainForm = mainForm;
            _overlay = overlay;
            _eventForm = eventForm;
            _gameData = gameData;

            _mainForm.SetController(this);
            _eventForm.SetController(this);
            _mainForm.TurnNumber = _gameData.TurnsBeforeOffer;
            _mainForm.TurnsBeforeOffer = _gameData.TurnsBeforeOffer;
        }

        public void addNewUser(string userName)
        {
            _mainForm.UserName = userName;
            _eventForm.UserName = userName;
           // _eventForm.UpdateEventData();
            _gameData.UserName = _mainForm.UserName;

        }

        public void addCaseScene()
        {

            _overlay.fadeIn();
            _eventForm.StartCaseOpenEvent();
        }

        public void addOfferScene()
        {
            _overlay.fadeIn();
            _eventForm.StartBankOfferEvent();
        }

        public void addFinalScene()
        {
            _overlay.fadeIn();
            _eventForm.StartFinalEvent();
        }

        public void returnToMain()
        {
            _overlay.fadeOut();
             
        }

        public void getNewOfferValue()
        {
            double offerAmount = 0;
            foreach (int valueLeft in _gameData.MoneyValues)
            {
                offerAmount += valueLeft;
            }

            offerAmount = offerAmount / _gameData.MoneyValues.Count;

            offerAmount *= (1 - (_gameData.MoneyValues.Count * 0.02));

            _eventForm.OfferValue = (int)offerAmount;
        }
        
        public void selectNewCase()
        {

            if (_gameData.CaseNumberOriginal == 0)
            {
                _gameData.CaseNumberOriginal = _mainForm.CaseNumber;
                _gameData.CaseNumbers.Remove(_mainForm.CaseNumber);
                _mainForm.SetInitialCase(_gameData.CaseNumberOriginal);
            }
            else
            {
                _gameData.CaseNumberPicked = _mainForm.CaseNumber;
                _gameData.CaseNumbers.Remove(_mainForm.CaseNumber);
                _mainForm.TurnNumber -= 1;
                getNewCaseValue();
            }

            if (_gameData.CaseNumbers.Count == 1)
            {
                _gameData.CaseNumberFinal = _gameData.CaseNumbers[0];
                _mainForm.TurnNumber = -1;
            }

            updateCaseNumbers();
        }

        public void updateCaseNumbers()
        {
            _eventForm.CaseNumberOriginal = _gameData.CaseNumberOriginal;
            _eventForm.CaseNumberPicked = _gameData.CaseNumberPicked;
            _eventForm.CaseNumberFinal = _gameData.CaseNumberFinal;
        }

        public void getNewCaseValue()
        {
            Random r = new Random();
            int value = _gameData.MoneyValues[r.Next(_gameData.MoneyValues.Count)];
            _gameData.MoneyValues.Remove(value);

            _eventForm.CaseValue = value;
        }

        public void updateWinnings()
        {
            _gameData.TotalWinnings += _eventForm.CaseValue;
            _mainForm.TotalWinnings += _gameData.TotalWinnings;
        }

        public void updateGamesPlayed()
        {
            _gameData.GamesPlayed += 1;
            _mainForm.GamesPlayed += 1;
        }

        public void restartGame()
        {
            List<int> moneyValues =  new List<int>() { 1, 5, 10, 15, 25, 50, 75, 100, 200, 300, 
                                                       400, 500, 750, 1000, 5000, 10000, 25000, 
                                                       50000, 75000, 100000, 200000, 300000, 
                                                       400000, 500000, 750000, 1000000 };

            List<int> caseNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 
                                                      14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
            _gameData.CaseNumberOriginal = 0;
            _gameData.CaseNumberPicked = 0;
            _gameData.CaseNumberFinal = 0;

            _gameData.CaseNumbers = caseNumbers;
            _gameData.MoneyValues = moneyValues;
            _mainForm.ResetForm();
            _gameData.TurnsBeforeOffer = 6;
            _mainForm.TurnsBeforeOffer = 6;
            _mainForm.TurnNumber = 6;
        }
        
    }


}
