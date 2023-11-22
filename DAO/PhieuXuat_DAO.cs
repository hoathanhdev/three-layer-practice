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
    public class PhieuXuat_DAO
    {
        static SqlConnection con;

        // Lấy danh sách tất cả nhân viên
        public static List<PhieuXuat_DTO> LayDSPhieuXuat()
        {
            string sTruyVan = "select * from phieuxuat";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<PhieuXuat_DTO> lstPhieuNhap = new List<PhieuXuat_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhieuXuat_DTO pn = new PhieuXuat_DTO();
                pn.sMaPhieu = dt.Rows[i]["maphieux"].ToString();
                pn.sMaDL = dt.Rows[i]["madl"].ToString();
                pn.sDiaChi = dt.Rows[i]["diachi"].ToString();
                pn.sTenNgNhan = dt.Rows[i]["tennguoinhan"].ToString();
                pn.sNgayXuat = DateTime.Parse(dt.Rows[i]["ngayxuat"].ToString());
                pn.sMaNVLap = dt.Rows[i]["manvphieu"].ToString();
                pn.sMaNVTT = dt.Rows[i]["manvthutruong"].ToString();
                pn.sTongSoTien = float.Parse(dt.Rows[i]["tongsotien"].ToString());


                lstPhieuNhap.Add(pn);
            }
            DataProvider.DongKetNoi(con);
            return lstPhieuNhap;
        }
        // Tìm ds nhân viên theo họ và tên, trả về null nếu không thấy
        public static List<PhieuXuat_DTO> TimPhieuNhapBangTuKhoa(string tukhoa)
        {
            string sTruyVan = string.Format(@"select * from phieuxuat where diachi like N'%{0}%' or tennguoinhan like '%{1}%' or ngayxuat like '%{2}%'", tukhoa, tukhoa, tukhoa);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<PhieuXuat_DTO> lstPhieuNhap = new List<PhieuXuat_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhieuXuat_DTO pn = new PhieuXuat_DTO();
                pn.sMaPhieu = dt.Rows[i]["maphieux"].ToString();
                pn.sMaDL = dt.Rows[i]["madl"].ToString();
                pn.sDiaChi = dt.Rows[i]["diachi"].ToString();
                pn.sTenNgNhan = dt.Rows[i]["tennguoinhan"].ToString();
                pn.sNgayXuat = DateTime.Parse(dt.Rows[i]["ngayxuat"].ToString());
                pn.sMaNVLap = dt.Rows[i]["manvphieu"].ToString();
                pn.sMaNVTT = dt.Rows[i]["manvthutruong"].ToString();
                pn.sTongSoTien = float.Parse(dt.Rows[i]["tongsotien"].ToString());


                lstPhieuNhap.Add(pn);
            }
            DataProvider.DongKetNoi(con);
            return lstPhieuNhap;
        }


        // Lấy thông tin nhân viên có mã ma, trả về null nếu không thấy
        public static PhieuXuat_DTO TimPhieuXuatTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from phieuxuat where maphieux=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            PhieuXuat_DTO pn = new PhieuXuat_DTO();
            pn.sMaPhieu = dt.Rows[0]["maphieux"].ToString();
            pn.sMaDL = dt.Rows[0]["madl"].ToString();
            pn.sDiaChi = dt.Rows[0]["diachi"].ToString();
            pn.sTenNgNhan = dt.Rows[0]["tennguoinhan"].ToString();
            pn.sNgayXuat = DateTime.Parse(dt.Rows[0]["ngayxuat"].ToString());
            pn.sMaNVLap = dt.Rows[0]["manvphieu"].ToString();
            pn.sMaNVTT = dt.Rows[0]["manvthutruong"].ToString();
            pn.sTongSoTien = float.Parse(dt.Rows[0]["tongsotien"].ToString());


            DataProvider.DongKetNoi(con);
            return pn;
        }

       // Thêm nhân viên
        public static bool ThemPhieuXuat(PhieuXuat_DTO pn)
        {
            string sTruyVan = string.Format(@"insert into phieuxuat values(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}')", pn.sMaPhieu, pn.sMaDL, pn.sDiaChi, pn.sTenNgNhan, 
                pn.sNgayXuat, pn.sMaNVLap, pn.sMaNVTT, pn.sTongSoTien);
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
        public static bool SuaPhieuXuat(PhieuXuat_DTO nv)
        {
            string sTruyVan = string.Format(@"update phieuxuat set diachi=N'{0}',tennguoinhan=N'{1}',ngayxuat='{2}', 
tongsotien='{3}', madl='{4}', manvphieu='{5}', manvthutruong='{6}' where maphieux ='{7}' ", nv.sDiaChi, nv.sTenNgNhan, nv.sNgayXuat, nv.sTongSoTien, nv.sMaDL, nv.sMaNVLap,nv.sMaNVTT, nv.sMaPhieu);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;

        }

        // Xóa nhân viên
        public static bool XoaPhieuXuat(PhieuXuat_DTO nv)
        {
            string sTruyVan = string.Format(@"delete from phieuxuat where maphieux=N'{0}'", nv.sMaPhieu);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
