using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class TaiKhoan_DAO
    {
        static SqlConnection con;
        public static List<TaiKhoan_DTO> LayDSTaiKhoan()
        {
            string sTruyVan = "select * from taikhoan";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<TaiKhoan_DTO> lstDaiLi = new List<TaiKhoan_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoan_DTO dl = new TaiKhoan_DTO();
                dl.sMaTK = dt.Rows[i]["matk"].ToString();
                dl.sUserName = dt.Rows[i]["username"].ToString();
                dl.sMatKhau = dt.Rows[i]["password"].ToString();
                dl.sEmail = dt.Rows[i]["email"].ToString();
                 
                lstDaiLi.Add(dl);
            }
            DataProvider.DongKetNoi(con);
            return lstDaiLi;
        }
        //-----------------------------------------


        // Tìm ds nhân viên theo họ và tên, trả về null nếu không thấy
         
        //---------------------------------------------

        // Lấy thông tin nhân viên có mã ma, trả về null nếu không thấy
        public static TaiKhoan_DTO TimTaiKhoanTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from taikhoan where matk = N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            TaiKhoan_DTO dl = new TaiKhoan_DTO();
            dl.sMaTK = dt.Rows[0]["matk"].ToString();
            dl.sUserName = dt.Rows[0]["username"].ToString();
            dl.sMatKhau = dt.Rows[0]["password"].ToString();
            dl.sEmail = dt.Rows[0]["email"].ToString();
             

            DataProvider.DongKetNoi(con);
            return dl;
        }
        //------------------------------------------


        // Thêm đại lí
        public static bool ThemTaiKhoan(TaiKhoan_DTO dl)
        {
            string sTruyVan = string.Format(@"insert into taikhoan values(N'{0}',N'{1}',N'{2}',N'{3}')", dl.sMaTK, dl.sUserName, dl.sMatKhau, dl.sEmail);
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
        public static bool SuaTaiKhoan(TaiKhoan_DTO dl)
        {
            string sTruyVan = string.Format(@"update taikhoan set  username=N'{0}',password=N'{1}',email='{2}' where matk='{3}'", dl.sUserName, dl.sMatKhau, dl.sEmail, dl.sMaTK);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        //-----------------------------------------

        // Xóa đại lí
        public static bool XoaTaiKhoan(TaiKhoan_DTO dl)
        {
            string sTruyVan = string.Format(@"delete from taikhoan where matk=N'{0}'", dl.sMaTK);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
