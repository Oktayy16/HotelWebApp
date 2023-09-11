using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; } // Odalar sadece rakam değil metinsel değerde alacak 5C gibi
        public string RoomCoverImage { get; set; } // resim
        public int Price { get; set; }
        public string Title { get; set; }
        public string BedCount { get; set; }
        public string BathCount { get; set; }
        public string Wife { get; set; }
        public string Description { get; set; }


    }
}
