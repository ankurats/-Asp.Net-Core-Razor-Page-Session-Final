using System;
using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Data
{
    public class Training
    {
        public int Id { get; set; }
        [Required, StringLength(40)]
        public string Title { get; set; }
        [Required, StringLength(50)]
        public string Trainer { get; set; }
        [Required]
        public TrainingLevel Level { get; set; }
    }

    public enum TrainingLevel
    {
        None,
        Beginner,
        Intermediate,
        Advanced
    }
}
