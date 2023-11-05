using System;
using System.Collections.Generic;

namespace DrugManagement.Data.Entities;

public partial class TblSupplier
{
    public int SupplierId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<TblDrug> TblDrugs { get; set; } = new List<TblDrug>();
}
