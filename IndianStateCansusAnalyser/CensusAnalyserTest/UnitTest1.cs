using System.Collections.Generic;
using IndianStateCansusAnalyser;
using IndianStateCansusAnalyser.POCO;
using Newtonsoft.Json;
using NUnit.Framework;
using static IndianStateCansusAnalyser.CensusAnalyser;


namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqkn,DensityPerSqkn";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles";
        static string wrongHeaderIndianCensusPath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles";
        static string delimiterIndianStateCensusFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles";
        static string wrongindanStateCensusFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles";
        static string wrongindianStateCensusFileType = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles";
        static string indianStateCodeFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles";
        static string wrongIndianStateCodeFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles";
        static string delimiterIndianStateCodeFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles";
        static string wrongHeaderStateCoderFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles";

        IndianStateCansusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;


        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCansusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        
        /// TC-1.1-Givens the indian census data file when readed should return census data count.
        
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }

        ///TC-1.2- Givens the wrong indian census data file when readed should return custom exception.
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongindianStateCensusFileType, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongindanStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }


    }
}