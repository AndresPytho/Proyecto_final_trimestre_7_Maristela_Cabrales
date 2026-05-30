using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestion_semilleros.Models
{
    public class AdminDashboardViewModel
    {
        public int TotalSemilleros { get; set; }
        public int TotalUsuarios { get; set; }
        public int TotalProyectos { get; set; }
        public int TotalReuniones { get; set; }
        public int TotalPatrocinadores { get; set; }
    }
}

