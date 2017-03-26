using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsFormsApplication1
{
    class common
    {
        //đường dẫn tới folder ảnh trong debug
        private static string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Images\";

        //thêm cột hình ảnh
        public static void addimagecolumn(DataGridView dgv)
        {
            DataGridViewImageColumn ic = new DataGridViewImageColumn();
            ic.HeaderText = "Hình ảnh";
            ic.Image = null;
            ic.Name = "cImg";
            ic.Width = 100;
            dgv.Columns.Insert(0, ic);
            dgv.Columns[0].Visible = false;
        }

        //load lại cột hình ảnh(đã thêm cột hình ảnh) sau mọi lần tìm kiếm
        public static void loadimagecolumn(DataGridView dgv, string imagecolumnname)
        {
            dgv.Columns[0].Visible = true;
            dgv.Columns[imagecolumnname].Visible = false;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataGridViewImageCell cell = row.Cells[0] as DataGridViewImageCell;
                string path = "default-product-image.jpg";
                try
                {
                    path = row.Cells[imagecolumnname].Value.ToString();
                }
                catch (Exception)
                {
                }
                path = appPath + path;
                
                if(checkfiletontai(path))
                {
                    //dispose để ko bị lock xóa
                    using (var bmpTemp = new Bitmap(path))
                    {
                        cell.Value = new Bitmap(bmpTemp);
                    }
                    row.Height = 90;
                }
                else
                {
                    path = "default-product-image.jpg";
                    path = appPath + path;
                    using (var bmpTemp = new Bitmap(path))
                    {
                        cell.Value = new Bitmap(bmpTemp);
                    }
                    row.Height = 90;
                }
            }
        }

        //kiểm tra file tồn tại trước khi làm việc với nó
        public static bool checkfiletontai(string path)
        {
            FileInfo file = new FileInfo(path);
            if (file.Exists)
                return true;
            return false;
        }

        //báo lỗi khi bị lỗi add, update, delete
        public static void successorerror(bool b)
        {
            if (b)
                MessageBox.Show("Thành công");
            else
                MessageBox.Show("Lỗi");
        }

        public static void successorerror(int b)
        {
            if (b == 1)
                MessageBox.Show("Thành công");
            else
                if (b == 0)
                    MessageBox.Show("Lỗi");
                else if (b == -1)
                    MessageBox.Show("Bạn phải có quyền admin để xóa!");
        }


        //clear tất cả textbox, checkbox, radiobutton, picturebox
        public static void ClearTextBoxes(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }

                if (c.HasChildren)
                {
                    ClearTextBoxes(c);
                }

                if (c is CheckBox)
                {

                    ((CheckBox)c).Checked = false;
                }

                if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }

                if (c is PictureBox)
                    ((PictureBox)c).Image = null;
            }
        }
        public static void ClearOnlyTextBoxes(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.HasChildren)
                {
                    ClearOnlyTextBoxes(c);
                }

            }
        }

        //chỉnh lại kích thước ảnh
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        //copy vo clipboard
        public static void copyAlltoClipboard(DataGridView dgv)
        {
            //to remove the first blank column from datagridview
            dgv.RowHeadersVisible = false;
            dgv.SelectAll();
            DataObject dataObj = dgv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        public static void xuatexcel(DataGridView dgv)
        {
            copyAlltoClipboard(dgv);
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        //kt số nếu không phải return 0
        public static int ktint(string so)
        {
            int a = 0;
            if (int.TryParse(so, out a))
            {
                return a;
            }
            return 0;
        }
        public static decimal ktdecimal(string so)
        {
            decimal b = 0;
            if (decimal.TryParse(so, out b))
            {
                return b;
            }
            return 0;
        }
    }
}
