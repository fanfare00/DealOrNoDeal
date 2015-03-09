using System;
using System.Collections.Generic;
using JamesDOND.Data;

namespace JamesDOND.Controller
{
    public interface IOverlay
    {

        void SetController(DONDController controller);

        void fadeIn();
        void fadeOut();
        void resetAlpha();

    }
}