using System;

namespace WinCSVTest.Models
{
    public class WHData
    {
        public string StationName { get; set; }
        public int screen_id { get; set; }
        public DateTime date { get; set; }
        public int depth_to_water_level { get; set; }
        public string comment { get; set; }
    }
}