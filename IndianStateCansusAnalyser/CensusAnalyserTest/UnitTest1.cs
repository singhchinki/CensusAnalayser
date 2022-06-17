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
        static string indianStateCensusFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles\StateCensusData.csv";
        static string wrongHeaderIndianCensusPath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles\wrongHeaderIndianCensusPath.csv";
        static string delimiterIndianStateCensusFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles\delimeterIndianStateCensus.csv";
        static string wrongindanStateCensusFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles\";
        static string wrongindianStateCensusFileType = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles\wrongIndianStateCensusFileType.txt";
        static string indianStateCodeFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles\StateCode.csv";
        static string wrongIndianStateCodeFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles\wrongIndianStatrCodeFilePath.txt";
        static string delimiterIndianStateCodeFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles\delimeterIndianStateCode.csv";
        static string wrongHeaderStateCoderFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles\wrongHeaderStateCode.csv";
        static string wrongIndianStateCoderFileType = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles\wrongIndianStateCodeFileType.txt";

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
        
       
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }

        
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongindanStateCensusFilePath ,indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongindanStateCensusFilePath ,indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongindianStateCensusFileType, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        [Test]
        public void GivenIndianCensusDelimiterFile_whenNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);

        }
        [Test]
        public void GivenIndianCensusDataFile_WhenHeaderNoProPer_ShouldReturnException()
        {
            var censusException = Assert.Throws < CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusPath, indianStateCensusHeaders));
            var stateException = Assert.Throws < CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderStateCoderFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);

        }


    }
}