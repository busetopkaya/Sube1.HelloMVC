﻿namespace Sube1.HelloMVC.Models
{
    public class Ogrenci : Object
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Numara { get; set; }
        public int Ogrenciid { get; set; }


        public override string ToString()
        {
            return $"Ad:{Ad}-Soyad:{Soyad}-Numara:{Numara}";
        }
    }
}
