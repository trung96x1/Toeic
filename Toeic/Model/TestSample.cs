using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toeic {
    public class TestSample {
        public String testName { get; set; }
        public char[] testResult { get; set; }

        public TestSample(String testName, char[] testResult) {
            if(testResult.Length != 200)
                return;
            this.testName = testName;
            this.testResult = new char[201];
            for(int i = 0; i < 200; i++) {
                this.testResult[i+1] = testResult[i];
            }
        }
    }
}
