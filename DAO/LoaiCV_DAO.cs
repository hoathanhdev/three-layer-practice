using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class LoaiCV_DAO
    {
        static SqlConnection con;
        public static List<LoaiCV_DTO> LayLoaiCV()
        {
            string sTruyVan = "select * from chucvu";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<LoaiCV_DTO> lstLoaiCV = new List<LoaiCV_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoaiCV_DTO lcv = new LoaiCV_DTO();
                lcv.sMaCV = dt.Rows[i]["macv"].ToString();
                lcv.sTenCV = dt.Rows[i]["tencv"].ToString();
                lstLoaiCV.Add(lcv);
            }
            DataProvider.DongKetNoi(con);
            return lstLoaiCV;
        }

        // lấy tên chức vụ theo mã
        public static string LayLoaiCVTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select tencv from chucvu where macv='{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                DataProvider.DongKetNoi(con);
                return null;
            }

            DataProvider.DongKetNoi(con);
            return dt.Rows[0]["tencv"].ToString();
        }
    }
}
