using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DaiLi_DAO
    {
        static SqlConnection con;

        // Lấy danh sách tất cả nhân viên
        public static List<DaiLi_DTO> LayDSDaiLi()
        {
            string sTruyVan = "select * from thongtindaily";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DaiLi_DTO> lstDaiLi = new List<DaiLi_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DaiLi_DTO dl = new DaiLi_DTO();
                dl.sMaDL = dt.Rows[i]["madl"].ToString();
                dl.sTenDL = dt.Rows[i]["tendl"].ToString();
                dl.sDiaChi = dt.Rows[i]["diachi"].ToString();
                dl.sSoDT = dt.Rows[i]["dienthoai"].ToString();
                dl.sSoTienNo = float.Parse(dt.Rows[i]["sotienno"].ToString());
                lstDaiLi.Add(dl);
            }
            DataProvider.DongKetNoi(con);
            return lstDaiLi;
        }
        //-----------------------------------------


        // Tìm ds nhân viên theo họ và tên, trả về null nếu không thấy
        public static List<DaiLi_DTO> TimDaiLiBangTuKhoa(string tukhoa)
        {
            string sTruyVan = string.Format(@"select * from thongtindaily where tendl like N'%{0}%' or dienthoai like N'%{1}%' or diachi like N'%{2}%'", tukhoa, tukhoa, tukhoa);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<DaiLi_DTO> lstDaiLi = new List<DaiLi_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DaiLi_DTO dl = new DaiLi_DTO();
                dl.sMaDL = dt.Rows[i]["madl"].ToString();
                dl.sTenDL = dt.Rows[i]["tendl"].ToString();
                dl.sDiaChi = dt.Rows[i]["diachi"].ToString();
                dl.sSoDT = dt.Rows[i]["dienthoai"].ToString();
                dl.sSoTienNo = float.Parse(dt.Rows[i]["sotienno"].ToString());
                lstDaiLi.Add(dl);
            }
            DataProvider.DongKetNoi(con);
            return lstDaiLi;
        }
        //---------------------------------------------
       
        // Lấy thông tin nhân viên có mã ma, trả về null nếu không thấy
        public static DaiLi_DTO TimDaiLiTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from thongtindaily where madl = N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            DaiLi_DTO dl = new DaiLi_DTO();
            dl.sMaDL = dt.Rows[0]["madl"].ToString();
            dl.sTenDL = dt.Rows[0]["tendl"].ToString();
            dl.sDiaChi = dt.Rows[0]["diachi"].ToString();
            dl.sSoDT = dt.Rows[0]["dienthoai"].ToString();
            dl.sSoTienNo = float.Parse(dt.Rows[0]["sotienno"].ToString());

            DataProvider.DongKetNoi(con);
            return dl;
        }
        //------------------------------------------
       

        // Thêm đại lí
        public static bool ThemDaiLi(DaiLi_DTO dl)
        {
            string sTruyVan = string.Format(@"insert into thongtindaily values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", dl.sMaDL, dl.sTenDL, dl.sDiaChi, dl.sSoDT, dl.sSoTienNo);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
            //try
            //{
            //    DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            //    DataProvider.DongKetNoi(con);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    DataProvider.DongKetNoi(con);
            //    return false;
            //}

        }
        //---------------------------------------



        // Sửa đại lí
        public static bool SuaDaiLi(DaiLi_DTO dl)
        {
            string sTruyVan = string.Format(@"update thongtindaily set tendl=N'{0}',diachi=N'{1}',dienthoai='{2}', sotienno='{3}' where madl = '{4}'", dl.sTenDL, dl.sDiaChi, dl.sSoDT, dl.sSoTienNo, dl.sMaDL);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        //-----------------------------------------

        // Xóa đại lí
        public static bool XoaDaiLi(DaiLi_DTO dl)
        {
            string sTruyVan = string.Format(@"delete from thongtindaily where madl=N'{0}'",dl.sMaDL);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
