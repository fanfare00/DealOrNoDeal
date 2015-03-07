using System;
using System.Collections.Generic;

namespace JamesDOND.Data
{
    public class DONDData
    {
        private string _userName;
        public string userName
        {
            get { return _userName;  }
            set
            {
                if (value.Length > 50)
                {
                    //display error message
                }
                else
                {
                    _userName = value;
                }
            }
        }

        private List<int> _moneyValues;
        public List<int> moneyVales
        {
            get { return _moneyValues;  }
            set { _moneyValues = value; }
        }

        private int[] _originalMoneyValues;
        public int[] originalMoneyValues
        {
            get { return _originalMoneyValues; }
            set { _originalMoneyValues = value; }
        }

    }
}
