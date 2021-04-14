namespace inventary
{
    partial class buscar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnBorrarAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.chkTextExactly = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.infoProduct = new inventary.addProducts();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.bntBorrarBodega = new System.Windows.Forms.Button();
            this.toolTipSave = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipDelBodega = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipDelAll = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "Buscar:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(68, 32);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(152, 22);
            this.txtSearch.TabIndex = 22;
            this.txtSearch.Text = " ";
            this.txtSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(68, 155);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(152, 23);
            this.btnSearch.TabIndex = 33;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(107)))), ((int)(((byte)(53)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Image = global::inventary.Properties.Resources.save_as_32px;
            this.btnGuardar.Location = new System.Drawing.Point(26, 242);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(50, 50);
            this.btnGuardar.TabIndex = 35;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.button4_Click);
            this.btnGuardar.MouseHover += new System.EventHandler(this.btnGuardar_MouseHover);
            // 
            // btnBorrarAll
            // 
            this.btnBorrarAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBorrarAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarAll.Image = global::inventary.Properties.Resources.delete_bin_30px;
            this.btnBorrarAll.Location = new System.Drawing.Point(154, 242);
            this.btnBorrarAll.Name = "btnBorrarAll";
            this.btnBorrarAll.Size = new System.Drawing.Size(50, 50);
            this.btnBorrarAll.TabIndex = 35;
            this.btnBorrarAll.UseVisualStyleBackColor = false;
            this.btnBorrarAll.Click += new System.EventHandler(this.btnBorrar_Click);
            this.btnBorrarAll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnBorrarAll_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxFilter);
            this.groupBox1.Controls.Add(this.chkTextExactly);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 214);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar";
            // 
            // cbxFilter
            // 
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Location = new System.Drawing.Point(68, 67);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(152, 24);
            this.cbxFilter.TabIndex = 39;
            // 
            // chkTextExactly
            // 
            this.chkTextExactly.AutoSize = true;
            this.chkTextExactly.Location = new System.Drawing.Point(68, 108);
            this.chkTextExactly.Name = "chkTextExactly";
            this.chkTextExactly.Size = new System.Drawing.Size(111, 21);
            this.chkTextExactly.TabIndex = 38;
            this.chkTextExactly.Text = "Texto Exacto";
            this.chkTextExactly.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Filtro:";
            this.label10.Click += new System.EventHandler(this.label11_Click);
            // 
            // infoProduct
            // 
            this.infoProduct.Location = new System.Drawing.Point(362, 12);
            this.infoProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.infoProduct.Name = "infoProduct";
            this.infoProduct.Size = new System.Drawing.Size(549, 462);
            this.infoProduct.TabIndex = 39;
            // 
            // dataView
            // 
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(35, 499);
            this.dataView.Name = "dataView";
            this.dataView.RowTemplate.Height = 24;
            this.dataView.Size = new System.Drawing.Size(839, 150);
            this.dataView.TabIndex = 41;
            this.dataView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView_CellClick);
            // 
            // bntBorrarBodega
            // 
            this.bntBorrarBodega.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(138)))), ((int)(((byte)(7)))));
            this.bntBorrarBodega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntBorrarBodega.Image = global::inventary.Properties.Resources.delete_link_24px;
            this.bntBorrarBodega.Location = new System.Drawing.Point(90, 242);
            this.bntBorrarBodega.Name = "bntBorrarBodega";
            this.bntBorrarBodega.Size = new System.Drawing.Size(50, 50);
            this.bntBorrarBodega.TabIndex = 43;
            this.bntBorrarBodega.UseVisualStyleBackColor = false;
            this.bntBorrarBodega.Click += new System.EventHandler(this.bntBorrarBodega_Click);
            this.bntBorrarBodega.MouseHover += new System.EventHandler(this.bntBorrarBodega_MouseHover);
            // 
            // toolTipSave
            // 
            this.toolTipSave.Tag = "";
            this.toolTipSave.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // toolTipDelBodega
            // 
            this.toolTipDelBodega.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // buscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bntBorrarBodega);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.infoProduct);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBorrarAll);
            this.Controls.Add(this.btnGuardar);
            this.Name = "buscar";
            this.Size = new System.Drawing.Size(918, 684);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBorrarAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkTextExactly;
        private addProducts infoProduct;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button bntBorrarBodega;
        private System.Windows.Forms.ToolTip toolTipSave;
        private System.Windows.Forms.ToolTip toolTipDelBodega;
        private System.Windows.Forms.ToolTip toolTipDelAll;
    }
}
