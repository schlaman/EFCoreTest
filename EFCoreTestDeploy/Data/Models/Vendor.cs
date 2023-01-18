using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTestDeploy.Data.Models;

[Table("vendor")]
public class Vendor
{
    public int VendorId { get; set; }

    public string Description { get; set; }

    public int VendorCategoryPrimary { get; set; }
}