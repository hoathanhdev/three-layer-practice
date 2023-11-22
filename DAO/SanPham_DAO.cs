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
    public class SanPham_DAO
    {
        static SqlConnection con;

        // Lấy danh sách tất cả nhân viên
        public static List<SanPham_DTO> LayDSSanPham()
        {
            string sTruyVan = "select * from thongtinsanpham";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<SanPham_DTO> lstNhanVien = new List<SanPham_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SanPham_DTO nv = new SanPham_DTO();
                nv.sMaSP = dt.Rows[i]["masp"].ToString();
                nv.sTenSP = dt.Rows[i]["tensp"].ToString();
                nv.sMaloai = dt.Rows[i]["loaisp"].ToString();
                nv.sSoLuongCo = Int32.Parse(dt.Rows[i]["soluongco"].ToString());
                nv.sDonGia= float.Parse(dt.Rows[i]["dongia"].ToString());
                lstNhanVien.Add(nv);
            }
            DataProvider.DongKetNoi(con);
            return lstNhanVien;
        }
        // Tìm ds nhân viên theo họ và tên, trả về null nếu không thấy
        public static List<SanPham_DTO> TimSanPhamBangTuKhoa(string tukhoa)
        {
            string sTruyVan = string.Format(@"select * from thongtinsanpham where tensp like N'%{0}%' or loaisp like N'%{1}%'", tukhoa, tukhoa);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<SanPham_DTO> lstNhanVien = new List<SanPham_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SanPham_DTO nv = new SanPham_DTO();
                nv.sMaSP = dt.Rows[i]["masp"].ToString();
                nv.sTenSP = dt.Rows[i]["tensp"].ToString();
                nv.sMaloai = dt.Rows[i]["loaisp"].ToString();
                nv.sSoLuongCo = Int32.Parse(dt.Rows[i]["soluongco"].ToString());
                nv.sDonGia = float.Parse(dt.Rows[i]["dongia"].ToString());
                lstNhanVien.Add(nv);
            }
            DataProvider.DongKetNoi(con);
            return lstNhanVien;
        }



        // Lấy thông tin nhân viên có mã ma, trả về null nếu không thấy
        public static SanPham_DTO TimSanPhamTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from thongtinsanpham where masp =N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            SanPham_DTO nv = new SanPham_DTO();
            nv.sMaSP = dt.Rows[0]["masp"].ToString();
            nv.sTenSP = dt.Rows[0]["tensp"].ToString();
            nv.sMaloai = dt.Rows[0]["loaisp"].ToString();
            nv.sSoLuongCo = Int32.Parse(dt.Rows[0]["soluongco"].ToString());
            nv.sDonGia = float.Parse(dt.Rows[0]["dongia"].ToString());


            DataProvider.DongKetNoi(con);
            return nv;
        }
        // Lấy danh sách các nhân viên có mã chức vụ ma
        

        // Thêm nhân viên
        public static bool ThemSanPham(SanPham_DTO nv)
        {
            string sTruyVan = string.Format(@"insert into thongtinsanpham values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", nv.sMaSP, nv.sTenSP, nv.sMaloai, nv.sSoLuongCo, nv.sDonGia);
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
        public static bool SuaSanPham(SanPham_DTO nv)
        {
            string sTruyVan = string.Format(@"update thongtinsanpham set tensp=N'{0}',soluongco=N'{1}',dongia='{2}', loaisp='{3}' where masp='{4}'", nv.sTenSP, nv.sSoLuongCo, nv.sDonGia, nv.sMaloai, nv.sMaSP);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;

        }

        // Xóa nhân viên
        public static bool XoaSanPham(SanPham_DTO nv)
        {
            string sTruyVan = string.Format(@"delete from thongtinsanpham where masp=N'{0}'", nv.sMaSP);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}


