using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Transformer_System
{
    /* ========================================= Converter ============================================
    
        Extract desired information from 'Collector' and converts (generate) it into List of 'StandardFormat' instances.

        Extensible: more types of converters can be added which can extract differently 'named' value from
                     'Collector' to generate 'StandardFormat' instances.
    */

    public abstract class Converter
    {
        protected List<string> Keys;
        protected List<List<string>> Values;

        public abstract StandardFormat[] Convert();
    }


    public class Converter1 : Converter
    {
        // Converting Source #1 to 'StandardFormat'

        public override StandardFormat[] Convert()
        {
            StandardFormat[] stdArray = new StandardFormat[] { };
            
            foreach (List<string> lst in this.Values)
            {
                string Identifier = lst[Keys.IndexOf("Identifier")].Split('|')[1];
                string Name = lst[Keys.IndexOf("Name")];
                string Types;
                if (lst[Keys.IndexOf("Type")] == "1")
                {
                    Types = "Trading";
                }
                else if (lst[Keys.IndexOf("Type")] == "2")
                {
                    Types = "RRSP";
                }
                else if (lst[Keys.IndexOf("Type")] == "3")
                {
                    Types = "RESP";
                }
                else
                {
                    Types = "Fund";
                }

                string Opened = lst[Keys.IndexOf("Opened")];
                string Currency;

                if (lst[Keys.IndexOf("Currency")] == "CD")
                {
                    Currency = "CAD";
                }
                else
                {
                    Currency = "USD";
                }

                StandardFormat stdF = new StandardFormat(
                    Identifier,
                    Name,
                    Types,
                    Opened,
                    Currency
                    );

                stdArray.Append(stdF);
            }
            return stdArray;
        }

        public Converter1(Collector collector1)
        {
            this.Keys = collector1.GetKeys();
            this.Values = collector1.GetValues();
        }
    }


    public class Converter2 : Converter
    {
        // Converting Source #2 to 'StandardFormat'
        // Assumption: Custodian code is given

        public override StandardFormat[] Convert()
        {
            StandardFormat[] stdArray = new StandardFormat[] { };

            foreach (List<string> lst in this.Values)
            {
                string Identifier = lst[Keys.IndexOf("Custodian Code")];
                string Name = lst[Keys.IndexOf("Name")];
                string Types = lst[Keys.IndexOf("Type")];
                string Opened = DateTime.Now.ToString("MM/dd/yyyy");
                string Currency;
                if (lst[Keys.IndexOf("Currency")] == "C")
                {
                    Currency = "CAD";
                }
                else
                {
                    Currency = "USD";
                }

                StandardFormat stdF = new StandardFormat(
                    Identifier,
                    Name,
                    Types,
                    Opened,
                    Currency
                    );

                stdArray.Append(stdF);
            }

            return stdArray;

            // StandardFormat(dict["Identifier"], dict["Name"], dict["Type"], dict["Opened"], dict["Currency"]);
        }

        public Converter2(Collector collector2)
        {
            this.Keys = collector2.GetKeys();
            this.Values = collector2.GetValues();
        }
    }
}
