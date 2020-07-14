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
        [Key]
        public int Row_id { get; set; }
        public string EmailAddress { get; set; }
        public List<Country> Countries { get; set; } = new List<Country>() { new Country() { Row_id = 1, CountryName = "India" }, 
            new Country() { Row_id = 2, CountryName = "USA" }
        };
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string PanNumber { get; set; }
        public string PassportNumber { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        public string IsActive { get; set; }
        public NeoTest()
        {
            Countries = new List<Country>() { new Country() { Row_id = 1, CountryName = "India" },
            new Country() { Row_id = 2, CountryName = "USA" } };
        }

    }

    [Table("Country")]
    public class Country
    {
        [Key]
        public int Row_id { get; set; }
        public string CountryName { get; set; }
    }
    [Table("State")]
    public class State
    {
        [Key]
        public int Row_id { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; }
    }
    [Table("City")]
    public class City
    {
        [Key]
        public int Row_id { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
    }
}
