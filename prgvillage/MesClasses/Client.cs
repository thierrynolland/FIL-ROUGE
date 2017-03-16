﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string CP { get; set; }
        public int Categorie { get; set; }
        public decimal Reduction { get; set; }
        public int CommercialId { get; set; }
        
    }
}
