﻿using System;

namespace MobileStore.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
    }
}