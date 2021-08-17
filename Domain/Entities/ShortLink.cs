using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class ShortLink
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
