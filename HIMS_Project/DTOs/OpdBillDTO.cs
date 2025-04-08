using HIMS_Project.Models;

namespace HIMS_Project.DTOs
{
    public class OpdBillDTO
    {
        public Opdbill Opdbill { get; set; }
        public Opdbillpayment Opdbillpayment { get; set; }

        public List<Opdbillservice> Opdbillservice { get; set; }


    }
}
