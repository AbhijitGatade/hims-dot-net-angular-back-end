using HIMS_Project.Models;

namespace HIMS_Project.DTOs
{
    public class LoginStatusDTO
    {   
        public string status { get; set; }
        public User user { get; set; }
        public IQueryable<Menu> topmenus { get; set; }
        public IQueryable<Menu> navmenus { get; set; }
        public IQueryable<Menu> childmenus { get; set; }

    }
}
