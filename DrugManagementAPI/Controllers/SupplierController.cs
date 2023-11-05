using DrugManagement.Data.Entities;
using DrugManagement.Data.Repositories;
using DrugManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        public SupplierRepository SupplierRepository { get; set; }
        public SupplierController()
        {
            this.SupplierRepository = new SupplierRepository();
        }

        [HttpGet]
        public List<TblSupplier> GetAllSuppliers()
        {
            return this.SupplierRepository.GetAllSuppliers();
        }

        [HttpPost]
        public void AddSupplier(Supplier supplier)
        {
            TblSupplier tblSupplier = new TblSupplier();
            tblSupplier.Name = supplier.Name;
            tblSupplier.Address = supplier.Address;
            this.SupplierRepository.AddSupplier(tblSupplier);
        }

        [HttpDelete]
        public void DeleteSupplier(int supplierId)
        {
            this.SupplierRepository.DeleteSupplier(supplierId);
        }

        [HttpPut]
        public void UpdateSupplier(int supplierId, Supplier supplier)
        {
            TblSupplier tblSupplier = new TblSupplier();
            tblSupplier.Name = supplier.Name;
            this.SupplierRepository.UpdateSupplier(supplierId, tblSupplier);
        }

        [HttpGet("{supplierId:int}")]
        public TblSupplier GetSupplier(int supplierId)
        {
            return this.SupplierRepository.GetSupplier(supplierId);
        }
    }
}
