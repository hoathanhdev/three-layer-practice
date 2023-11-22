using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class PhieuXuat_BUS
    {
        public static List<PhieuXuat_DTO> LayDSPhieuXuat()
        {
            return PhieuXuat_DAO.LayDSPhieuXuat();
        }

        public static List<PhieuXuat_DTO> TimPhieuXuatBangTuKhoa(string tukhoa)
        {
            return PhieuXuat_DAO.TimPhieuNhapBangTuKhoa(tukhoa);
        }

        public static PhieuXuat_DTO TimPhieuXuatTheoMa(string ma)
        {
            return PhieuXuat_DAO.TimPhieuXuatTheoMa(ma);
        }

        public static bool ThemPhieuXuat(PhieuXuat_DTO dl)
        {
            return PhieuXuat_DAO.ThemPhieuXuat(dl);
        }

        public static bool SuaPhieuXuat(PhieuXuat_DTO dl)
        {
            return PhieuXuat_DAO.SuaPhieuXuat(dl);
        }

        public static bool XoaPhieuXuat(PhieuXuat_DTO dl)
        {
            return PhieuXuat_DAO.XoaPhieuXuat(dl);
        }
    }
}
