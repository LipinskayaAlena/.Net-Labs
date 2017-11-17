using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab4_XmlTechnologies;
using System.IO;
using System.Linq;
using System;
using System.Text;
using System.Collections.Generic;

namespace Lab4_XmlTechnologiesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetElements()
        {
            MemoryStream[] memoryStream = new[]
            {
               "<?xml version=\"1.0\" encoding=\"utf-8\"?><docSearch_dsReq_0_0 userID=\"798955\" companyID=\"222\" queryType=\"normal\" dateRange=\"allDates\" infoLevel=\"default\" tkrEncoding=\"prtID\" calcPrice=\"1\" ppv=\"both\" acceptLanguage=\"en\" synCharsRequired=\"0\" exclude3rdParty=\"0\" maxRows=\"1\" ><docID>34387618</docID><sort s_c=\"score\" s_d=\"desc\" /><excludeCtbs>0</excludeCtbs></docSearch_dsReq_0_0>",
               "<?xml version=\"1.0\" encoding=\"utf-8\"?><docSearch_dsReq_0_0 userID=\"3118158\" companyID=\"25256\" queryType=\"normal\" dateRange=\"last90Days\" tkrEncoding=\"prtID\" tkrPrimary=\"1\" calcPrice=\"0\" acceptLanguage=\"en\" synCharsRequired=\"0\" exclude3rdParty=\"1\" maxRows=\"3\"><sort s_c=\"date\" s_d=\"desc\" /><excludeCtbs>0</excludeCtbs><ctbs>54,767,2,5179,3202,3414,16006,360,25256</ctbs><ticker>100204446</ticker><analystSet>MX#001</analystSet><industrySet>MX#001</industrySet><subjectSet>MX#001</subjectSet><regionSet>MX#001</regionSet><categorySet>MX#001</categorySet><langID>en</langID><matchStr strSrc=\"hdln\">\"model\"</matchStr></docSearch_dsReq_0_0>",
               "<?xml version=\"1.0\"?><docSearch_dsReq_0_0 calcPrice=\"1\" dateRange=\"allDates\" companyID=\"184\" userID=\"2112\"><sort s_c=\"date\"/><excludeCtbs>false</excludeCtbs><ctbs>17846</ctbs><industrySet>MG#10338</industrySet><industry>0606</industry><industry>0609</industry><industry>0612</industry><industry>0133</industry><industry>0909</industry><industry>1209</industry><subjectSet>MX#001</subjectSet><subject>OVER</subject><subject>NOV</subject></docSearch_dsReq_0_0>"
           }.Select(xml => new MemoryStream(Encoding.UTF8.GetBytes(xml))).ToArray();

            Dictionary<String, Int32> expected = new Dictionary<String, Int32>()
            {
                { String.Empty, 2 },
                { "34387618", 1}
            };

            XmlSearcher xmlSearcher = new XmlSearcher(2);
            Dictionary<String, Int32> result = xmlSearcher.Search(memoryStream, "docID");

            CollectionAssert.AreEqual(expected, result);
            
        }

        [TestMethod]
        public void GetAttributes()
        {
            MemoryStream[] memoryStream = new[]
            {
               "<?xml version=\"1.0\" encoding=\"utf-8\"?><docSearch_dsReq_0_0 userID=\"798955\" companyID=\"222\" queryType=\"normal\" dateRange=\"allDates\" infoLevel=\"default\" tkrEncoding=\"prtID\" calcPrice=\"1\" ppv=\"both\" acceptLanguage=\"en\" synCharsRequired=\"0\" exclude3rdParty=\"0\" maxRows=\"1\" ><docID>34387618</docID><sort s_c=\"score\" s_d=\"desc\" /><excludeCtbs>0</excludeCtbs></docSearch_dsReq_0_0>",
               "<?xml version=\"1.0\" encoding=\"utf-8\"?><docSearch_dsReq_0_0 userID=\"3118158\" companyID=\"25256\" queryType=\"normal\" dateRange=\"last90Days\" tkrEncoding=\"prtID\" tkrPrimary=\"1\" calcPrice=\"0\" acceptLanguage=\"en\" synCharsRequired=\"0\" exclude3rdParty=\"1\" maxRows=\"3\"><sort s_c=\"date\" s_d=\"desc\" /><excludeCtbs>0</excludeCtbs><ctbs>54,767,2,5179,3202,3414,16006,360,25256</ctbs><ticker>100204446</ticker><analystSet>MX#001</analystSet><industrySet>MX#001</industrySet><subjectSet>MX#001</subjectSet><regionSet>MX#001</regionSet><categorySet>MX#001</categorySet><langID>en</langID><matchStr strSrc=\"hdln\">\"model\"</matchStr></docSearch_dsReq_0_0>",
               "<?xml version=\"1.0\"?><docSearch_dsReq_0_0 calcPrice=\"1\" dateRange=\"allDates\" companyID=\"184\" userID=\"2112\"><sort s_c=\"date\"/><excludeCtbs>false</excludeCtbs><ctbs>17846</ctbs><industrySet>MG#10338</industrySet><industry>0606</industry><industry>0609</industry><industry>0612</industry><industry>0133</industry><industry>0909</industry><industry>1209</industry><subjectSet>MX#001</subjectSet><subject>OVER</subject><subject>NOV</subject></docSearch_dsReq_0_0>"
           }.Select(xml => new MemoryStream(Encoding.UTF8.GetBytes(xml))).ToArray();

            Dictionary<String, Int32> expected = new Dictionary<String, Int32>()
            {
                { "score", 1 },
                { "date", 2 }
            };

            XmlSearcher xmlSearcher = new XmlSearcher(2);
            Dictionary<String, Int32> result = xmlSearcher.Search(memoryStream, "sort/@s_c");

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
