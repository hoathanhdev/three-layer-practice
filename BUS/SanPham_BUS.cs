using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class SanPham_BUS
    {
        public static List<SanPham_DTO> LayDSSanPham()
        {
            return SanPham_DAO.LayDSSanPham();
        }

        public static List<SanPham_DTO> TimSanPhamBangTuKhoa(string tukhoa)
        {
            return SanPham_DAO.TimSanPhamBangTuKhoa(tukhoa);
        }

        public static SanPham_DTO TimSanPhamTheoMa(string ma)
        {
            return SanPham_DAO.TimSanPhamTheoMa(ma);
        }

        public static bool ThemSanPham(SanPham_DTO dl)
        {
            return SanPham_DAO.ThemSanPham(dl);
        }

        public static bool SuaSanPham(SanPham_DTO dl)
        {
            return SanPham_DAO.SuaSanPham(dl);
        }

        public static bool XoaSanPham(SanPham_DTO dl)
        {
            return SanPham_DAO.XoaSanPham(dl);
        }
    }
}
