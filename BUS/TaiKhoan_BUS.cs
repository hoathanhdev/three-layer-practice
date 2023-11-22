using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class TaiKhoan_BUS
    {
        public static List<TaiKhoan_DTO> LayDSTaiKhoan()
        {
            return TaiKhoan_DAO.LayDSTaiKhoan();
        }

         

        public static TaiKhoan_DTO TimTaiKhoanTheoMa(string ma)
        {
            return TaiKhoan_DAO.TimTaiKhoanTheoMa(ma);
        }

        public static bool ThemTaiKhoan(TaiKhoan_DTO dl)
        {
            return TaiKhoan_DAO.ThemTaiKhoan(dl);
        }

        public static bool SuaTaiKhoan(TaiKhoan_DTO dl)
        {
            return TaiKhoan_DAO.SuaTaiKhoan(dl);
        }

        public static bool XoaTaiKhoan(TaiKhoan_DTO dl)
        {
            return TaiKhoan_DAO.XoaTaiKhoan(dl);
        }
    }
}
