using System;
using System.Collections.Generic;

namespace DrugManagement.Data.Entities;

public partial class TblDrug
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? ManufacturedDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public int? SupplierId { get; set; }

    public virtual TblSupplier? Supplier { get; set; }
}
