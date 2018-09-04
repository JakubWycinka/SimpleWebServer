using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebServer.Models.DbModels
{
    public class SimpleMessage
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public string Message { get; set; }
    }
}
