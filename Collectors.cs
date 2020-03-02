using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Transformer_System
{
    /* ========================================= Collector ==============================================
     
       Responsible for collecting data from raw source
    
       Assumption: 
           1. Assume data is already read into some kind of data structure that needs to be designed.
           2. All files are CSV files, but don’t worry about the code to read the files.  
           3. Custodian Code is unique for each row of data for source #2
    */

    public abstract class Collector
    {
        //  Class resposible for collecting data.

        //  Invariant: Keys.Count() == Every Entry.Count() of this.Value

        protected List<string> Keys { get;}
        protected List<List<string>> Values { get;}

        public List<string> GetKeys()
        {
            return this.Keys;
        }

        public List<List<string>> GetValues()
        {
            return this.Values;
        }
    }

    public class Collector_header : Collector
    // Collect raw data from source (csv) that contains headers
    {
        public Collector_header(/*csv object*/)
        {
            // Parameter 1: csv file object

            // this.Keys = headers from source input (csv) 
            // this.values = list of lists of values of each rows. (ie. [["ID|ABC", "Name", "Currency"],["ID|ABC", "Name", "Currency"]]
        }
    }



    public class Collector_noheader : Collector
    // Collect raw data from source (csv) that doesnt contain headers
    {
        public Collector_noheader(/*csv object, userdefined list of headers*/)
        {
            /*
                Parameter 1: csv file object
                Parameter 2: userdefined list of headers (In this case (source #2): ["Name", "Type", "Currency", "Custodian Code"] )

                Precondition: Input2.Count() == # of columns in csv

                csv reader stores list of lists of values of each rows (not the header) in this.Value.

                this.Keys = Input 2
                this.Values = list of lists of values of each rows. (ie. [["ID|ABC", "Name", "Currency"],["ID|ABC", "Name", "Currency"]]
            */
        }
    }
}