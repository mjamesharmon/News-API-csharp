using System;
using System.Globalization;

namespace NewsAPI.Constants
{
    public readonly struct Language : IEquatable<Language>
    {
        private readonly string _value;

        public static Language AF => new Language(Languages.AF);

        public static Language AN => new Language(Languages.AN);

        public static Language AR => new Language(Languages.AR);

        public static Language AZ => new Language(Languages.AZ);

        public static Language BG => new Language(Languages.BG);

        public static Language BN => new Language(Languages.BN);

        public static Language BR => new Language(Languages.BR);

        public static Language BS => new Language(Languages.BS);

        public static Language CA => new Language(Languages.CA);

        public static Language CS => new Language(Languages.CS);

        public static Language CY => new Language(Languages.CY);

        public static Language DA => new Language(Languages.DA);

        public static Language DE => new Language(Languages.DE);

        public static Language EL => new Language(Languages.EL);

        public static Language EN => new Language(Languages.EN);

        public static Language EO => new Language(Languages.EO);

        public static Language ES => new Language(Languages.ES);

        public static Language ET => new Language(Languages.ET);

        public static Language EU => new Language(Languages.EU);

        public static Language FA => new Language(Languages.FA);

        public static Language FI => new Language(Languages.FI);

        public static Language FR => new Language(Languages.FR);

        public static Language GL => new Language(Languages.GL);

        public static Language HE => new Language(Languages.HE);

        public static Language HI => new Language(Languages.HI);

        public static Language HR => new Language(Languages.HR);

        public static Language HT => new Language(Languages.HT);

        public static Language HU => new Language(Languages.HU);

        public static Language HY => new Language(Languages.HY);

        public static Language ID => new Language(Languages.ID);

        public static Language IS => new Language(Languages.IS);

        public static Language IT => new Language(Languages.IT);

        public static Language JP => new Language(Languages.JP);

        public static Language JV => new Language(Languages.JV);

        public static Language KK => new Language(Languages.KK);

        public static Language KO => new Language(Languages.KO);

        public static Language LA => new Language(Languages.LA);

        public static Language LB => new Language(Languages.LB);

        public static Language LT => new Language(Languages.LT);

        public static Language LV => new Language(Languages.LV);

        public static Language MG => new Language(Languages.MG);

        public static Language MK => new Language(Languages.MK);

        public static Language ML => new Language(Languages.ML);

        public static Language MR => new Language(Languages.MR);

        public static Language MS => new Language(Languages.MS);

        public static Language NL => new Language(Languages.NL);

        public static Language NN => new Language(Languages.NN);

        public static Language NO => new Language(Languages.NO);

        public static Language OC => new Language(Languages.OC);

        public static Language PL => new Language(Languages.PL);

        public static Language PT => new Language(Languages.PT);

        public static Language RO => new Language(Languages.RO);

        public static Language RU => new Language(Languages.RU);

        public static Language SH => new Language(Languages.SH);

        public static Language SK => new Language(Languages.SK);

        public static Language SL => new Language(Languages.SL);

        public static Language SQ => new Language(Languages.SQ);

        public static Language SR => new Language(Languages.SR);

        public static Language SV => new Language(Languages.SV);

        public static Language SW => new Language(Languages.SW);

        public static Language TA => new Language(Languages.TA);

        public static Language TE => new Language(Languages.TE);

        public static Language TH => new Language(Languages.TH);

        public static Language TL => new Language(Languages.TL);

        public static Language TR => new Language(Languages.TR);

        public static Language UK => new Language(Languages.UK);

        public static Language UR => new Language(Languages.UR);

        public static Language VI => new Language(Languages.VI);

        public static Language VO => new Language(Languages.VO);

        public static Language ZH => new Language(Languages.ZH);

        /// <summary>
        /// 
        /// </summary>
        public string Name => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public static Language FromName(string language) =>
            new Language(language);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static Language FromKnownCulture(CultureInfo knownCulture) =>
            new Language(knownCulture.TwoLetterISOLanguageName);

        private Language(Languages knownLanguage) :
            this(knownLanguage.ToString())
        { }
      
        private Language(string language)
        {
            _value = language.ToLowerInvariant();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Language other)
        {
          return this._value.Equals(other._value);
        }
    }
}

