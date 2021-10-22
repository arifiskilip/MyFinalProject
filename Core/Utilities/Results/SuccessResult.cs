using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message) 
        { 

        } // mesaj vermek istiyorsa.
        public SuccessResult():base(true)
        {

        } // mesaj vermek istemiyorsa.
    }
}
