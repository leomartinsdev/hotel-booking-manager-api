namespace TrybeHotel.Dto
{
     public class RoomDto
     {
          public int roomId { get; set; }
          public string name { get; set; }
          public int capacity { get; set; }
          public string image { get; set; }
<<<<<<< HEAD
          public HotelDto hotel { get; set; }
=======
          public HotelDto? hotel { get; set; }
>>>>>>> faseB/leonardo-martins-trybe-hotel-fase-b
     }
}