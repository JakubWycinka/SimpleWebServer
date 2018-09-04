using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebServer.Models.DtoModels
{
    public class SimpleMessageDto
    {
        public int Id { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
