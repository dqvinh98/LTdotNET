namespace QL_DaySauDaiHoc
{
    partial class frmDonVi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDonVi));
            this.lblDonVi = new System.Windows.Forms.Label();
            this.lblTenDonVi = new System.Windows.Forms.Label();
            this.lblMaDonVi = new System.Windows.Forms.Label();
            this.lblMaTruong = new System.Windows.Forms.Label();
            this.txtMaDonVi = new System.Windows.Forms.TextBox();
            this.dgvDonVi = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnChinhSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnKhongLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.txtTenDonVi = new System.Windows.Forms.TextBox();
            this.cboMaTruong = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonVi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDonVi
            // 
            this.lblDonVi.AutoSize = true;
            this.lblDonVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDonVi.Location = new System.Drawing.Point(244, 36);
            this.lblDonVi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(252, 25);
            this.lblDonVi.TabIndex = 0;
            this.lblDonVi.Text = "DANH SÁCH CÁC ĐƠN VỊ";
            // 
            // lblTenDonVi
            // 
            this.lblTenDonVi.AutoSize = true;
            this.lblTenDonVi.Location = new System.Drawing.Point(52, 134);
            this.lblTenDonVi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenDonVi.Name = "lblTenDonVi";
            this.lblTenDonVi.Size = new System.Drawing.Size(97, 20);
            this.lblTenDonVi.TabIndex = 1;
            this.lblTenDonVi.Text = "Tên Đơn Vị:";
            // 
            // lblMaDonVi
            // 
            this.lblMaDonVi.AutoSize = true;
            this.lblMaDonVi.Location = new System.Drawing.Point(52, 85);
            this.lblMaDonVi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaDonVi.Name = "lblMaDonVi";
            this.lblMaDonVi.Size = new System.Drawing.Size(92, 20);
            this.lblMaDonVi.TabIndex = 2;
            this.lblMaDonVi.Text = "Mã Đơn Vị:";
            // 
            // lblMaTruong
            // 
            this.lblMaTruong.AutoSize = true;
            this.lblMaTruong.Location = new System.Drawing.Point(52, 182);
            this.lblMaTruong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaTruong.Name = "lblMaTruong";
            this.lblMaTruong.Size = new System.Drawing.Size(94, 20);
            this.lblMaTruong.TabIndex = 3;
            this.lblMaTruong.Text = "Mã Trường:";
            // 
            // txtMaDonVi
            // 
            this.txtMaDonVi.Location = new System.Drawing.Point(166, 82);
            this.txtMaDonVi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtMaDonVi.Name = "txtMaDonVi";
            this.txtMaDonVi.Size = new System.Drawing.Size(440, 27);
            this.txtMaDonVi.TabIndex = 5;
            // 
            // dgvDonVi
            // 
            this.dgvDonVi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonVi.Location = new System.Drawing.Point(166, 240);
            this.dgvDonVi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvDonVi.Name = "dgvDonVi";
            this.dgvDonVi.Size = new System.Drawing.Size(397, 189);
            this.dgvDonVi.TabIndex = 7;
            this.dgvDonVi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonVi_CellClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(122, 456);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 34);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnChinhSua
            // 
            this.btnChinhSua.Location = new System.Drawing.Point(250, 455);
            this.btnChinhSua.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnChinhSua.Name = "btnChinhSua";
            this.btnChinhSua.Size = new System.Drawing.Size(110, 35);
            this.btnChinhSua.TabIndex = 9;
            this.btnChinhSua.Text = "Chỉnh sửa";
            this.btnChinhSua.UseVisualStyleBackColor = true;
            this.btnChinhSua.Click += new System.EventHandler(this.btnChinhSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(250, 504);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(110, 34);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnKhongLuu
            // 
            this.btnKhongLuu.Location = new System.Drawing.Point(380, 504);
            this.btnKhongLuu.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnKhongLuu.Name = "btnKhongLuu";
            this.btnKhongLuu.Size = new System.Drawing.Size(110, 35);
            this.btnKhongLuu.TabIndex = 11;
            this.btnKhongLuu.Text = "Không lưu";
            this.btnKhongLuu.UseVisualStyleBackColor = true;
            this.btnKhongLuu.Click += new System.EventHandler(this.btnKhongLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(380, 457);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 34);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(509, 456);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 34);
            this.btnDong.TabIndex = 13;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // txtTenDonVi
            // 
            this.txtTenDonVi.Location = new System.Drawing.Point(166, 131);
            this.txtTenDonVi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTenDonVi.Name = "txtTenDonVi";
            this.txtTenDonVi.Size = new System.Drawing.Size(440, 27);
            this.txtTenDonVi.TabIndex = 14;
            // 
            // cboMaTruong
            // 
            this.cboMaTruong.FormattingEnabled = true;
            this.cboMaTruong.Location = new System.Drawing.Point(166, 179);
            this.cboMaTruong.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cboMaTruong.Name = "cboMaTruong";
            this.cboMaTruong.Size = new System.Drawing.Size(440, 28);
            this.cboMaTruong.TabIndex = 16;

            // 
            // frmDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(742, 562);
            this.Controls.Add(this.cboMaTruong);
            this.Controls.Add(this.txtTenDonVi);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnKhongLuu);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnChinhSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvDonVi);
            this.Controls.Add(this.txtMaDonVi);
            this.Controls.Add(this.lblMaTruong);
            this.Controls.Add(this.lblMaDonVi);
            this.Controls.Add(this.lblTenDonVi);
            this.Controls.Add(this.lblDonVi);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmDonVi";
            this.Text = "Đơn Vị";
            this.Load += new System.EventHandler(this.frmDonVi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonVi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDonVi;
        private System.Windows.Forms.Label lblTenDonVi;
        private System.Windows.Forms.Label lblMaDonVi;
        private System.Windows.Forms.Label lblMaTruong;
        private System.Windows.Forms.TextBox txtMaDonVi;
        private System.Windows.Forms.DataGridView dgvDonVi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnChinhSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnKhongLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TextBox txtTenDonVi;
        private System.Windows.Forms.ComboBox cboMaTruong;
    }
}