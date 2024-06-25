using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sube1_HELLOMVC.Models.ViewModels
{
    public class Ogrenci_Ders
    {
        public int OgrenciId { get; set; }
        public int DersId { get; set; }
        public IEnumerable<Ders> Dersler { get; set; }
    }
}