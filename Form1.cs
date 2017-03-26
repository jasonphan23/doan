using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using DTO;
//using BUS;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using WindowsFormsApplication1.View;
using MetroFramework.Forms;
using System.Collections;
namespace WindowsFormsApplication1
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();



            pndangnhapuser.Controls.Add(lg);

            //add usercontrols
            tabquanlinhapkho.Controls.Add(dspn);
            tabquanlinhapkho.Controls.Add(dhv);
           
            tabkhthanthiet.Controls.Add(khv);


            tabthongketimkiem.Controls.Add(tkv);

            tabcauhinh.Controls.Add(spv);
            tabcauhinh.Controls.Add(nv);
            tabcauhinh.Controls.Add(nccv);

            dspn.Dock = DockStyle.Fill;
            nv.Dock = DockStyle.Fill;
            nccv.Dock = DockStyle.Fill;

            tkv.Dock = DockStyle.Fill;

            spv.Dock = DockStyle.Fill;

            dhv.Dock = DockStyle.Fill;

            add_dulieu_ao();

            tabthongke.SelectedIndex = 0;
        }

        login lg;

        nhacungcapview nccv = new nhacungcapview();
        danhsachphieunhaphangview dspn = new danhsachphieunhaphangview();

        dathangview dhv = new dathangview();

        nhanvienview nv = new nhanvienview();

        sanphamview spv = new sanphamview();
        khachhangview khv = new khachhangview();

        
        thongkeview tkv = new thongkeview();

        //private int madonnhap;

        //id của nhân viên đang đăng nhập
        public string manvdangnhap;
        #region dangnhap
        //đăng nhập
        private void button24_Click(object sender, EventArgs e)
        {
            //nhanvienbus bus = new nhanvienbus();
            //if (bus.dangnhap(lg.tendangnhap, lg.matkhau))
            //{
            //    currentuser.user = lg.tendangnhap;
            //    manvdangnhap = currentuser.user;
            //    tp.nvdangnhap = currentuser.user;
            //    xk.nvdangnhap = currentuser.user;

            //    if (bus.phanquyen(currentuser.user) == false)
            //    {
            //        tabthongke.TabPages.Remove(tabdanhsachnv);
            //        admin.phanquyen = false;
            //    }
            //    else admin.phanquyen = true;

            //tabthongke.SelectedTab = tabtrangchinh;
            //pndangnhapuser.Visible = false;
            //common.ClearOnlyTextBoxes(pndangnhapuser);
            //tabthongke.Visible = true;
            //    lg.Visible = false;
            //    chaolbl.Text = "Chào bạn vào giao diện chính";
            //    idnvlbl.Text = "ID nhân viên: " + manvdangnhap;
            //    tennvlbl.Text = "Tên nhân viên: " + bus.getname(manvdangnhap);
            //}
            //else
            //{
            //    MessageBox.Show("Sai ID hoặc mật khẩu");
            //}
        }

        #endregion

        #region menu

        //danh sách nhân viên
        private void btndanhsachnhanvien_Click(object sender, EventArgs e)
        {
          
        }

        //mở panel taodonnhap để tạo phiếu nhập hàng
        private void taodonnhapkho_Click(object sender, EventArgs e)
        {
            HidePanels(tabquanlinhapkho);
            dspn.Visible = true;
        }

        //mở panel danh sách phiếu nhập hàng
        private void suathongtindonnhap_Click(object sender, EventArgs e)
        {
            //HidePanels(tabquanlinhapkho);
            //dspn.Visible = true;
            //dspn.loadcombobox();
        }

        //mở panel để thêm sản phẩm
        private void themsanphambtn_Click(object sender, EventArgs e)
        {
            //lấy mã loại vào combobox nếu có thì mới mở panel sản phẩm
            //if (listmaloai())
            //{
            //    HidePanels(tabdanhsachsp);
            //    tsp.Visible = true;
            //    tsp.loadcombobox();
            //} 
        }

        //mở panel loại sản phẩm
        private void button21_Click(object sender, EventArgs e)
        {
           
        }

        //mở panel nhà cung cấp
        private void button20_Click(object sender, EventArgs e)
        {
            HidePanels(tabquanlinhapkho);
            nccv.Visible = true;
        }

        //mở panel danh sách sản phẩm
        private void danhsachvasuaspbtn_Click(object sender, EventArgs e)
        {

        }

        //mở panel xuất kho
        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        //mở panel danh sách tồn kho
        private void btndanhsachtonkho_Click(object sender, EventArgs e)
        {
      
        }
        //mở panel danh sách xuất kho
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        //nút back tất cả mọi thứ
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            switch (tabthongke.SelectedIndex)
            {
                case 0:
                    {
                    }
                    break;
                case 1:
                    {

                    }
                    break;
                case 2:
                    {
                        HidePanels(tabkhthanthiet);
                        pnkhachhangtt.Visible = true;
                    }
                    break;
                case 3:
                    {
                        HidePanels(tabquanlinhapkho);
                        qlnhapkho.Visible = true;
                    }
                    break;
                case 4:
                    {
                        HidePanels(tabquanlixuatkho);
                        qlxuatkho.Visible = true;
                    }
                    break;
                case 5:
                    {
                        //nhanvienbus bus = new nhanvienbus();
                        //if (bus.phanquyen(currentuser.user) == 
                        //    true)
                        //{
                        //    HidePanels(tabkhthanthiet);
                        //    pnkhachhangtt.Visible = true;
                        //}
                        HidePanels(tabthongketimkiem);
                        pnthongke.Visible = true;
                    }
                    break;

                case 6:
                    {
                        HidePanels(tabcauhinh);
                        panelcauhinh.Visible = true;
                    }
                    break;
            }
        }
        #endregion

        #region special function


        //ẩn hết panel
        private void HidePanels()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel)
                {
                    c.Visible = false;
                }
            }
        }

        //ẩn hết panel trong 1 panel
        //private void HidePanels(Panel pn)
        //{
        //    foreach (Control c in pn.Controls)
        //    {
        //        if (c is Panel)
        //        {
        //            c.Visible = false;
        //        }
        //    }
        //}

        private void HidePanels(TabPage tp)
        {
            foreach (Control c in tp.Controls)
            {
                if (c is UserControl)
                {
                    c.Visible = false;
                }
                if (c is Panel)
                {
                    c.Visible = false;
                }
            }
        }

        //lấy mã loại vào combobox
        //private bool listmaloai()
        //{
        //    loaibus bus = new loaibus();
        //    //nếu có loại sản phẩm
        //    if (bus.any())
        //        return true;
        //    //nếu không có thì hỏi có nhập không
        //    else
        //    {
        //        DialogResult dialogResult = MessageBox.Show("Bạn chưa nhập các loại sản phẩm mà bạn sẽ bán (VD: Nước ngọt, Snack,...)" + "\n" + "Vào thêm loại sản phẩm mới?", "Chưa nhập loại sản phẩm", MessageBoxButtons.YesNo);
        //        if (dialogResult == DialogResult.Yes)
        //        {
        //            button21.PerformClick();

        //        }
        //        else if (dialogResult == DialogResult.No)
        //        {
        //            //tabControl1.SelectedTab = tabPage1;
        //        }
        //        return false;
        //    }
        //}

        //load mã nhà cung cấp vào combobox
        //private bool listnhacungcap()
        //{
        //    nhacungcapbus bus = new nhacungcapbus();
        //    if (bus.any())
        //    {
        //        return true;
        //    }
        //    //nếu không có thì hỏi có nhập không
        //    else
        //    {
        //        DialogResult dialogResult = MessageBox.Show("Bạn chưa có nhà cung cấp" + "\n" + "Vào thêm nhà cung cấp mới?", "Chưa có nhà cung cấp", MessageBoxButtons.YesNo);
        //        if (dialogResult == DialogResult.Yes)
        //        {
        //            button20.PerformClick();
        //        }
        //        else if (dialogResult == DialogResult.No)
        //        {
        //            //tabControl1.SelectedTab = tabPage1;
        //        }
        //        return false;
        //    }

        //}

        #endregion

        public string madnvangnhap { get; set; }

        private void logout_Click(object sender, EventArgs e)
        {
            currentuser.user = "";
            tabthongke.Visible = false;
            pndangnhapuser.Visible = true;
            lg.Visible = true;
        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                txt_tongtiensaugiam.Text = (Int32.Parse(txt_tongtien.Text) - 100000).ToString();
            }
            else
            {
                txt_tongtiensaugiam.Text = txt_tongtien.Text;
            }
        }

        public void add_dulieu_ao()
        {

            cthdgv.ColumnCount = 4;
            // REAL INDEX
            cthdgv.Columns[0].Name = "Mã SP";
            cthdgv.Columns[1].Name = "Tên SP";
            cthdgv.Columns[2].Name = "Đơn giá";
            cthdgv.Columns[3].Name = "Tổng";

            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "SL";
            combo.Name = "combo";
            ArrayList num = new ArrayList();
            num.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            combo.Items.AddRange(num.ToArray());
            cthdgv.Columns.Add(combo); // MAC DINH INDEX = 4 . 
            combo.DisplayIndex = 2; // DAY CHI LA DISPLAY INDEX, KHONG PHAI LA INDEX THAT. INDEX THAT CO SO LUONG LA 4.


            cthdgv.Rows.Add("56", "Kitkat hộp lớn", "50000", "50000", "1");
            cthdgv.Rows.Add("32", "KẸO SỮA KANRO CAO CẤP", "50000", "50000", "1");

            DataTable dt_sp = new DataTable();
            dt_sp.Columns.Add("Mã SP", typeof(int));
            dt_sp.Columns.Add("Tên SP", typeof(string));
            dt_sp.Columns.Add("Đơn giá", typeof(int));

            dt_sp.Rows.Add(17, "Rượu Sake", 1500000);
            dt_sp.Rows.Add(30, "BÁNH HELLO PANDA SOCOLA ", 50000);
            dt_sp.Rows.Add(31, "KẸO HAICHU VỊ TÁO XANH 12 VIÊN", 50000);
            dt_sp.Rows.Add(32, "KẸO SỮA KANRO CAO CẤP", 50000);
            dt_sp.Rows.Add(56, "Kitkat hợp lớn", 50000);
            dsspgv.DataSource = dt_sp;


        }

        private void button26_Click(object sender, EventArgs e)
        {
            HidePanels(tabkhthanthiet);
            khv.Visible = true;
            khv.tabControl5.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HidePanels(tabkhthanthiet);
            khv.Visible = true;
            khv.tabControl5.SelectedIndex = 0;
        }

        private void taodonnhapkho_Click_1(object sender, EventArgs e)
        {

            HidePanels(tabquanlinhapkho);
            dspn.Visible = true;
            dspn.tabControl4.SelectedIndex = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HidePanels(tabquanlinhapkho);
            dhv.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HidePanels(tabcauhinh);
            nv.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HidePanels(tabcauhinh);
            nccv.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HidePanels(tabcauhinh);
            spv.Visible = true;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            HidePanels(tabthongketimkiem);
            tkv.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            HidePanels(tabthongketimkiem);
            tkv.Visible = true;
        }
    }
}