namespace StajyerApp.WinForms
{
    partial class frmBirimListele
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
            this.gcBirimList = new DevExpress.XtraGrid.GridControl();
            this.gvBirimList = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gcBirimList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBirimList)).BeginInit();
            this.SuspendLayout();
            // 
            // gcBirimList
            // 
            this.gcBirimList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBirimList.Location = new System.Drawing.Point(0, 0);
            this.gcBirimList.MainView = this.gvBirimList;
            this.gcBirimList.Name = "gcBirimList";
            this.gcBirimList.Size = new System.Drawing.Size(625, 453);
            this.gcBirimList.TabIndex = 0;
            this.gcBirimList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBirimList});
            this.gcBirimList.Click += new System.EventHandler(this.gcBirimList_Click);
            // 
            // gvBirimList
            // 
            this.gvBirimList.GridControl = this.gcBirimList;
            this.gvBirimList.Name = "gvBirimList";
            this.gvBirimList.OptionsBehavior.Editable = false;
            this.gvBirimList.OptionsView.ShowGroupPanel = false;
            this.gvBirimList.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvBirimList_RowCellClick);
            this.gvBirimList.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvBirimList_RowStyle);
            this.gvBirimList.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvBirimList_ShowingEditor);
            // 
            // frmBirimListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 453);
            this.Controls.Add(this.gcBirimList);
            this.Name = "frmBirimListele";
            this.Text = "BirimListe";
            this.Load += new System.EventHandler(this.frmBirimListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcBirimList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBirimList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcBirimList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBirimList;
    }
}