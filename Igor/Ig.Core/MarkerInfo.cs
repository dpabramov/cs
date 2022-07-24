using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ig.Core
{
    public class MarkerInfo
    {
        public int Id;
        public string Name;
        public float Latitude;
        public float Longitude;

        public MarkerInfo(int id,
                        string name,
                        float latitude,
                        float longitude)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public static List<MarkerInfo> GetMarkerInfoFromCsv(string path)
        {
            List<MarkerInfo> result = new List<MarkerInfo>();

            List<string> data = (File.ReadAllLines(path)).ToList();

            foreach (string sValue in data)
            {
                string[] record = new string[4];
                record = sValue.Split(',');

                var markerInfo = new MarkerInfo((int)Int64.Parse(record[0]),
                                      record[1],
                                      float.Parse(record[2].Replace('.', ',')),
                                      float.Parse(record[3].Replace('.', ',')));

                result.Add(markerInfo);
            }

            return result;
        }
    }
}
