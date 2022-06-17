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
        static string wrongindIanStateCensusFilePath = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles";
        static string wrongindIanStateCensusFileType = @"D:\BridgeLabzFellowship\CensusAnalayser\IndianStateCansusAnalyser\CensusAnalyserTest\CSVFiles";
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

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);    
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
    }
}