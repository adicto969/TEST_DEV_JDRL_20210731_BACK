using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TEST_DEV_JRL_20210731.DataAccess.Dto.Input
{
    public class PersonCreateDtoInput
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }
        [Required]
        public string ApellidoMaterno { get; set; }
        [Required]
        [StringLength(13, MinimumLength = 13)]
        public string Rfc { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        public int UsuarioAgrega { get; set; }
    }
}
