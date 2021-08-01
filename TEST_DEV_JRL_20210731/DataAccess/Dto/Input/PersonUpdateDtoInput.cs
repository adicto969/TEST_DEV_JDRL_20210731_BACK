using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TEST_DEV_JRL_20210731.DataAccess.Dto.Input
{
    public class PersonUpdateDtoInput
    {
        public int IdPersonaFisica { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        [StringLength(13, MinimumLength = 13)]
        public string Rfc { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
