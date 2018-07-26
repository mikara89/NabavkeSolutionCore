using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NabavkeSolutionCore.Models.Mobile
{
    public interface IDevide
    {
        int total_count { get; set; }
        int offset { get; set; }
        int limit { get; set; }
        List<Player> players { get; set; }
        string[] playersIdArray { get; }
    }

    public interface IPlayer
    {
        string id { get; set; }
        string identifier { get; set; }
        int session_count { get; set; }
        string language { get; set; }
        int timezone { get; set; }
        string game_version { get; set; }
        string device_os { get; set; }
        int device_type { get; set; }
        string device_model { get; set; }
        string ad_id { get; set; }
        Dictionary<string, string> tags { get; set; }
        int last_active { get; set; }
        double amount_spent { get; set; }
        int created_at { get; set; }
        bool invalid_identifier { get; set; }
        int badge_count { get; set; }
    }

    public class Device:IDevide
    {
        public Device()
        {
            players = new List<Player>();
        }
        public int total_count { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public List<Player> players { get; set; }

        public string[] playersIdArray
        {
            get
            {
                string[] a = new string[players.Count];
                for (int i = 0; i < players.Count; i++)
                {
                    a[i] = players.ElementAt(i).id;
                }
                return a;
            }
        }
    }

    public class Player:IPlayer
    {
        public Player()
        {
            tags = new Dictionary<string, string>();
        }
        public string id { get; set; }
        public string identifier { get; set; }
        public int session_count { get; set; }
        public string language { get; set; }
        public int timezone { get; set; }
        public string game_version { get; set; }
        public string device_os { get; set; }
        public int device_type { get; set; }
        public string device_model { get; set; }
        public string ad_id { get; set; }
        public Dictionary<string, string> tags { get; set; }
        public int last_active { get; set; }
        public double amount_spent { get; set; }
        public int created_at { get; set; }
        public bool invalid_identifier { get; set; }
        public int badge_count { get; set; }
    }

}