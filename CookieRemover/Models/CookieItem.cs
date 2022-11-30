﻿namespace CookieExtension.Models
{
    public class CookieItem
    {
        public string CookieName { get; set; }
        public string CookieValue { get; set; }
        public string CookieDomain { get; set; }
        public string CookiePath { get; set; }
        public string CookieExpiryDate { get; set; }
        public CookieItem(string Name, string Value, string Domain, string Path, string ExpDate) 
        { 
            CookieName= Name;
            CookieValue= Value;
            CookieDomain= Domain;
            CookiePath= Path;
            CookieExpiryDate = ExpDate;
        }

    }
}
