using System;
using System.Collections.Generic;
using JamesDOND.Data;

namespace JamesDOND.Controller
{
    public interface IStartMenu
    {
        void SetController(DONDController controller);
        void PlayCaseOpenningSound();
        void PlayCaseOpennedSound();
        void PlayClickSound();
        void PlayTickSound();
        void PlayCrowdBooSound();
        void PlayPhoneSound();
        void PlayWinTheme();
        void PlayNoDealSound();

        void ReturnToMainMenu();
    }
}
