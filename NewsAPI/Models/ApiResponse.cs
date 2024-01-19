﻿using NewsAPI.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAPI.Models
{
    internal class ApiResponse
    {
        public Statuses Status { get; set; }
        public ErrorCodes? Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<Article> Articles { get; set; } = new();
        public int TotalResults { get; set; }
    }
}
