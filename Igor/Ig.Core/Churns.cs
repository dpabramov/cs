using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Ig.Core
{
    public class Churns
    {
        private List<Churn> _churns;

        public Churns()
        {
            _churns = new List<Churn>();
        }

        public void LoadFromCsv(string path)
        {
            List<string> data = (File.ReadAllLines(path)).ToList();

            foreach (string sValue in data)
            {
                string[] record = new string[14];
                record = sValue.Split(',');

                _churns.Add(new Churn
                {
                    RowNumber = (int)Int64.Parse(record[0]),
                    CustomerId = record[1],
                    Surname = record[2],
                    CreditScore = (int)Int64.Parse(record[3]),
                    Geography = record[4],
                    Gender = record[5],
                    Age = (int)Int64.Parse(record[6]),
                    Tenure = (int)Int64.Parse(record[7]),
                    Balance = float.Parse(record[8].Replace('.', ',')),
                    NumOfProducts = (int)Int64.Parse(record[9]),
                    HasCrCard = record[10] == "1" ? true : false,
                    IsActiveMember = record[11] == "1" ? true : false,
                    EstimatedSalary = float.Parse(record[12].Replace('.', ',')),
                    Exited = record[13] == "1" ? true : false
                });
            }
        }
    }
}
