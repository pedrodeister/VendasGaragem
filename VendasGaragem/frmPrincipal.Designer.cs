namespace VendasGaragem
{
    partial class frmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastroBásicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.corToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarVendedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acompanharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasPeríodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasVendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroBásicoToolStripMenuItem,
            this.vendedorToolStripMenuItem,
            this.veículoToolStripMenuItem,
            this.acompanharToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1363, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastroBásicoToolStripMenuItem
            // 
            this.cadastroBásicoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.corToolStripMenuItem,
            this.marcaToolStripMenuItem,
            this.modeloToolStripMenuItem});
            this.cadastroBásicoToolStripMenuItem.Name = "cadastroBásicoToolStripMenuItem";
            this.cadastroBásicoToolStripMenuItem.Size = new System.Drawing.Size(163, 32);
            this.cadastroBásicoToolStripMenuItem.Text = "Cadastro básico";
            // 
            // corToolStripMenuItem
            // 
            this.corToolStripMenuItem.Name = "corToolStripMenuItem";
            this.corToolStripMenuItem.Size = new System.Drawing.Size(180, 32);
            this.corToolStripMenuItem.Text = "Cor";
            this.corToolStripMenuItem.Click += new System.EventHandler(this.corToolStripMenuItem_Click);
            // 
            // marcaToolStripMenuItem
            // 
            this.marcaToolStripMenuItem.Name = "marcaToolStripMenuItem";
            this.marcaToolStripMenuItem.Size = new System.Drawing.Size(180, 32);
            this.marcaToolStripMenuItem.Text = "Marca";
            this.marcaToolStripMenuItem.Click += new System.EventHandler(this.marcaToolStripMenuItem_Click);
            // 
            // modeloToolStripMenuItem
            // 
            this.modeloToolStripMenuItem.Name = "modeloToolStripMenuItem";
            this.modeloToolStripMenuItem.Size = new System.Drawing.Size(180, 32);
            this.modeloToolStripMenuItem.Text = "Modelo";
            this.modeloToolStripMenuItem.Click += new System.EventHandler(this.modeloToolStripMenuItem_Click);
            // 
            // vendedorToolStripMenuItem
            // 
            this.vendedorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerenciarVendedoresToolStripMenuItem});
            this.vendedorToolStripMenuItem.Name = "vendedorToolStripMenuItem";
            this.vendedorToolStripMenuItem.Size = new System.Drawing.Size(109, 32);
            this.vendedorToolStripMenuItem.Text = "Vendedor";
            // 
            // gerenciarVendedoresToolStripMenuItem
            // 
            this.gerenciarVendedoresToolStripMenuItem.Name = "gerenciarVendedoresToolStripMenuItem";
            this.gerenciarVendedoresToolStripMenuItem.Size = new System.Drawing.Size(275, 32);
            this.gerenciarVendedoresToolStripMenuItem.Text = "Gerenciar Vendedores";
            this.gerenciarVendedoresToolStripMenuItem.Click += new System.EventHandler(this.gerenciarVendedoresToolStripMenuItem_Click);
            // 
            // veículoToolStripMenuItem
            // 
            this.veículoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem});
            this.veículoToolStripMenuItem.Name = "veículoToolStripMenuItem";
            this.veículoToolStripMenuItem.Size = new System.Drawing.Size(87, 32);
            this.veículoToolStripMenuItem.Text = "Veículo";
            // 
            // cadastrarToolStripMenuItem
            // 
            this.cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            this.cadastrarToolStripMenuItem.Size = new System.Drawing.Size(180, 32);
            this.cadastrarToolStripMenuItem.Text = "Cadastrar";
            this.cadastrarToolStripMenuItem.Click += new System.EventHandler(this.cadastrarToolStripMenuItem_Click);
            // 
            // acompanharToolStripMenuItem
            // 
            this.acompanharToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendasPeríodoToolStripMenuItem,
            this.vendasVendedorToolStripMenuItem});
            this.acompanharToolStripMenuItem.Name = "acompanharToolStripMenuItem";
            this.acompanharToolStripMenuItem.Size = new System.Drawing.Size(136, 32);
            this.acompanharToolStripMenuItem.Text = "Acompanhar";
            // 
            // vendasPeríodoToolStripMenuItem
            // 
            this.vendasPeríodoToolStripMenuItem.Name = "vendasPeríodoToolStripMenuItem";
            this.vendasPeríodoToolStripMenuItem.Size = new System.Drawing.Size(235, 32);
            this.vendasPeríodoToolStripMenuItem.Text = "Vendas período";
            this.vendasPeríodoToolStripMenuItem.Click += new System.EventHandler(this.vendasPeríodoToolStripMenuItem_Click);
            // 
            // vendasVendedorToolStripMenuItem
            // 
            this.vendasVendedorToolStripMenuItem.Name = "vendasVendedorToolStripMenuItem";
            this.vendasVendedorToolStripMenuItem.Size = new System.Drawing.Size(235, 32);
            this.vendasVendedorToolStripMenuItem.Text = "Vendas vendedor";
            this.vendasVendedorToolStripMenuItem.Click += new System.EventHandler(this.vendasVendedorToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(57, 32);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 740);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastroBásicoToolStripMenuItem;
        private ToolStripMenuItem corToolStripMenuItem;
        private ToolStripMenuItem marcaToolStripMenuItem;
        private ToolStripMenuItem modeloToolStripMenuItem;
        private ToolStripMenuItem vendedorToolStripMenuItem;
        private ToolStripMenuItem gerenciarVendedoresToolStripMenuItem;
        private ToolStripMenuItem veículoToolStripMenuItem;
        private ToolStripMenuItem cadastrarToolStripMenuItem;
        private ToolStripMenuItem acompanharToolStripMenuItem;
        private ToolStripMenuItem vendasPeríodoToolStripMenuItem;
        private ToolStripMenuItem vendasVendedorToolStripMenuItem;
        private ToolStripMenuItem sairToolStripMenuItem;
    }
}