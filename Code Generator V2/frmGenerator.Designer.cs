namespace Code_Generator_V2
{
    partial class frmGenerator
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
            this.components = new System.ComponentModel.Container();
            this.cbServer = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnConnection = new System.Windows.Forms.Button();
            this.flyDataBaseTables = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefreshTable = new System.Windows.Forms.Button();
            this.rtxCode = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBusinessLayer = new System.Windows.Forms.Button();
            this.btnPresentationLayer = new System.Windows.Forms.Button();
            this.pnlLowMain = new System.Windows.Forms.Panel();
            this.btnCreateDataGridView = new System.Windows.Forms.Button();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateCmb = new System.Windows.Forms.Button();
            this.btnCreateTools = new System.Windows.Forms.Button();
            this.pnlTableColumns = new System.Windows.Forms.Panel();
            this.dgvTableColumns = new System.Windows.Forms.DataGridView();
            this.btnDataAcessLayer = new System.Windows.Forms.Button();
            this.btnSqlQuery = new System.Windows.Forms.Button();
            this.btnDesignerLayer = new System.Windows.Forms.Button();
            this.btnNewConnection = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlLowMain.SuspendLayout();
            this.pnlTableColumns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // cbServer
            // 
            this.cbServer.BackColor = System.Drawing.Color.Silver;
            this.cbServer.Enabled = false;
            this.cbServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbServer.FormattingEnabled = true;
            this.cbServer.Items.AddRange(new object[] {
            "Microsoft Sql Server",
            "Oracle",
            "MySQL"});
            this.cbServer.Location = new System.Drawing.Point(9, 6);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(166, 26);
            this.cbServer.TabIndex = 1;
            this.cbServer.Text = "Microsoft Sql Server";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnConnection);
            this.panel1.Controls.Add(this.flyDataBaseTables);
            this.panel1.Location = new System.Drawing.Point(5, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 259);
            this.panel1.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(232, 214);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 35);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(232, 174);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 35);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "All Tables In DataBase (MemoryDB)";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Gainsboro;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(232, 133);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(82, 35);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.Gainsboro;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(232, 92);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(82, 35);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(232, 51);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(82, 35);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnConnection
            // 
            this.btnConnection.BackColor = System.Drawing.Color.Gainsboro;
            this.btnConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnection.Location = new System.Drawing.Point(232, 10);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(82, 35);
            this.btnConnection.TabIndex = 1;
            this.btnConnection.Text = "Connection";
            this.btnConnection.UseVisualStyleBackColor = false;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // flyDataBaseTables
            // 
            this.flyDataBaseTables.AutoScroll = true;
            this.flyDataBaseTables.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flyDataBaseTables.Location = new System.Drawing.Point(5, 31);
            this.flyDataBaseTables.Name = "flyDataBaseTables";
            this.flyDataBaseTables.Size = new System.Drawing.Size(220, 214);
            this.flyDataBaseTables.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnNewConnection);
            this.panel2.Controls.Add(this.btnRefreshTable);
            this.panel2.Controls.Add(this.cbServer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1080, 43);
            this.panel2.TabIndex = 3;
            // 
            // btnRefreshTable
            // 
            this.btnRefreshTable.BackColor = System.Drawing.Color.Silver;
            this.btnRefreshTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshTable.Location = new System.Drawing.Point(339, 4);
            this.btnRefreshTable.Name = "btnRefreshTable";
            this.btnRefreshTable.Size = new System.Drawing.Size(130, 29);
            this.btnRefreshTable.TabIndex = 2;
            this.btnRefreshTable.Text = "Refresh Tables";
            this.btnRefreshTable.UseVisualStyleBackColor = false;
            this.btnRefreshTable.Click += new System.EventHandler(this.btnRefreshTable_Click);
            // 
            // rtxCode
            // 
            this.rtxCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxCode.BackColor = System.Drawing.Color.LightSteelBlue;
            this.rtxCode.ContextMenuStrip = this.contextMenuStrip1;
            this.rtxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxCode.Location = new System.Drawing.Point(360, 74);
            this.rtxCode.Name = "rtxCode";
            this.rtxCode.Size = new System.Drawing.Size(705, 259);
            this.rtxCode.TabIndex = 5;
            this.rtxCode.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 70);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "Cut";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // btnBusinessLayer
            // 
            this.btnBusinessLayer.BackColor = System.Drawing.Color.Silver;
            this.btnBusinessLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusinessLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusinessLayer.Location = new System.Drawing.Point(631, 47);
            this.btnBusinessLayer.Name = "btnBusinessLayer";
            this.btnBusinessLayer.Size = new System.Drawing.Size(111, 23);
            this.btnBusinessLayer.TabIndex = 2;
            this.btnBusinessLayer.Text = "Business Layer";
            this.btnBusinessLayer.UseVisualStyleBackColor = false;
            this.btnBusinessLayer.Click += new System.EventHandler(this.btnBusinessLayer_Click);
            // 
            // btnPresentationLayer
            // 
            this.btnPresentationLayer.BackColor = System.Drawing.Color.Silver;
            this.btnPresentationLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresentationLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresentationLayer.Location = new System.Drawing.Point(497, 47);
            this.btnPresentationLayer.Name = "btnPresentationLayer";
            this.btnPresentationLayer.Size = new System.Drawing.Size(111, 23);
            this.btnPresentationLayer.TabIndex = 6;
            this.btnPresentationLayer.Text = "Presentation Layer";
            this.btnPresentationLayer.UseVisualStyleBackColor = false;
            this.btnPresentationLayer.Click += new System.EventHandler(this.btnPresentationLayer_Click);
            // 
            // pnlLowMain
            // 
            this.pnlLowMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLowMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLowMain.Controls.Add(this.btnCreateDataGridView);
            this.pnlLowMain.Controls.Add(this.cbSelectAll);
            this.pnlLowMain.Controls.Add(this.label2);
            this.pnlLowMain.Controls.Add(this.btnCreateCmb);
            this.pnlLowMain.Controls.Add(this.btnCreateTools);
            this.pnlLowMain.Controls.Add(this.pnlTableColumns);
            this.pnlLowMain.Location = new System.Drawing.Point(5, 339);
            this.pnlLowMain.Name = "pnlLowMain";
            this.pnlLowMain.Size = new System.Drawing.Size(1061, 318);
            this.pnlLowMain.TabIndex = 7;
            // 
            // btnCreateDataGridView
            // 
            this.btnCreateDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateDataGridView.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCreateDataGridView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateDataGridView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateDataGridView.Location = new System.Drawing.Point(765, 101);
            this.btnCreateDataGridView.Name = "btnCreateDataGridView";
            this.btnCreateDataGridView.Size = new System.Drawing.Size(133, 37);
            this.btnCreateDataGridView.TabIndex = 9;
            this.btnCreateDataGridView.Text = "Create DataGridView";
            this.btnCreateDataGridView.UseVisualStyleBackColor = false;
            this.btnCreateDataGridView.Click += new System.EventHandler(this.btnCreateDataGridView_Click);
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectAll.ForeColor = System.Drawing.Color.Crimson;
            this.cbSelectAll.Location = new System.Drawing.Point(384, 12);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(87, 22);
            this.cbSelectAll.TabIndex = 8;
            this.cbSelectAll.Text = "Select All";
            this.cbSelectAll.UseVisualStyleBackColor = true;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "All Columns in Table";
            // 
            // btnCreateCmb
            // 
            this.btnCreateCmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCmb.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCreateCmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateCmb.Location = new System.Drawing.Point(765, 48);
            this.btnCreateCmb.Name = "btnCreateCmb";
            this.btnCreateCmb.Size = new System.Drawing.Size(133, 37);
            this.btnCreateCmb.TabIndex = 3;
            this.btnCreateCmb.Text = "Fill Combobox";
            this.btnCreateCmb.UseVisualStyleBackColor = false;
            this.btnCreateCmb.Click += new System.EventHandler(this.btnCreateCmb_Click);
            // 
            // btnCreateTools
            // 
            this.btnCreateTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateTools.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCreateTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateTools.Location = new System.Drawing.Point(909, 48);
            this.btnCreateTools.Name = "btnCreateTools";
            this.btnCreateTools.Size = new System.Drawing.Size(133, 37);
            this.btnCreateTools.TabIndex = 2;
            this.btnCreateTools.Text = "Create Tools";
            this.btnCreateTools.UseVisualStyleBackColor = false;
            this.btnCreateTools.Click += new System.EventHandler(this.btnCreateTools_Click);
            // 
            // pnlTableColumns
            // 
            this.pnlTableColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTableColumns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTableColumns.Controls.Add(this.dgvTableColumns);
            this.pnlTableColumns.Location = new System.Drawing.Point(6, 42);
            this.pnlTableColumns.Name = "pnlTableColumns";
            this.pnlTableColumns.Size = new System.Drawing.Size(749, 264);
            this.pnlTableColumns.TabIndex = 0;
            // 
            // dgvTableColumns
            // 
            this.dgvTableColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTableColumns.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgvTableColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableColumns.Location = new System.Drawing.Point(2, 5);
            this.dgvTableColumns.Name = "dgvTableColumns";
            this.dgvTableColumns.RowHeadersWidth = 10;
            this.dgvTableColumns.Size = new System.Drawing.Size(741, 254);
            this.dgvTableColumns.TabIndex = 0;
            // 
            // btnDataAcessLayer
            // 
            this.btnDataAcessLayer.BackColor = System.Drawing.Color.Silver;
            this.btnDataAcessLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataAcessLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataAcessLayer.Location = new System.Drawing.Point(765, 47);
            this.btnDataAcessLayer.Name = "btnDataAcessLayer";
            this.btnDataAcessLayer.Size = new System.Drawing.Size(111, 23);
            this.btnDataAcessLayer.TabIndex = 8;
            this.btnDataAcessLayer.Text = "Data Access Layer";
            this.btnDataAcessLayer.UseVisualStyleBackColor = false;
            this.btnDataAcessLayer.Click += new System.EventHandler(this.btnDataAcessLayer_Click);
            // 
            // btnSqlQuery
            // 
            this.btnSqlQuery.BackColor = System.Drawing.Color.Silver;
            this.btnSqlQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSqlQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSqlQuery.Location = new System.Drawing.Point(895, 47);
            this.btnSqlQuery.Name = "btnSqlQuery";
            this.btnSqlQuery.Size = new System.Drawing.Size(111, 23);
            this.btnSqlQuery.TabIndex = 9;
            this.btnSqlQuery.Text = "Sql Query";
            this.btnSqlQuery.UseVisualStyleBackColor = false;
            this.btnSqlQuery.Click += new System.EventHandler(this.btnSqlQuery_Click);
            // 
            // btnDesignerLayer
            // 
            this.btnDesignerLayer.BackColor = System.Drawing.Color.Silver;
            this.btnDesignerLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesignerLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesignerLayer.Location = new System.Drawing.Point(363, 47);
            this.btnDesignerLayer.Name = "btnDesignerLayer";
            this.btnDesignerLayer.Size = new System.Drawing.Size(111, 23);
            this.btnDesignerLayer.TabIndex = 10;
            this.btnDesignerLayer.Text = "Designer Layer";
            this.btnDesignerLayer.UseVisualStyleBackColor = false;
            this.btnDesignerLayer.Click += new System.EventHandler(this.btnDesignerLayer_Click);
            // 
            // btnNewConnection
            // 
            this.btnNewConnection.BackColor = System.Drawing.Color.Silver;
            this.btnNewConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewConnection.Location = new System.Drawing.Point(187, 4);
            this.btnNewConnection.Name = "btnNewConnection";
            this.btnNewConnection.Size = new System.Drawing.Size(130, 29);
            this.btnNewConnection.TabIndex = 3;
            this.btnNewConnection.Text = "New Connection";
            this.btnNewConnection.UseVisualStyleBackColor = false;
            this.btnNewConnection.Click += new System.EventHandler(this.btnNewConnection_Click_1);
            // 
            // frmGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1080, 664);
            this.Controls.Add(this.btnDesignerLayer);
            this.Controls.Add(this.btnSqlQuery);
            this.Controls.Add(this.btnDataAcessLayer);
            this.Controls.Add(this.pnlLowMain);
            this.Controls.Add(this.btnPresentationLayer);
            this.Controls.Add(this.btnBusinessLayer);
            this.Controls.Add(this.rtxCode);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGenerator";
            this.Text = "frmGenerator";
            this.Load += new System.EventHandler(this.frmGenerator_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlLowMain.ResumeLayout(false);
            this.pnlLowMain.PerformLayout();
            this.pnlTableColumns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbServer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flyDataBaseTables;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rtxCode;
        private System.Windows.Forms.Button btnBusinessLayer;
        private System.Windows.Forms.Button btnPresentationLayer;
        private System.Windows.Forms.Panel pnlLowMain;
        private System.Windows.Forms.Panel pnlTableColumns;
        private System.Windows.Forms.Button btnCreateCmb;
        private System.Windows.Forms.Button btnCreateTools;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTableColumns;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.Button btnDataAcessLayer;
        private System.Windows.Forms.Button btnSqlQuery;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDesignerLayer;
        private System.Windows.Forms.CheckBox cbSelectAll;
        private System.Windows.Forms.Button btnRefreshTable;
        private System.Windows.Forms.Button btnCreateDataGridView;
        private System.Windows.Forms.Button btnNewConnection;
    }
}