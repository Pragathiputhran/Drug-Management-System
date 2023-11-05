using DrugManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugManagement.Data.Repositories
{
    public class SupplierRepository
    {
        DmsdbContext DmsdbContext { get; set; }
        public SupplierRepository() 
        {
            this.DmsdbContext = new DmsdbContext();
        }

        public List<TblSupplier> GetAllSuppliers()
        {
            return this.DmsdbContext.TblSuppliers.ToList();
        }

        public void AddSupplier(TblSupplier supplier)
        {
            this.DmsdbContext.TblSuppliers.Add(supplier);
            this.DmsdbContext.SaveChanges();
        }

        public void DeleteSupplier(int supplierId)
        {
            var supplierToBeDeleted=this.DmsdbContext.TblSuppliers.Where(s=>s.SupplierId==supplierId).FirstOrDefault();
            if(supplierToBeDeleted != null)
            {
                this.DmsdbContext.TblSuppliers.Remove(supplierToBeDeleted);
                this.DmsdbContext.SaveChanges();
            }
        }
        public void UpdateSupplier(int supplierId,TblSupplier supplier)
        {
            var supplierToBeUpdated=this.DmsdbContext.TblSuppliers.Where(s=>s.SupplierId == supplierId).FirstOrDefault();
            if(supplierToBeUpdated != null)
            {
                supplierToBeUpdated.Name = supplier.Name;
                this.DmsdbContext.SaveChanges();
            }
        }

        public TblSupplier GetSupplier(int supplierId)
        {
            return this.DmsdbContext.TblSuppliers.Where(s => s.SupplierId == supplierId).FirstOrDefault();
        }
    }
}
