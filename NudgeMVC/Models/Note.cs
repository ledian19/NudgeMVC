using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NudgeMVC.Models {
    public class Note {
        [Key]
        public int note_id { get; set; }
        public string note_content { get; set; }
        public int? category_id { get; set; }
        public string note_title { get; set; }
        public string note_highlight { get; set; }
        public int? user_id { get; set; }
        public DateTime? creation_date { get; set; }
        public DateTime? last_updated_on { get; set; }
        public int? label_id { get; set; }
    }
}
