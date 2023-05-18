﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BrowserTravel.Library.Entities.Dto.Auth
{
    public class RegisterDto
    {
        public RegisterDto()
        {
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
