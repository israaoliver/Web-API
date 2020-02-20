﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Tarde.Domains
{
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        public string Titulo { get; set; }

        public int IdGenero { get; set; }

        public GeneroDomain Genero { get; set; }


        public FilmeDomain()
        {

        }
    }
}
