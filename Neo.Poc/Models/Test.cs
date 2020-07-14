using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Neo.Poc.Models
{
    [Table("Neo_Test")]
    public class NeoTest
    {  
       
        public int NeoTestId { get; set; }
        public string EmailAddress { get; set; }
      
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string PanNumber { get; set; }
        public string PassportNumber { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        //public virtual List<Country> Countries { get; set; }
        public NeoTest()
        {
            
        }

        public static List<Country> GetCountries()
        {
            return  new List<Country>() { new Country() { CountryId = 1, CountryName = "India" },
            new Country() { CountryId = 2, CountryName = "USA" } };
        }
    }

    [Table("Country")]
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
    [Table("State")]
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; }
    }
    [Table("City")]
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
    }
}
