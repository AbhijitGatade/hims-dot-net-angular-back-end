using HIMS_Project.Models;
using System.Security.Permissions;

namespace HIMS_Project.Services
{
    public interface IPatientService
    {
        void CreateCalculation(int billid);
        string GenerateUID();
    }
   
}
