﻿namespace Admin.Domain.Entities.Base
{
    public class BaseEntity
    {
        public long id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
