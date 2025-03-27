using HIMS_Project.Context;
using HIMS_Project.DTOs;
using HIMS_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HIMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        ProjectDBContext _context;
        public AuthenticationController(ProjectDBContext context) {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            LoginStatusDTO loginStatusDTO = new LoginStatusDTO();
            List<User> users = _context.Users.Where(u => u.Username.Equals(loginDTO.username) && u.Password.Equals(loginDTO.password)).ToList();
            if(users.Count == 0)
                loginStatusDTO.status = "failed";
            else
            {
                loginStatusDTO.status = "success";
                loginStatusDTO.user = users[0];

                var result = from m in _context.Menus
                             join rm in _context.RoleMenus
                             on m.Id equals rm.Menuid
                             where m.Parentmenuid == 0 && rm.Roleid == loginStatusDTO.user.Roleid
                             orderby m.Srno
                             select m;
                loginStatusDTO.topmenus = result;

                result = from m in _context.Menus
                             join rm in _context.RoleMenus
                             on m.Id equals rm.Menuid
                             where m.Parentmenuid != 0 && rm.Roleid == loginStatusDTO.user.Roleid
                             orderby m.Srno
                             select m;
                loginStatusDTO.navmenus = result;

                result = from m in _context.Menus
                             where m.Parentmenuid != 0 && m.Isparentmenu.Equals("false")
                             orderby m.Id
                             select m;
                loginStatusDTO.childmenus = result;

            }
            return Ok(loginStatusDTO);
        }
    }
}
