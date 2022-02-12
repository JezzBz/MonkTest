using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class SentMessage
    {
        [Key]
        public int id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string recipients { get; set; }

        public DateTime CreatedDate { get; set; }
        public RequestResult Result { get; set; }
        public string FailedMessage { get; set; }
    }
}
public enum RequestResult
{
    Ok,
    Failed
}