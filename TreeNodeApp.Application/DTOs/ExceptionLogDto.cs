using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeNodeApp.Application.DTOs
{
    public class ExceptionLogDto
    {
        public long EventId { get; set; }
        public string? ExceptionType { get; set; }
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; }
        public string? QueryParameters { get; set; }
        public string? BodyParameters { get; set; }
        public string? StackTrace { get; set; }
    }
}
