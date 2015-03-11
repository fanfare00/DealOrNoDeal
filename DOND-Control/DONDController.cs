using System;
using System.Text;
using System.Collections;
using JamesDOND.Data;
using System.Collections.Generic;

using System.Net;
using System.IO;

namespace JamesDOND.Controller
{
    public class DONDController
    {
        IMainForm _mainForm;
        IOverlay _overlay;
        IEventForm _eventForm;
        IStartMenu _startMenu;
        DONDData _gameData;

        public DONDController(IMainForm mainForm, IOverlay overlay, IEventForm eventForm, IStartMenu startMenu, DONDData gameData)
        {
            _mainForm = mainForm;
            _overlay = overlay;
            _eventForm = eventForm;
            _startMenu = startMenu;
            _gameData = gameData;

            _startMenu.SetController(this);
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
            _gameData.UserName = userName;

        }

        public void playCaseOpenningSound()
        {
            _startMenu.PlayCaseOpenningSound();
        }

        public void playCaseOpennedSound()
        {
            _startMenu.PlayCaseOpennedSound();
        }

        public void playTickSound()
        {
            _startMenu.PlayTickSound();
        }

        public void playClickSound()
        {
            _startMenu.PlayClickSound();
        }

        public void playPhoneSound()
        {
            _startMenu.PlayPhoneSound();
        }

        public void playCrowdBooSound()
        {
            _startMenu.PlayCrowdBooSound();
        }

        public void playWinTheme()
        {
            _startMenu.PlayWinTheme();
        }

        public void playNoDealSound()
        {
            _startMenu.PlayNoDealSound();
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

            if (_gameData.CaseNumbers.Count == 2)
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

        public void updateWinnings(int value)
        {
            _gameData.TotalWinnings += value;
            _mainForm.TotalWinnings = _gameData.TotalWinnings;
        }

        public void updateGamesPlayed()
        {
            _gameData.GamesPlayed += 1;
            _mainForm.GamesPlayed = _gameData.GamesPlayed;
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

        public void returnToMainMenu()
        {
            restartGame();
            _gameData.GamesPlayed = 0;
            _gameData.UserName = "";
            _gameData.TotalWinnings = 0;

            _mainForm.ShutDown();
            _startMenu.ReturnToMainMenu();
        }

        public void postToServer(string score)
        {
            //The method we will use to send the data, this can be POST or GET.
            string requestmethod = "POST";

            //Here we will enter the data to send, just like if we where to go to a webpage and enter variables,
            // we would type: "www.somesite.com?var1=Hello&var2=Server!"!
            string postData = "var1=" + _gameData.UserName + "&var2=" + score + "";

            //The Byte Array that will be used for writing the data to the stream.
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //The URL of the webpage to send the data to.
            string URL = "http://i.jdonaldmccarthy.bitnamiapp.com/index/testTester.php";

            //The type of content being send, this is almost always "application/x-www-form-urlencoded".
            string contenttype = "application/x-www-form-urlencoded";

            //What the server sends back:
            string responseFromServer = null;

            //Here we will create the WebRequest object, and enter the URL as soon as it is created.
            WebRequest request = WebRequest.Create(URL);

            //We also need a Stream:
            Stream dataStream;

            //...And a webResponce,
            WebResponse response;

            //don't forget the streamreader either!
            StreamReader reader;

            //We will need to set the method used to send the data.
            request.Method = requestmethod;

            //Then the contenttype:
            request.ContentType = contenttype;

            //content length
            request.ContentLength = byteArray.Length;

            //ok, now get the request from the webRequest object, and put it into our Stream:
            dataStream = request.GetRequestStream();

            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);

            // Close the Stream object.
            dataStream.Close();


            //Get the responce
            response = request.GetResponse();

            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();

            //Open the responce stream:
            reader = new StreamReader(dataStream);

            //read the content into the responcefromserver string
            responseFromServer = reader.ReadToEnd();

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
        }
        
    }


}
