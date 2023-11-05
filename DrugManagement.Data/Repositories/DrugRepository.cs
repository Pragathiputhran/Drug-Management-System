using DrugManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugManagement.Data.Repositories
{
    public class DrugRepository
    {
        DmsdbContext DmsdbContext { get; set; }
        public DrugRepository()
        {
            this.DmsdbContext = new DmsdbContext();
        }

        public List<TblDrug> GetAllDrugs()
        {
            return this.DmsdbContext.TblDrugs.ToList();
        }

        public void AddDrug(TblDrug drug)
        {
            this.DmsdbContext.TblDrugs.Add(drug);
            this.DmsdbContext.SaveChanges();
        }

        public void DeleteDrug(int drugId)
        {
            var drugToBeDeleted = this.DmsdbContext.TblDrugs.Where(d => d.Id == drugId).FirstOrDefault();
            if(drugToBeDeleted != null)
            {
                this.DmsdbContext.TblDrugs.Remove(drugToBeDeleted);
                this.DmsdbContext.SaveChanges();
            }
        }

        public void UpdateDrug( TblDrug drug)
        {
            var drugToBeUpdated=this.DmsdbContext.TblDrugs.Where(d=>d.Id== drug.Id).FirstOrDefault();
            if(drugToBeUpdated != null)
            {
                drugToBeUpdated.Name = drug.Name;
                this.DmsdbContext.SaveChanges();
            }
        }

        public TblDrug GetDrug(int drugId)
        {
            return this.DmsdbContext.TblDrugs.Where(d => d.Id == drugId).FirstOrDefault();
        }
    }
}
