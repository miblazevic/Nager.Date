﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Croatia
    /// </summary>
    public class CroatiaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// CroatiaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CroatiaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.HR;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nova Godina", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Bogojavljenje, Sveta tri kralja", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Uskrs i uskrsni ponedjeljak", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Uskrs i uskrsni ponedjeljak", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Međunarodni praznik rada", "International Workers' Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Tijelovo", "Corpus Christi", countryCode));
            items.Add(new PublicHoliday(year, 6, 22, "Dan antifašističke borbe", "Anti-Fascist Struggle Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 5, "Dan pobjede i domovinske zahvalnosti i Dan hrvatskih branitelja", "Victory and Homeland Thanksgiving Day and the Day of Croatian defenders", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Velika Gospa", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Dan svih svetih", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Božić", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Prvi dan po Božiću, Sveti Stjepan, Štefanje, Stipanje", "St.Stephen's Day", countryCode));

            items.Add(this.GetIndependenceDay(year, countryCode));
            items.Add(this.GetRemembranceDay(year, countryCode));
            items.Add(this.GetStatehoodDay(year, countryCode));
            items.Add(this.GetNationalDay(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private PublicHoliday GetIndependenceDay(int year, CountryCode countryCode)
        {
            if (year < 2020)
            {
                return new PublicHoliday(year, 10, 8, "Dan neovisnosti", "Independence Day", countryCode);
            }

            return null;
        }

        private PublicHoliday GetRemembranceDay(int year, CountryCode countryCode)
        {
            if (year > 2020)
            {
                return new PublicHoliday(year, 11, 18, "Dan sjećanja na žrtve Domovinskog rata", "Remembrance Day", countryCode);
            }

            return null;
        }

        private PublicHoliday GetStatehoodDay(int year, CountryCode countryCode)
        {
            if (year < 2020)
            {
                return new PublicHoliday(year, 6, 25, "Dan državnosti", "Statehood Day", countryCode);
            }

            return null;
        }

        private PublicHoliday GetNationalDay(int year, CountryCode countryCode)
        {
            if (year > 2020)
            {
                return new PublicHoliday(year, 5, 30, "Dan državnosti", "National Day", countryCode);
            }

            return null;
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Croatia",
            };
        }
    }
}
