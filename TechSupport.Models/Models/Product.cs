using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSupport.Models;

public partial class Product
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string ProductCode { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(18, 1)")]
    public decimal Version { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ReleaseDate { get; set; }

    [InverseProperty("ProductCodeNavigation")]
    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();

    [InverseProperty("ProductCodeNavigation")]
    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();

    public override string ToString()
    {
        // Define the total widths for each field
        int codeWidth = 15;    // Width for ProductCode
        int nameWidth = 40;    // Width for Name
        int versionWidth = 11;  // Width for Version
        int dateWidth = 15;     // Width for ReleaseDate

        // Format the ReleaseDate as a short date string and Version to one decimal place
        string formattedProductCode = ProductCode.PadRight(codeWidth);
        string formattedName = Name.PadRight(nameWidth);
        string formattedVersion = Version.ToString("F1").PadRight(versionWidth);
        string formattedReleaseDate = ReleaseDate.ToString("MM/dd/yyyy").PadRight(dateWidth);

        // Combine all formatted strings
        return $"{formattedProductCode} {formattedName} {formattedVersion}{formattedReleaseDate}";
    }
}


