using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndianStateCansusAnalyser.POCO;

namespace IndianStateCansusAnalyser
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
               // case (CensusAnalyser.Country.US):
                   // return new USCensusAdapter().LoadUSCensusData(csvFilePath, dataHeaders);
                    default:
                    throw new CensusAnalyserException("NO Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
            
            
    }
}
