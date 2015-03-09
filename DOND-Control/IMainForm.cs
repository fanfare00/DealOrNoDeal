using System;
using System.Collections.Generic;
using JamesDOND.Data;

namespace JamesDOND.Controller
{
    public interface IMainForm
    {
        void SetController(DONDController controller);
        void SetInitialCase(int caseNumberOriginal);
        void ResetForm();

        string UserName { get; set; }
        int GamesPlayed { get; set; }
        int CaseNumber { get; set; }
        int TurnNumber { get; set; }
        int TotalWinnings { get; set; }
        int TurnsBeforeOffer { get; set; }


    }
}
