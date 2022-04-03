using System;
using System.Collections.Generic;
using System.Text;

namespace _121_Document
{
    public class BaseDocument
    {
        public string DocName { get; set; }

        public string DocNumber { get; set; }

        public DateTimeOffset IssueDate { get; set; }

        public virtual string PropertyString
        {
            get
            {
                return $"DocName: {DocName}, " +
                    $"\nDocNumber: {DocNumber}," +
                    $"\nIssueDate: {IssueDate:dd-MM-yyy}";
            }
        }

        public BaseDocument(string docName, string docNumber, DateTimeOffset issueDate)
        {
            DocName = docName;
            DocNumber = docNumber;
            IssueDate = issueDate;
        }

        public void WriteProperties()
        {
            Console.WriteLine(PropertyString);
        }
    }
}
