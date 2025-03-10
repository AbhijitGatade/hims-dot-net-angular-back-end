namespace HIMS_Project.Models
{
    public class RoleMenuPostModel
    {
            public int RoleId { get; set; }        // The RoleId for which we are associating menus
            public List<int> Menuids { get; set; } // A list of MenuIds to be associated with the RoleId

    }
}
