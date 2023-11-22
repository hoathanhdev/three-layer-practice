using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class NhanVien_BUS
    {
        public static List<NhanVien_DTO> LayDSNhanVien()
        {
            return NhanVien_DAO.LayDSNhanVien();
        }

        public static List<NhanVien_DTO> TimNhanVienBangTuKhoa(string tukhoa)
        {
            return NhanVien_DAO.TimNhanVienBangTuKhoa(tukhoa);
        }

        public static NhanVien_DTO TimNhanVienTheoMa(string ma)
        {
            return NhanVien_DAO.TimNhanVienTheoMa(ma);
        }

        public static bool ThemNhanVien(NhanVien_DTO dl)
        {
            return NhanVien_DAO.ThemNhanVien(dl);
        }

        public static bool SuaNhanVien(NhanVien_DTO dl)
        {
            return NhanVien_DAO.SuaNhanVien(dl);
        }

        public static bool XoaNhanVien(NhanVien_DTO dl)
        {
            return NhanVien_DAO.XoaNhanVien(dl);
        }
    }
}
