﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario//Objeto Usuario
    {
        [Key] //para que automaticamente incremente el primero
        public int PkUsuario { get; set; }
        public string Nombre { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        [ForeignKey("Roles")]
        public int? FkRol {  get; set; }//Para aceptar cualalquier cosa (CREO)
        public Rol Roles { get; set; }
    }
}
