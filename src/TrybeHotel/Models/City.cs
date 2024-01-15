namespace TrybeHotel.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    // 1. Implemente as models da aplicação
<<<<<<< HEAD
    public class City {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
=======
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
>>>>>>> faseC/leonardo-martins-trybe-hotel-c
        public ICollection<Hotel>? Hotels { get; set; }
    }
}