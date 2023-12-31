﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiii.Models
{
    public class Doktor
    {
        public int DoktorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string DoktorAdi { get; set; }
        [Required]
        [MaxLength(100)]
        public string DoktorSoyadi { get; set; }
 
        public int PoliklinikId { get; set; }
        
        public Poliklinik? Poliklinik { get; set; }
        public ICollection<Randevu>? Randevu { get; set;}
           
    }
}
