using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodeApp.Core.Enums;

namespace TreeNodeApp.Core.Entities
{
    public class ExceptionLog
    {
        [Key]
        public long Id { get; set; }
        public long EventId { get; set; }
        public DateTime Timestamp { get; set; }
        public string QueryParameters { get; set; }
        public string BodyParameters { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
        public ExceptionType Type { get; set; }
    }
}
