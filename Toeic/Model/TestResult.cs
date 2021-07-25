/*
 * This file is used to implement method due with TestResult.xml
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Xml;

namespace Toeic {
    public class TestResult {

        private String TESTRESULT_URL = @"Data\TestResult.xml";
        private String TAG_ROOT = "Root";
        private String TAG_TEST = "Test";
        private String TAG_TESTNAME = "TestName";
        private String TAG_TESTRESULT = "TestResult";

        private ObservableCollection<TestSample> listTest{get;set;}
        private static TestResult instance = null;
        public static TestResult getInstance() {
            if(instance == null)
                instance = new TestResult();
            return instance;
        }

        public TestResult() {
            listTest = new ObservableCollection<TestSample>();
            Thread threadReadSettingXML = new Thread(loadTestResultFromXMLFile);
            threadReadSettingXML.Start();
        }

        private void loadTestResultFromXMLFile( object obj ) {
            checkFile();
            XmlDocument doc = new XmlDocument();
            try {
                doc.Load(TESTRESULT_URL);
                XmlNodeList testList = doc.GetElementsByTagName(TAG_TEST);
                foreach(XmlNode test in testList) {
                    String testName = test.SelectNodes(TAG_TESTNAME).Item(0).InnerText;
                    char[] testResult = test.SelectNodes(TAG_TESTRESULT).Item(0).InnerText.ToCharArray();
                    //Update listTest lead to update UI
                    App.Current.Dispatcher.Invoke(() => {
                        listTest.Add(new TestSample(testName, testResult));  
                    });
                         
                }
            }catch(Exception e){
                Console.WriteLine(e.ToString());
            }
        }

        public void save() {
            Thread threadSaveXML = new Thread(writeUserSettingsToXML);
            threadSaveXML.Start();
        }

        private void writeUserSettingsToXML() {
            checkFile();
            XmlDocument doc = new XmlDocument();
            try {
                doc.Load(TESTRESULT_URL);
                foreach(TestSample test in listTest) {
                    XmlElement elementName = doc.CreateElement(TAG_TESTNAME);
                    elementName.InnerText = test.testName;
                    XmlElement elementResult = doc.CreateElement(TAG_TESTRESULT);
                    elementResult.InnerText = test.testResult.ToString();
                    XmlElement elementTest = doc.CreateElement(TAG_TEST);
                    elementTest.AppendChild(elementName);
                    elementTest.AppendChild(elementResult);

                    doc.GetElementsByTagName(TAG_ROOT).Item(0).AppendChild(elementTest);
                    doc.Save(TESTRESULT_URL);
                }
            } catch(Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public void checkFile() {
            FileInfo fileInfo = new FileInfo(TESTRESULT_URL);
            if(fileInfo.Exists) {
                Console.WriteLine("Setting exist");
            } else {
                //Create parent directory
                Console.WriteLine("Setting not exist");
                Directory.CreateDirectory(fileInfo.Directory.FullName);

                //Add Declaration tag
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                //Add root tag "Setting"
                XmlElement element1 = doc.CreateElement(TAG_ROOT);
                doc.AppendChild(element1);
                doc.Save(TESTRESULT_URL);
                Console.WriteLine("Setting created !");
            }
        }

        public void addTest(TestSample test){
            listTest.Add(test);
            save();
        }

        public ObservableCollection<TestSample> getListTest() {
            return listTest;
        }
    }
}
