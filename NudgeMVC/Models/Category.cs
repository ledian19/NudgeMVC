using System;
using System.ComponentModel.DataAnnotations;

namespace NudgeMVC.Models {
    public class Category {
        [Key]
        public int category_id { get; set; }
        public string? category_name { get; set; }
        public int? parent_category { get; set; }
        public int? user_id { get; set; }
    }
}
