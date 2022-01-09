namespace TaskAlocModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        public int TaskId { get; set; }

        public int PizzaId { get; set; }

        public int ChefId { get; set; }

        public virtual Chef Chef { get; set; }

        public virtual Pizza Pizza { get; set; }
    }
}
