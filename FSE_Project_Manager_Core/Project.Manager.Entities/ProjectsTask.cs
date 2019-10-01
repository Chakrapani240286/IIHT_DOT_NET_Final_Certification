using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Manager.Entities
{
    [Table("tbl_project_task")]
    public class ProjectsTask
    {
        [Key]
        [Column("project_task_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectsTaskId { get; set; }

        [Column("title")]
        [MaxLength(200)]
        public string Title { get; set; }

        [Column("description")]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Column("priority")]
        [MaxLength(200)]
        public string Priority { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("project_id")]
        public int ProjectsId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("task_user_id")]
        public int TaskUserId { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        public Projects Projects { get; set; }
    }
}
