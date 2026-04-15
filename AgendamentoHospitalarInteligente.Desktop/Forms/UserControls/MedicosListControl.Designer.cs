namespace AgendamentoHospitalarInteligente.Desktop.Forms.UserControls
{
    partial class MedicosListControl
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
            panelPrincipal = new Panel();
            lblTitulo = new Label();
            btnNovo = new Button();
            grid = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNome = new DataGridViewTextBoxColumn();
            colEditar = new DataGridViewButtonColumn();
            colExcluir = new DataGridViewButtonColumn();
            gbForm = new GroupBox();
            lblNome = new Label();
            txtNome = new TextBox();
            lblHorarioInicio = new Label();
            mtbInicio = new MaskedTextBox();
            lblHorarioFim = new Label();
            mtbFim = new MaskedTextBox();
            btnAddHorario = new Button();
            gridHorarios = new DataGridView();
            colHorarioInicio = new DataGridViewTextBoxColumn();
            colHorarioFim = new DataGridViewTextBoxColumn();
            colHorarioRemover = new DataGridViewButtonColumn();
            btnSalvar = new Button();
            btnCancelar = new Button();
            btnAnterior = new Button();
            lblPaginacao = new Label();
            btnProxima = new Button();
            panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            gbForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridHorarios).BeginInit();
            SuspendLayout();
            // 
            // panelPrincipal
            // 
            panelPrincipal.AutoScroll = true;
            panelPrincipal.Controls.Add(lblTitulo);
            panelPrincipal.Controls.Add(btnNovo);
            panelPrincipal.Controls.Add(grid);
            panelPrincipal.Controls.Add(btnAnterior);
            panelPrincipal.Controls.Add(lblPaginacao);
            panelPrincipal.Controls.Add(btnProxima);
            panelPrincipal.Controls.Add(gbForm);
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.Location = new Point(0, 0);
            panelPrincipal.Margin = new Padding(3, 4, 3, 4);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Padding = new Padding(6, 7, 6, 7);
            panelPrincipal.Size = new Size(994, 933);
            panelPrincipal.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(426, 7);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(125, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Medicos";
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(11, 67);
            btnNovo.Margin = new Padding(3, 4, 3, 4);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(171, 47);
            btnNovo.TabIndex = 1;
            btnNovo.Text = "Novo Medico";
            btnNovo.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;
            grid.ColumnHeadersHeight = 29;
            grid.Columns.AddRange(new DataGridViewColumn[] { colId, colNome, colEditar, colExcluir });
            grid.Location = new Point(11, 127);
            grid.Margin = new Padding(3, 4, 3, 4);
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidth = 51;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(949, 333);
            grid.TabIndex = 2;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colNome
            // 
            colNome.HeaderText = "Nome";
            colNome.MinimumWidth = 6;
            colNome.Name = "colNome";
            colNome.ReadOnly = true;
            // 
            // colEditar
            // 
            colEditar.HeaderText = "Editar";
            colEditar.MinimumWidth = 6;
            colEditar.Name = "colEditar";
            colEditar.ReadOnly = true;
            colEditar.Text = "Editar";
            colEditar.UseColumnTextForButtonValue = true;
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
            // gbForm
            // 
            //
            // btnAnterior
            //
            btnAnterior.Location = new Point(300, 467);
            btnAnterior.Size = new Size(90, 28);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Text = "← Anterior";
            //
            // lblPaginacao
            //
            lblPaginacao.Location = new Point(396, 471);
            lblPaginacao.Size = new Size(160, 20);
            lblPaginacao.TextAlign = ContentAlignment.MiddleCenter;
            lblPaginacao.Name = "lblPaginacao";
            lblPaginacao.Text = "Página 1 de 1";
            //
            // btnProxima
            //
            btnProxima.Location = new Point(560, 467);
            btnProxima.Size = new Size(90, 28);
            btnProxima.Name = "btnProxima";
            btnProxima.Text = "Próxima →";
            //
            // gbForm
            //
            gbForm.Controls.Add(lblNome);
            gbForm.Controls.Add(txtNome);
            gbForm.Controls.Add(lblHorarioInicio);
            gbForm.Controls.Add(mtbInicio);
            gbForm.Controls.Add(lblHorarioFim);
            gbForm.Controls.Add(mtbFim);
            gbForm.Controls.Add(btnAddHorario);
            gbForm.Controls.Add(gridHorarios);
            gbForm.Controls.Add(btnSalvar);
            gbForm.Controls.Add(btnCancelar);
            gbForm.Location = new Point(11, 507);
            gbForm.Margin = new Padding(3, 4, 3, 4);
            gbForm.Name = "gbForm";
            gbForm.Padding = new Padding(3, 4, 3, 4);
            gbForm.Size = new Size(949, 333);
            gbForm.TabIndex = 3;
            gbForm.TabStop = false;
            gbForm.Text = "Medico";
            gbForm.Visible = false;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(17, 33);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(53, 20);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(17, 60);
            txtNome.Margin = new Padding(3, 4, 3, 4);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(342, 27);
            txtNome.TabIndex = 1;
            // 
            // lblHorarioInicio
            // 
            lblHorarioInicio.AutoSize = true;
            lblHorarioInicio.Location = new Point(17, 107);
            lblHorarioInicio.Name = "lblHorarioInicio";
            lblHorarioInicio.Size = new Size(48, 20);
            lblHorarioInicio.TabIndex = 2;
            lblHorarioInicio.Text = "Inicio:";
            // 
            // mtbInicio
            // 
            mtbInicio.Location = new Point(17, 133);
            mtbInicio.Margin = new Padding(3, 4, 3, 4);
            mtbInicio.Mask = "00:00";
            mtbInicio.Name = "mtbInicio";
            mtbInicio.Size = new Size(91, 27);
            mtbInicio.TabIndex = 3;
            mtbInicio.Text = "0800";
            // 
            // lblHorarioFim
            // 
            lblHorarioFim.AutoSize = true;
            lblHorarioFim.Location = new Point(137, 107);
            lblHorarioFim.Name = "lblHorarioFim";
            lblHorarioFim.Size = new Size(36, 20);
            lblHorarioFim.TabIndex = 4;
            lblHorarioFim.Text = "Fim:";
            // 
            // mtbFim
            // 
            mtbFim.Location = new Point(137, 133);
            mtbFim.Margin = new Padding(3, 4, 3, 4);
            mtbFim.Mask = "00:00";
            mtbFim.Name = "mtbFim";
            mtbFim.Size = new Size(91, 27);
            mtbFim.TabIndex = 5;
            mtbFim.Text = "1200";
            // 
            // btnAddHorario
            // 
            btnAddHorario.Location = new Point(514, 127);
            btnAddHorario.Margin = new Padding(3, 4, 3, 4);
            btnAddHorario.Name = "btnAddHorario";
            btnAddHorario.Size = new Size(114, 40);
            btnAddHorario.TabIndex = 6;
            btnAddHorario.Text = "+Horario";
            btnAddHorario.UseVisualStyleBackColor = true;
            // 
            // gridHorarios
            // 
            gridHorarios.AllowUserToAddRows = false;
            gridHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridHorarios.BackgroundColor = Color.White;
            gridHorarios.ColumnHeadersHeight = 29;
            gridHorarios.Columns.AddRange(new DataGridViewColumn[] { colHorarioInicio, colHorarioFim, colHorarioRemover });
            gridHorarios.Location = new Point(17, 180);
            gridHorarios.Margin = new Padding(3, 4, 3, 4);
            gridHorarios.Name = "gridHorarios";
            gridHorarios.ReadOnly = true;
            gridHorarios.RowHeadersVisible = false;
            gridHorarios.RowHeadersWidth = 51;
            gridHorarios.Size = new Size(611, 100);
            gridHorarios.TabIndex = 7;
            // 
            // colHorarioInicio
            // 
            colHorarioInicio.HeaderText = "Inicio";
            colHorarioInicio.MinimumWidth = 6;
            colHorarioInicio.Name = "colHorarioInicio";
            colHorarioInicio.ReadOnly = true;
            // 
            // colHorarioFim
            // 
            colHorarioFim.HeaderText = "Fim";
            colHorarioFim.MinimumWidth = 6;
            colHorarioFim.Name = "colHorarioFim";
            colHorarioFim.ReadOnly = true;
            // 
            // colHorarioRemover
            // 
            colHorarioRemover.HeaderText = "";
            colHorarioRemover.MinimumWidth = 6;
            colHorarioRemover.Name = "colHorarioRemover";
            colHorarioRemover.ReadOnly = true;
            colHorarioRemover.Text = "X";
            colHorarioRemover.UseColumnTextForButtonValue = true;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(651, 180);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(137, 47);
            btnSalvar.TabIndex = 8;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(651, 233);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(137, 47);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // MedicosListControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelPrincipal);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MedicosListControl";
            Size = new Size(994, 933);
            panelPrincipal.ResumeLayout(false);
            panelPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            gbForm.ResumeLayout(false);
            gbForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridHorarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colExcluir;
        private System.Windows.Forms.GroupBox gbForm;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblHorarioInicio;
        private System.Windows.Forms.MaskedTextBox mtbInicio;
        private System.Windows.Forms.Label lblHorarioFim;
        private System.Windows.Forms.MaskedTextBox mtbFim;
        private System.Windows.Forms.Button btnAddHorario;
        private System.Windows.Forms.DataGridView gridHorarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHorarioInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHorarioFim;
        private System.Windows.Forms.DataGridViewButtonColumn colHorarioRemover;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Label lblPaginacao;
        private System.Windows.Forms.Button btnProxima;
    }
}
