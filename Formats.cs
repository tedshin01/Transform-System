using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Transformer_System
{
    // ================================== Format Classes ====================================
    //
    // Can easily add other Format than 'StandardFormat' if required.

    public class StandardFormat
    // Target Standard Format
    {
        public string AccountCode { get; }
        public string Name { get; }
        public string Type { get; }
        public string OpenDate { get; }
        public string Currency { get; }

        public StandardFormat(string accCode, string name, string type, string odate, string curr)
        {
            this.AccountCode = accCode;
            this.Name = name;
            this.Type = type;
            this.OpenDate = odate;
            this.Currency = curr;
        }
    }

}
