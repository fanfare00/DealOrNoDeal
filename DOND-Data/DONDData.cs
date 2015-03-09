using System;
using System.Collections.Generic;

namespace JamesDOND.Data
{
    public class DONDData
    {
        private string _UserName;
        public string UserName
        {
            get { return _UserName;  }
            set
            {
                if (value.Length > 50)
                {
                    //display error message
                }
                else
                {
                    _UserName = value;
                }
            }
        }

        private List<int> _MoneyValues;
        public List<int> MoneyValues
        {
            get { return _MoneyValues;  }
            set { _MoneyValues = value; }
        }

        private List<int> _CaseNumbers;
        public List<int> CaseNumbers
        {
            get { return _CaseNumbers; }
            set { _CaseNumbers = value; }
        }


        private int _GamesPlayed;
        public int GamesPlayed
        {
            get { return _GamesPlayed; }
            set { _GamesPlayed = value; }
        }

        private int _CaseNumberOriginal;
        public int CaseNumberOriginal
        {
            get { return _CaseNumberOriginal; }
            set { _CaseNumberOriginal = value; }
        }

        private int _CaseNumberPicked;
        public int CaseNumberPicked
        {
            get { return _CaseNumberPicked; }
            set { _CaseNumberPicked = value; }
        }

        private int _CaseNumberFinal;
        public int CaseNumberFinal
        {
            get { return _CaseNumberFinal; }
            set { _CaseNumberFinal = value; }
        }

        private int _TurnsBeforeOffer;
        public int TurnsBeforeOffer
        {
            get { return _TurnsBeforeOffer; }
            set { _TurnsBeforeOffer = value; }
        }

        private int _TotalWinnings;
        public int TotalWinnings
        {
            get { return _TotalWinnings; }
            set { _TotalWinnings = value; }
        }

        public DONDData(string userName, List<int> moneyValues, List<int>caseNumbers, int turnsBeforeOffer, int gamesPlayed, int caseNumberPicked, int caseNumberOriginal, int caseNumberFinal)
        {
            UserName = userName;
            MoneyValues = moneyValues;
            GamesPlayed = gamesPlayed;
            CaseNumbers = caseNumbers;
            CaseNumberPicked = caseNumberPicked;
            CaseNumberOriginal = caseNumberOriginal;
            CaseNumberFinal = caseNumberFinal;
            TurnsBeforeOffer = turnsBeforeOffer;
        }
    }
}
