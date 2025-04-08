using HIMS_Project.Context;
using HIMS_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace HIMS_Project.Services
{
    public class PatientService : IPatientService
    {

        ProjectDBContext _context;
        string Prefix = "NH-";
        public PatientService(ProjectDBContext context)
        {
            _context = context;
        }
        public string GenerateUID()
        {
            int nextId = 1;
            Patient patient = _context.Patients.OrderByDescending(p => p.Id).FirstOrDefault();
            if (patient != null)
            {
                int lastUID = int.Parse(patient.Uidno.Replace(Prefix, ""));
                nextId = lastUID + 1;
            }
            return $"{Prefix}{nextId:D5}";
        }
        public void CreateCalculation(int billid)
        {
            var opdbill = _context.Opdbills.Find(billid);
            var totalpaid = _context.Opdbillpayments.Where(s => s.Billid == billid).Sum(s => s.PaidAmount);
            opdbill.Paidamount = totalpaid;
            opdbill.Pendingamount = (int)(opdbill.Billamount - opdbill.Paidamount);
            _context.Entry(opdbill).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

    }

}

