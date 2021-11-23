using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<Administrador> GetAdmins(int? PageNumber, int? PageSize);

        Administrador GetAdmin(int id);

        void InsertAdmin(Administrador admin);

        bool UpdateAdmin(Administrador admin);

        bool DeleteAdmin(int id);

    }
}
