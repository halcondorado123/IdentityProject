﻿namespace Identidad.Models
{
    public class RoleModificar
    {
        public string NombreRol { get; set;}
        public string IdRol { get; set;}

        //public string? Centro_Costo { get; set; }
        public string[]? AgregarIds { get; set;}
        public string[]? EliminarIds { get; set;}

    }
}
