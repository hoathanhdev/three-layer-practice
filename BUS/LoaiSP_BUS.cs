using System;
using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class LoaiSP_BUS
    {
        public static List<LoaiSP_DTO> LayChucVu()
        {
            return LoaiSP_DAO.LayLoaiSP();
        }
        public static string LayTenChucVuTheoMa(string ma)
        {
            return LoaiSP_DAO.LayLoaiSPTheoMa(ma);
        }
    }
}
