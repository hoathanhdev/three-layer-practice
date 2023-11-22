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
    public class LoaiSP_DAO
    {
        static SqlConnection con;
        public static List<LoaiSP_DTO> LayLoaiSP()
        {
            string sTruyVan = "select * from loaisanpham";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<LoaiSP_DTO> lstLoaiSP = new List<LoaiSP_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoaiSP_DTO lsp = new LoaiSP_DTO();
                lsp.sMaLoai = dt.Rows[i]["maloai"].ToString();
                lsp.sTenLoai = dt.Rows[i]["tenloai"].ToString();
                lstLoaiSP.Add(lsp);
            }
            DataProvider.DongKetNoi(con);
            return lstLoaiSP;
        }

        // lấy tên chức vụ theo mã
        public static string LayLoaiSPTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select tenloai from loaisanpham where maloai=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                DataProvider.DongKetNoi(con);
                return null;
            }

            DataProvider.DongKetNoi(con);
            return dt.Rows[0]["tenloai"].ToString();
        }
    }
}
