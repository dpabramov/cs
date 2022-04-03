using System;
using System.Collections.Generic;
using System.Text;

namespace _121_Document
{
    public class Pasport : BaseDocument
    {
        public string Country { get; set; }

        public string PersonName { get; set; }

        public Pasport(string docNumber, DateTimeOffset issueDate): 
            base("Pasport",docNumber, issueDate)
        {
        }

        public Pasport(string docNumber,
            DateTimeOffset issueDate,
            string country,
            string personName) :
            this(docNumber, issueDate)
        {
            Country = country;
            PersonName = personName;
        }

        public override string PropertyString
        {
            get
            {
                return base.PropertyString +
                    $"\nCountry: {Country}" +
                    $"\nPersonName: {PersonName}";
            }
        }

        public void ChangeIssueDate(DateTimeOffset dateTimeOffset)
        {
            IssueDate = dateTimeOffset;
        }
    }
}
