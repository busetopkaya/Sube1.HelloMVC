using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sube1_HELLOMVC.Models
{
    public class OgrenciDers
    {
        public int OgrenciId { get; set; }
        public virtual Ogrenci Ogrenci { get; set; }

        public int DersId { get; set; }
        public virtual Ders Ders { get; set; }
    }
}