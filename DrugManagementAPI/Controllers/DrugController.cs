using DrugManagement.Data.Entities;
using DrugManagement.Data.Repositories;
using DrugManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        public DrugRepository DrugRepository { get; set; }
        public DrugController()
        {
            this.DrugRepository = new DrugRepository();
        }

        [HttpGet]
        public List<TblDrug> GetAllDrugs()
        {
            return this.DrugRepository.GetAllDrugs();
        }

        [HttpPost]
        public void AddDrug(Drug drug)
        {
            TblDrug tblDrug = new TblDrug();
            tblDrug.Name = drug.Name;
            tblDrug.ManufacturedDate = drug.ManufacturedDate;
            tblDrug.ExpiryDate= drug.ExpiryDate;
            tblDrug.SupplierId = drug.SupplierId;
            this.DrugRepository.AddDrug(tblDrug);
        }

        [HttpDelete]
        public void DeleteDrug(int drugId)
        {
            this.DrugRepository.DeleteDrug(drugId);
        }

        [HttpPut]
        public void UpdateDrug(Drug drug)
        {
            TblDrug tblDrug= new TblDrug(); 
            tblDrug.Id = drug.Id;
            tblDrug.Name = drug.Name;
            tblDrug.ManufacturedDate= drug.ManufacturedDate;
            tblDrug.ExpiryDate = drug.ExpiryDate;
            tblDrug.SupplierId= drug.SupplierId;
            this.DrugRepository.UpdateDrug(tblDrug);
        }

        [HttpGet("{drugId:int}")]
        public TblDrug GetDrug(int drugId)
        {
            return this.DrugRepository.GetDrug(drugId);
        }
    }
}
