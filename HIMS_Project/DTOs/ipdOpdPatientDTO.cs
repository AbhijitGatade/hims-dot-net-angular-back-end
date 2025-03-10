namespace HIMS_Project.DTOs
{
    public class ipdOpdPatientDTO
    {
        public List<PatientDTO> Patient { get; set; }

        public List<IpdpatientDTO> Ipdpatient { get; set; }
        public List<OpdpatientDTO> Opdpatient { get; set; }
    }
}
