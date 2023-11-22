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
    public class NhanVien_DAO
    {
        static SqlConnection con;

        // Lấy danh sách tất cả nhân viên
        public static List<NhanVien_DTO> LayDSNhanVien()
        {
            string sTruyVan = "select * from nhanvien";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<NhanVien_DTO> lstNhanVien = new List<DTO.NhanVien_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVien_DTO nv = new NhanVien_DTO();
                nv.sMaNV = dt.Rows[i]["manv"].ToString();
                nv.sMaCV  = dt.Rows[i]["macv"].ToString();
                nv.sTenNV = dt.Rows[i]["tennv"].ToString();
                nv.sDiaChi = dt.Rows[i]["diachi"].ToString();
                nv.sSoDT = dt.Rows[i]["dienthoai"].ToString();
                lstNhanVien.Add(nv);
            }
            DataProvider.DongKetNoi(con);
            return lstNhanVien;
        }
        // Tìm ds nhân viên theo họ và tên, trả về null nếu không thấy
        public static List<NhanVien_DTO> TimNhanVienBangTuKhoa(string tukhoa)
        {
            string sTruyVan = string.Format(@"select * from nhanvien where tennv like N'%{0}%' or dienthoai like '%{1}%' or  macv like '%{2}%' or diachi like N'%{3}%'", tukhoa,tukhoa,tukhoa, tukhoa);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<NhanVien_DTO> lstNhanVien = new List<DTO.NhanVien_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVien_DTO nv = new NhanVien_DTO();
                nv.sMaNV = dt.Rows[i]["manv"].ToString();
                nv.sMaCV = dt.Rows[i]["macv"].ToString();
                nv.sTenNV = dt.Rows[i]["tennv"].ToString();
                nv.sDiaChi = dt.Rows[i]["diachi"].ToString();
                nv.sSoDT = dt.Rows[i]["dienthoai"].ToString();
                lstNhanVien.Add(nv);
            }
            DataProvider.DongKetNoi(con);
            return lstNhanVien;
        }
        
 
        
        // Lấy thông tin nhân viên có mã ma, trả về null nếu không thấy
        public static NhanVien_DTO TimNhanVienTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from nhanvien where manv=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.sMaNV = dt.Rows[0]["manv"].ToString();
            nv.sTenNV = dt.Rows[0]["tennv"].ToString();
            nv.sDiaChi = dt.Rows[0]["diachi"].ToString();
            nv.sSoDT = dt.Rows[0]["dienthoai"].ToString();
            

            DataProvider.DongKetNoi(con);
            return nv;
        }     

        // Thêm nhân viên
        public static bool ThemNhanVien(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"insert into nhanvien values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", nv.sMaNV, nv.sMaCV, nv.sTenNV, nv.sDiaChi, nv.sSoDT);
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

        // Sửa nhân viên
        public static bool SuaNhanVien(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"update nhanvien set tennv=N'{0}' ,diachi=N'{1}',dienthoai='{2}' , macv ='{3}' where manv='{4}'", nv.sTenNV, nv.sDiaChi, nv.sSoDT, nv.sMaCV, nv.sMaNV);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;

        }

        // Xóa nhân viên
        public static bool XoaNhanVien(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"delete from nhanvien where manv='{0}'", nv.sMaNV);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}

