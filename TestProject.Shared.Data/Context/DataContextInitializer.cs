using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Shared.Data.Context
{
    public class DataContextInitializer
    {
        public static void SeedCountries(DataContext context)
        {
            Country[] countries =
            {
                new Country(){ NameKz = "Казахстан", NameRu = "Казахстан"},
                new Country(){ NameRu = "Россия", NameKz = "Россия"},
                new Country(){ NameKz = "Украина", NameRu = "Украина" },
                new Country(){ NameRu = "Беларусь", NameKz = "Беларусь"},
                new Country(){ NameKz = "Монголия", NameRu = "Монголия" }
            };
            if (!context.Countries.Any())
            {
                context.Countries.AddRange(countries);
            }

            context.SaveChanges();
        }

        public static void SeedCities(DataContext context)
        {
            var kz = context.Countries.Where(x => x.NameRu == "Казахстан").Select(x => x.Id).FirstOrDefault();
            var ru = context.Countries.Where(x => x.NameRu == "Россия").Select(x => x.Id).FirstOrDefault();
            var ua = context.Countries.Where(x => x.NameRu == "Украина").Select(x => x.Id).FirstOrDefault();
            var blr = context.Countries.Where(x => x.NameRu == "Беларусь").Select(x => x.Id).FirstOrDefault();
            var mn = context.Countries.Where(x => x.NameRu == "Монголия").Select(x => x.Id).FirstOrDefault();

            City[] cities =
            {
                new City(){ NameKz = "Астана", NameRu = "Астана", CountryId = kz},
                new City(){ NameKz = "Алматы", NameRu = "Алматы", CountryId = kz},
                new City(){ NameKz = "Москва", NameRu = "Москва", CountryId = ru},
                new City(){ NameKz = "Киев", NameRu = "Киев", CountryId = ua},
                new City(){ NameKz = "Минск", NameRu = "Минск", CountryId = blr},
                new City(){ NameKz = "Улан-Батор", NameRu = "Улан-Батор", CountryId = mn},
            };
            if (!context.Cities.Any())
            {
                context.Cities.AddRange(cities);
            }

            context.SaveChanges();
        }
    }
}
