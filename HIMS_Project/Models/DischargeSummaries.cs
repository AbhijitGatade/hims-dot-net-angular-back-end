using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIMS_Project.Models
{
    [Table("discharge_summaries")]
    public class DischargeSummaries
    {
        [Key]
        [Column("id")]
        public int id {  get; set; }
        [Column("ipdid")]
        public int ipdid { get; set; }

        [Column("discharge_date")]
        public DateOnly discharge_date { get; set; }

        [Column("discharge_time")]
        public string  discharge_time { get; set; }

        [Column("diagnosis")]
        public string diagnosis { get; set; }

        [Column("history_course")]
        public string history_course { get; set; }

        [Column("medicine_course")]
        public string medicine_course { get; set; }

        [Column("operation")]
        public string operation { get; set; }

        [Column("treatment")]
        public string treatment { get; set; }

        [Column("patient_condition")]
        public string patient_condition { get; set; }

        [Column("death_mark")]
        public string death_mark { get; set; }

        [Column("discharge_as")]
        public string discharge_as { get; set; }


        [ForeignKey("ipdid")]
        [InverseProperty("DischargeSummaries")]
        public virtual Ipdpatient? Ipdpatients { get; set; }
    }
}
