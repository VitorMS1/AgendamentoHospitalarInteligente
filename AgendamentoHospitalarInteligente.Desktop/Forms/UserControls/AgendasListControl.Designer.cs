namespace AgendamentoHospitalarInteligente.Desktop.Forms.UserControls
{
    partial class AgendasListControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codigo gerado pelo Windows Form Designer

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            grid = new DataGridView();
            colAgenda = new DataGridViewTextBoxColumn();
            colDetalhes = new DataGridViewButtonColumn();
            colExcluir = new DataGridViewButtonColumn();
            panelPaginacao = new Panel();
            btnAnterior = new Button();
            lblPaginacao = new Label();
            btnProxima = new Button();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            panelPaginacao.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(914, 53);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Agendas";
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Columns.AddRange(new DataGridViewColumn[] { colAgenda, colDetalhes, colExcluir });
            grid.Dock = DockStyle.Fill;
            grid.Location = new Point(0, 53);
            grid.Margin = new Padding(3, 4, 3, 4);
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidth = 51;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(914, 614);
            grid.TabIndex = 1;
            // 
            // colAgenda
            // 
            colAgenda.HeaderText = "Agenda";
            colAgenda.MinimumWidth = 6;
            colAgenda.Name = "colAgenda";
            colAgenda.ReadOnly = true;
            // 
            // colDetalhes
            // 
            colDetalhes.HeaderText = "Detalhes";
            colDetalhes.MinimumWidth = 6;
            colDetalhes.Name = "colDetalhes";
            colDetalhes.ReadOnly = true;
            colDetalhes.Text = "Detalhes";
            colDetalhes.UseColumnTextForButtonValue = true;
            // 
            // colExcluir
            // 
            colExcluir.HeaderText = "Excluir";
            colExcluir.MinimumWidth = 6;
            colExcluir.Name = "colExcluir";
            colExcluir.ReadOnly = true;
            colExcluir.Text = "Excluir";
            colExcluir.UseColumnTextForButtonValue = true;
            //
            // panelPaginacao
            //
            panelPaginacao.Controls.Add(btnAnterior);
            panelPaginacao.Controls.Add(lblPaginacao);
            panelPaginacao.Controls.Add(btnProxima);
            panelPaginacao.Dock = DockStyle.Bottom;
            panelPaginacao.Height = 40;
            panelPaginacao.Name = "panelPaginacao";
            //
            // btnAnterior
            //
            btnAnterior.Location = new Point(300, 6);
            btnAnterior.Size = new Size(90, 28);
            btnAnterior.Text = "← Anterior";
            btnAnterior.Name = "btnAnterior";
            //
            // lblPaginacao
            //
            lblPaginacao.Location = new Point(396, 10);
            lblPaginacao.Size = new Size(160, 20);
            lblPaginacao.TextAlign = ContentAlignment.MiddleCenter;
            lblPaginacao.Name = "lblPaginacao";
            lblPaginacao.Text = "Página 1 de 1";
            //
            // btnProxima
            //
            btnProxima.Location = new Point(560, 6);
            btnProxima.Size = new Size(90, 28);
            btnProxima.Text = "Próxima →";
            btnProxima.Name = "btnProxima";
            //
            // AgendasListControl
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grid);
            Controls.Add(panelPaginacao);
            Controls.Add(lblTitulo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AgendasListControl";
            Size = new Size(914, 667);
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            panelPaginacao.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAgenda;
        private System.Windows.Forms.DataGridViewButtonColumn colDetalhes;
        private System.Windows.Forms.DataGridViewButtonColumn colExcluir;
        private System.Windows.Forms.Panel panelPaginacao;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Label lblPaginacao;
        private System.Windows.Forms.Button btnProxima;
    }
}
