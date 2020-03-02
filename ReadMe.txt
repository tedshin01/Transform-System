
            
=================================== Transform System ===================================

I have desined this system into 2 level filteration of raw data (csc).
The main goal of this system is to ouput StandardFormat instances from raw data.

2 Major parts
	- Collectors
		- responsible for collecting data from raw source
		- 2 subclasses:
			Collector_header: responsible for collecting data from csv file which contains header
			Collector_noheader: responsible for collecting data from csv file which does not contain header
	- Converters
		- Takes Collector instances and convert data into Standard Format.
		- Mainly responsible for matching 'name' of the data to target format (StandardFormat)

Note:
   - Client must choose specific type of collector and converter depending on source file to generate 'StandardFormat' objects.
   - For example, in order to generage 'StandardFormat' with source #2 (specified in the requirement), one must use 
       'Collector_noheader' to collect data from the source and then convert to 'StandardFormat' using 'Converter2'

