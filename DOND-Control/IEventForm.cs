using System;
using System.Collections.Generic;
using JamesDOND.Data;

namespace JamesDOND.Controller
{
    public interface IEventForm
    {
        void SetController(DONDController controller);
        void StartCaseOpenEvent();
        void StartBankOfferEvent();
        void StartFinalEvent();

        string UserName { get; set; }
        int CaseNumberPicked { get; set; }
        int CaseNumberOriginal { get; set; }
        int CaseNumberFinal { get; set; }
        int CaseValue { get; set; }
        int OfferValue { get; set; }


    }
}