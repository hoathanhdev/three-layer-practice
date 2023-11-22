using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class DaiLi_BUS
    {
        public static List<DaiLi_DTO> LayDSDaiLi()
        {
            return DaiLi_DAO.LayDSDaiLi();
        }

        public static List<DaiLi_DTO> TimDaiLiBangTuKhoa(string tukhoa)
        {
            return DaiLi_DAO.TimDaiLiBangTuKhoa(tukhoa);
        }

        public static DaiLi_DTO TimDaiLiTheoMa(string ma)
        {
            return DaiLi_DAO.TimDaiLiTheoMa(ma);
        }

        public static bool ThemDaiLi(DaiLi_DTO dl)
        {
            return DaiLi_DAO.ThemDaiLi(dl);
        }

        public static bool SuaDaiLi(DaiLi_DTO dl)
        {
            return DaiLi_DAO.SuaDaiLi(dl);
        }

        public static bool XoaDaiLi(DaiLi_DTO dl)
        {
            return DaiLi_DAO.XoaDaiLi(dl);
        }
    }
}
