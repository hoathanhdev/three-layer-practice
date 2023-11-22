using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class LoaiCV_BUS
    {
        public static List<LoaiCV_DTO> LayChucVu()
        {
            return LoaiCV_DAO.LayLoaiCV();
        }
        public static string LayTenChucVuTheoMa(string ma)
        {
            return LoaiCV_DAO.LayLoaiCVTheoMa(ma);
        }
    }
}
