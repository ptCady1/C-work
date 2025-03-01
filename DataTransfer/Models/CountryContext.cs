using DataTransfer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataTransfer.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Games> Game { get; set; } = null!;
        public DbSet<SportType> SportsTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Games>().HasData(
                new Games
                {
                    GamesID = "win",
                    Name = "winter",
                },
                new Games
                {
                    GamesID = "sum",
                    Name = "summer",
                },
                new Games
                {
                    GamesID = "para",
                    Name = "para",
                },
                new Games
                {
                    GamesID = "youth",
                    Name = "youth",
                }
                );

            modelBuilder.Entity<SportType>().HasData(
                new SportType
                {
                    SportTypeID = "cu_in",
                    SportName = "Curling/Indoor",
                },
                new SportType
                {
                    SportTypeID = "bob_ou",
                    SportName = "Bobsleigh/Outdoor",
                },
                new SportType
                {
                    SportTypeID = "di_in",
                    SportName = "Diving/Indoor",
                },
                new SportType
                {
                    SportTypeID = "ro_in",
                    SportName = "Road Cycling/Outdoor",
                },
                new SportType
                {
                    SportTypeID = "cy_in",
                    SportName = "Cycling/Outdoor",
                },
                new SportType
                {
                    SportTypeID = "ar_in",
                    SportName = "Archery/Indoor",
                },
                new SportType
                {
                    SportTypeID = "can_in",
                    SportName = "Canoe Sprint/Outdoor",
                },
                new SportType
                {
                    SportTypeID = "bre_in",
                    SportName = "Breakdancing/Indoor",
                },
                new SportType
                {
                    SportTypeID = "ska_in",
                    SportName = "Skateboarding/Outdoor",
                }
                );

            modelBuilder.Entity<Country>().HasData(
                new 
                {
                    countryID = "can",
                    countryName = "Canada",
                    GamesID = "win",
                    SportTypeID = "cu_in",
                    Flag = "Flag_of_Canada.png"
                },
                new
                {
                    countryID = "aus",
                    countryName = "Austria",
                    GamesID = "para",
                    SportTypeID = "ca_ou",
                    Flag = "Flag_of_Austria.png"
                },
                new
                {
                    countryID = "bra",
                    countryName = "Brazil",
                    GamesID = "sum",
                    SportTypeID = "ro_ou",
                    Flag = "Flag_of_Brazil.png"
                },
                new
                {
                    countryID = "cyp",
                    countryName = "Cyprus",
                    GamesID = "youth",
                    SportTypeID = "bre_in",
                    Flag = "Flag_of_Cyprus.png"
                },
                new
                {
                    countryID = "fra",
                    countryName = "France",
                    GamesID = "youth",
                    SportTypeID = "bre_in",
                    Flag = "Flag_of_France.png"
                },
                new
                {
                    countryID = "fin",
                    countryName = "Finland",
                    GamesID = "youth",
                    SportTypeID = "ska_ou",
                    Flag = "Flag_of_Finland.png"
                },
                new
                 {
                     countryID = "slo",
                     countryName = "Slovakia",
                     GamesID = "youth",
                     SportTypeID = "ska_ou",
                     Flag = "Flag_of_Slovakia.png"
                 },
                 new
                  {
                      countryID = "por",
                      countryName = "Portugal",
                      GamesID = "youth",
                      SportTypeID = "ska_ou",
                      Flag = "Flag_of_Portugal.png"
                  },
                new
                {
                    countryID = "ger",
                    countryName = "Germany",
                    GamesID = "sum",
                    SportTypeID = "di_in",
                    Flag = "Flag_of_Germany.png"
                },
                new
                {
                    countryID = "jam",
                    countryName = "Jamaica",
                    GamesID = "win",
                    SportTypeID = "bob_ou",
                    Flag = "Flag_of_Jamaica.png"
                },
                new
                {
                    countryID = "mex",
                    countryName = "Mexico",
                    GamesID = "sum",
                    SportTypeID = "di_in",
                    Flag = "Flag_of_Mexico.png"
                },
                    new
                    {
                        countryID = "pak",
                        countryName = "Pakistan",
                        GamesID = "para",
                        SportTypeID = "ca_ou",
                        Flag = "Flag_of_Pakistan.png"
                    },
                    new
                    {
                        countryID = "rus",
                        countryName = "Russia",
                        GamesID = "youth",
                        SportTypeID = "bre_in",
                        Flag = "Flag_of_Russia.png"
                    },
                    new
                    {
                        countryID = "thai",
                        countryName = "Thailand",
                        GamesID = "para",
                        SportTypeID = "ar_in",
                        Flag = "Flag_of_Thailand.png"
                    },
                    new
                    {
                        countryID = "net",
                        countryName = "Netherland",
                        GamesID = "sum",
                        SportTypeID = "cy_ou",
                        Flag = "Flag_of_the_Netherlands.png"
                    },
                    new
                    {
                        countryID = "chi",
                        countryName = "China",
                        GamesID = "sum",
                        SportTypeID = "di_in",
                        Flag = "Flag_of_the_People's_Republic_of_China.png"
                    },
                    new
                    {
                        countryID = "bri",
                        countryName = "United Kingdom",
                        GamesID = "win",
                        SportTypeID = "cu_in",
                        Flag = "Flag_of_the_United_Kingdom.png"
                    },
                    new
                    {
                        countryID = "usa",
                        countryName = "United States",
                        GamesID = "sum",
                        SportTypeID = "co_ou",
                        Flag = "Flag_of_the_United_States.png"
                    },
                    new
                    {
                        countryID = "ukr",
                        countryName = "Ukrain",
                        GamesID = "para",
                        SportTypeID = "ar_in",
                        Flag = "Flag_of_Ukrain.png"
                    },

                    new
                {
                        countryID = "uru",
                        countryName = "Urugauy",
                        GamesID = "para",
                        SportTypeID = "ar_in",
                        Flag = "Flag_of_Urugauy.png"
                    },
                    new
                    {
                        countryID = "zim",
                        countryName = "Zimbabwe",
                        GamesID = "para",
                        SportTypeID = "ca_ou",
                        Flag = "Flag_of_Zimbabwe.png"
                    },
                    new
                    {
                        countryID = "ita",
                        countryName = "Italy",
                        GamesID = "win",
                        SportTypeID = "bob_ou",
                        Flag = "Italy.png"
                    },
                    new
                    {
                        countryID = "jap",
                        countryName = "Japan",
                        GamesID = "win",
                        SportTypeID = "bob_ou",
                        Flag = "Japan.png"
                },
                    new
                    {
                        countryID = "swe",
                        countryName = "Sweden",
                        GamesID = "win",
                        SportTypeID = "cu_in",
                        Flag = "Sweden.png"
                    }
                );
        }
    }
}
