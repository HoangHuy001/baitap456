using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace baitap456
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Form2 frmNhanVien = new Form2();
            if (frmNhanVien.ShowDialog() == DialogResult.OK)
            {
                // Add a new row to the DataGridView
                dataGridView1.Rows.Add(frmNhanVien.MSNV, frmNhanVien.TenNV, frmNhanVien.LuongCoBan.ToString("N2"));
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                Form2 frmNhanVien = new Form2
                {
                    MSNV = selectedRow.Cells[0].Value.ToString(),
                    TenNV = selectedRow.Cells[1].Value.ToString(),
                    LuongCoBan = Convert.ToDecimal(selectedRow.Cells[2].Value)
                };

                if (frmNhanVien.ShowDialog() == DialogResult.OK)
                {
                    // Update the selected row with new data
                    selectedRow.Cells[0].Value = frmNhanVien.MSNV;
                    selectedRow.Cells[1].Value = frmNhanVien.TenNV;
                    selectedRow.Cells[2].Value = frmNhanVien.LuongCoBan.ToString("N2");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Remove selected rows from the DataGridView
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (!row.IsNewRow) // Ensure not to delete the "New Row"
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the current form
        }
    }
}
