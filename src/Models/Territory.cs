using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Territory
{
    [Key]
    [MaxLength(20)]
    public string TerritoryID { get; set; }

    [Required]
    [MaxLength(50)]
    public string TerritoryDescription { get; set; }

    public int RegionID { get; set; }

    [ForeignKey("Region")]
    public virtual Region Region { get; set; }

    public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
}