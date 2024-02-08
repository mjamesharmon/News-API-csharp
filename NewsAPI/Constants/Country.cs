using System;
using System.Globalization;

namespace NewsAPI.Constants
{
	public readonly struct Country : IEquatable<Country>
	{
		private readonly string _value;

        public static Country AE => new Country(Countries.AE);
    
        public static Country AR => new Country(Countries.AR);
      
        public static Country AT => new Country(Countries.AT);

        public static Country AU => new Country(Countries.AU);
 
        public static Country BE => new Country(Countries.BE);

        public static Country BG => new Country(Countries.BG);

        public static Country BR => new Country(Countries.BR);
      
        public static Country CA => new Country(Countries.CA);

        public static Country CH => new Country(Countries.CH);
    
        public static Country CN => new Country(Countries.CN);

        public static Country CO => new Country(Countries.CO);

        public static Country CU => new Country(Countries.CU);
     
        public static Country CZ => new Country(Countries.CZ);
    
        public static Country DE => new Country(Countries.DE);
      
        public static Country EG => new Country(Countries.EG);
     
        public static Country FR => new Country(Countries.FR);
    
        public static Country GB => new Country(Countries.GB);
  
        public static Country GR => new Country(Countries.GR);

        public static Country HK => new Country(Countries.HK);
  
        public static Country HU => new Country(Countries.HU);

        public static Country ID => new Country(Countries.ID);
    
        public static Country IE => new Country(Countries.IE);

        public static Country IL => new Country(Countries.IL);

        public static Country IN => new Country(Countries.IN);
     
        public static Country IT => new Country(Countries.IT);

        public static Country JP => new Country(Countries.JP);

        public static Country KR => new Country(Countries.KR);

        public static Country LT => new Country(Countries.LT);

        public static Country LV => new Country(Countries.LV);

        public static Country MA => new Country(Countries.MA);

        public static Country MX => new Country(Countries.MX);

        public static Country MY => new Country(Countries.MY);

        public static Country NG => new Country(Countries.NG);

        public static Country NL => new Country(Countries.NL);

        public static Country NO => new Country(Countries.NO);
 
        public static Country NZ => new Country(Countries.NZ);

        public static Country PH => new Country(Countries.PH);

        public static Country PL => new Country(Countries.PL);

        public static Country PT => new Country(Countries.PT);

        public static Country RO => new Country(Countries.RO);

        public static Country RS => new Country(Countries.RS);

        public static Country RU => new Country(Countries.RU);

        public static Country SA => new Country(Countries.SA);

        public static Country SE => new Country(Countries.SE);

        public static Country SG => new Country(Countries.SG);

        public static Country SI => new Country(Countries.SI);

        public static Country SK => new Country(Countries.SK);

        public static Country TH => new Country(Countries.TH);

        public static Country TR => new Country(Countries.TR);

        public static Country TW => new Country(Countries.TW);

        public static Country UA => new Country(Countries.UA);

        public static Country US => new Country(Countries.US);

        public static Country VE => new Country(Countries.VE);

        public static Country ZA => new Country(Countries.ZA);

        /// <summary>
        /// 
        /// </summary>
        public string Name => _value;

		public static Country FromName(string country) =>
			new Country(country);

        public static Country FromKnownRegion(RegionInfo knownRegion) =>
            new Country(knownRegion.TwoLetterISORegionName);

		private Country(Countries knownCountry) :
			this(knownCountry.ToString())
		{ }

        private Country(string country)
		{
			_value = country.ToLowerInvariant();
		}

        public bool Equals(Country other)
        {
            return this._value.Equals(other._value);
        }
    }
}

