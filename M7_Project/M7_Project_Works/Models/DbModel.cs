using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace M7_Project_Works.Models
{
    public enum Location { Asia, Africa, Europe, Australia, America}
    public class team
    {
        [Display(Name ="Team ID")]
        public int teamId { get; set; }
        [Required, StringLength(50), Display(Name ="Team Name")]
        public string teamName { get; set; }
        [Required, EnumDataType(typeof(Location)), Display(Name = "Region")]
        public Location? Location { get; set; }
        [Required, StringLength(20), Display(Name ="Contact No.")]
        public string Contact { get; set; }
        [Required, Column(TypeName = "date")]
        [Display(Name = "Established On"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Established { get; set; }
        //Navigation
        public virtual ICollection<Player> Players { get; set; }
    }
    public class Player
    {
        public int PlayerId { get; set; }
        [Required, StringLength(50)]
        [Display(Name = "Player Name")]
        public string PlayerName { get; set; }
        [Required, Column(TypeName = "money")]
        [Display(Name = "Basic Salary")]
        public decimal BasicSalary { get; set; }
        //FK
        [Required]
        [Display(Name = "Team")]
        public int teamId { get; set; }
        //Navigation
        [ForeignKey("teamId")]
        public virtual team team { get; set; }
    }
    public class teamDbContext: DbContext
    {
        public teamDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<team> teams { get; set; }
        public DbSet<Player> Players { get; set; }
    }
    public class DbInitializer : DropCreateDatabaseIfModelChanges<teamDbContext>
    {
        protected override void Seed(teamDbContext context)
        {
           
        }
    }


}