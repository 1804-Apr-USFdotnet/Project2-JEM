using System;

namespace FTV.DAL
{
    public abstract class BaseEntity
    {
        private DateTime Created { get; set; }
        private DateTime? Modified { get; set; }
    }
}