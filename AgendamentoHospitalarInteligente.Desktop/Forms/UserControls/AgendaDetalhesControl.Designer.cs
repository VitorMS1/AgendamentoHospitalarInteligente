namespace AgendamentoHospitalarInteligente.Desktop.Forms.UserControls
{
    partial class AgendaDetalhesControl
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
            btnEncaixar = new Button();
            lblPac = new Label();
            lblTitulo = new Label();
            txtPacienteNome = new TextBox();
            lblDur = new Label();
            lblMedicos = new Label();
            nudDuracao = new NumericUpDown();
            gridMedicos = new DataGridView();
            colMedicoNome = new DataGridViewTextBoxColumn();
            colMedicoHorarios = new DataGridViewTextBoxColumn();
            lblPri = new Label();
            lblConsultas = new Label();
            cmbPrioridade = new ComboBox();
            gridConsultas = new DataGridView();
            colPrioridade = new DataGridViewTextBoxColumn();
            colPaciente = new DataGridViewTextBoxColumn();
            colMedico = new DataGridViewTextBoxColumn();
            colHorario = new DataGridViewTextBoxColumn();
            colDuracao = new DataGridViewTextBoxColumn();
            lblNaoAlocados = new Label();
            gridNaoAlocados = new DataGridView();
            colNaoAlocadoNome = new DataGridViewTextBoxColumn();
            colNaoAlocadoDuracao = new DataGridViewTextBoxColumn();
            colNaoAlocadoPrioridade = new DataGridViewTextBoxColumn();
            btnMostrarEncaixe = new Button();
            chkRespeitarHoraAtualEncaixe = new CheckBox();
            btnCancelarEncaixe = new Button();
            panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuracao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridMedicos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridConsultas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridNaoAlocados).BeginInit();
            SuspendLayout();
            // 
            // panelPrincipal
            // 
            panelPrincipal.AutoScroll = true;
            panelPrincipal.Controls.Add(btnEncaixar);
            panelPrincipal.Controls.Add(lblPac);
            panelPrincipal.Controls.Add(lblTitulo);
            panelPrincipal.Controls.Add(txtPacienteNome);
            panelPrincipal.Controls.Add(lblDur);
            panelPrincipal.Controls.Add(lblMedicos);
            panelPrincipal.Controls.Add(nudDuracao);
            panelPrincipal.Controls.Add(gridMedicos);
            panelPrincipal.Controls.Add(lblPri);
            panelPrincipal.Controls.Add(lblConsultas);
            panelPrincipal.Controls.Add(cmbPrioridade);
            panelPrincipal.Controls.Add(gridConsultas);
            panelPrincipal.Controls.Add(lblNaoAlocados);
            panelPrincipal.Controls.Add(gridNaoAlocados);
            panelPrincipal.Controls.Add(btnMostrarEncaixe);
            panelPrincipal.Controls.Add(chkRespeitarHoraAtualEncaixe);
            panelPrincipal.Controls.Add(btnCancelarEncaixe);
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.Location = new Point(0, 0);
            panelPrincipal.Margin = new Padding(3, 4, 3, 4);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Padding = new Padding(6, 7, 6, 7);
            panelPrincipal.Size = new Size(994, 1067);
            panelPrincipal.TabIndex = 0;
            // 
            // btnEncaixar
            // 
            btnEncaixar.Location = new Point(11, 993);
            btnEncaixar.Margin = new Padding(3, 4, 3, 4);
            btnEncaixar.Name = "btnEncaixar";
            btnEncaixar.Size = new Size(169, 27);
            btnEncaixar.TabIndex = 6;
            btnEncaixar.Text = "Encaixar";
            btnEncaixar.UseVisualStyleBackColor = true;
            // 
            // lblPac
            // 
            lblPac.AutoSize = true;
            lblPac.Location = new Point(207, 911);
            lblPac.Name = "lblPac";
            lblPac.Size = new Size(67, 20);
            lblPac.TabIndex = 0;
            lblPac.Text = "Paciente:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(351, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(274, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Detalhes da Agenda";
            // 
            // txtPacienteNome
            // 
            txtPacienteNome.Location = new Point(207, 938);
            txtPacienteNome.Margin = new Padding(3, 4, 3, 4);
            txtPacienteNome.Name = "txtPacienteNome";
            txtPacienteNome.PlaceholderText = "Nome do paciente";
            txtPacienteNome.Size = new Size(228, 27);
            txtPacienteNome.TabIndex = 1;
            // 
            // lblDur
            // 
            lblDur.AutoSize = true;
            lblDur.Location = new Point(209, 978);
            lblDur.Name = "lblDur";
            lblDur.Size = new Size(107, 20);
            lblDur.TabIndex = 2;
            lblDur.Text = "Duracao (min):";
            // 
            // lblMedicos
            // 
            lblMedicos.AutoSize = true;
            lblMedicos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMedicos.Location = new Point(11, 67);
            lblMedicos.Name = "lblMedicos";
            lblMedicos.Size = new Size(198, 28);
            lblMedicos.TabIndex = 1;
            lblMedicos.Text = "Medicos da Agenda";
            // 
            // nudDuracao
            // 
            nudDuracao.Location = new Point(209, 1005);
            nudDuracao.Margin = new Padding(3, 4, 3, 4);
            nudDuracao.Maximum = new decimal(new int[] { 480, 0, 0, 0 });
            nudDuracao.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nudDuracao.Name = "nudDuracao";
            nudDuracao.Size = new Size(91, 27);
            nudDuracao.TabIndex = 3;
            nudDuracao.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // gridMedicos
            // 
            gridMedicos.AllowUserToAddRows = false;
            gridMedicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridMedicos.BackgroundColor = Color.White;
            gridMedicos.ColumnHeadersHeight = 29;
            gridMedicos.Columns.AddRange(new DataGridViewColumn[] { colMedicoNome, colMedicoHorarios });
            gridMedicos.Location = new Point(11, 100);
            gridMedicos.Margin = new Padding(3, 4, 3, 4);
            gridMedicos.Name = "gridMedicos";
            gridMedicos.ReadOnly = true;
            gridMedicos.RowHeadersVisible = false;
            gridMedicos.RowHeadersWidth = 51;
            gridMedicos.Size = new Size(949, 200);
            gridMedicos.TabIndex = 2;
            // 
            // colMedicoNome
            // 
            colMedicoNome.HeaderText = "Medico";
            colMedicoNome.MinimumWidth = 6;
            colMedicoNome.Name = "colMedicoNome";
            colMedicoNome.ReadOnly = true;
            // 
            // colMedicoHorarios
            // 
            colMedicoHorarios.HeaderText = "Horarios Disponiveis";
            colMedicoHorarios.MinimumWidth = 6;
            colMedicoHorarios.Name = "colMedicoHorarios";
            colMedicoHorarios.ReadOnly = true;
            // 
            // lblPri
            // 
            lblPri.AutoSize = true;
            lblPri.Location = new Point(322, 977);
            lblPri.Name = "lblPri";
            lblPri.Size = new Size(81, 20);
            lblPri.TabIndex = 4;
            lblPri.Text = "Prioridade:";
            // 
            // lblConsultas
            // 
            lblConsultas.AutoSize = true;
            lblConsultas.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblConsultas.Location = new Point(11, 313);
            lblConsultas.Name = "lblConsultas";
            lblConsultas.Size = new Size(213, 28);
            lblConsultas.TabIndex = 3;
            lblConsultas.Text = "Consultas Agendadas";
            // 
            // cmbPrioridade
            // 
            cmbPrioridade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrioridade.Location = new Point(322, 1004);
            cmbPrioridade.Margin = new Padding(3, 4, 3, 4);
            cmbPrioridade.Name = "cmbPrioridade";
            cmbPrioridade.Size = new Size(113, 28);
            cmbPrioridade.TabIndex = 5;
            // 
            // gridConsultas
            // 
            gridConsultas.AllowUserToAddRows = false;
            gridConsultas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridConsultas.BackgroundColor = Color.White;
            gridConsultas.ColumnHeadersHeight = 29;
            gridConsultas.Columns.AddRange(new DataGridViewColumn[] { colPrioridade, colPaciente, colMedico, colHorario, colDuracao });
            gridConsultas.Location = new Point(11, 347);
            gridConsultas.Margin = new Padding(3, 4, 3, 4);
            gridConsultas.Name = "gridConsultas";
            gridConsultas.ReadOnly = true;
            gridConsultas.RowHeadersVisible = false;
            gridConsultas.RowHeadersWidth = 51;
            gridConsultas.Size = new Size(949, 298);
            gridConsultas.TabIndex = 4;
            // 
            // colPrioridade
            // 
            colPrioridade.HeaderText = "Prioridade";
            colPrioridade.MinimumWidth = 6;
            colPrioridade.Name = "colPrioridade";
            colPrioridade.ReadOnly = true;
            // 
            // colPaciente
            // 
            colPaciente.HeaderText = "Paciente";
            colPaciente.MinimumWidth = 6;
            colPaciente.Name = "colPaciente";
            colPaciente.ReadOnly = true;
            // 
            // colMedico
            // 
            colMedico.HeaderText = "Medico";
            colMedico.MinimumWidth = 6;
            colMedico.Name = "colMedico";
            colMedico.ReadOnly = true;
            // 
            // colHorario
            // 
            colHorario.HeaderText = "Horario";
            colHorario.MinimumWidth = 6;
            colHorario.Name = "colHorario";
            colHorario.ReadOnly = true;
            // 
            // colDuracao
            // 
            colDuracao.HeaderText = "Duracao (min)";
            colDuracao.MinimumWidth = 6;
            colDuracao.Name = "colDuracao";
            colDuracao.ReadOnly = true;
            // 
            // lblNaoAlocados
            // 
            lblNaoAlocados.AutoSize = true;
            lblNaoAlocados.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNaoAlocados.Location = new Point(9, 661);
            lblNaoAlocados.Name = "lblNaoAlocados";
            lblNaoAlocados.Size = new Size(239, 28);
            lblNaoAlocados.TabIndex = 5;
            lblNaoAlocados.Text = "Pacientes Nao Alocados";
            // 
            // gridNaoAlocados
            // 
            gridNaoAlocados.AllowUserToAddRows = false;
            gridNaoAlocados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridNaoAlocados.BackgroundColor = Color.White;
            gridNaoAlocados.ColumnHeadersHeight = 29;
            gridNaoAlocados.Columns.AddRange(new DataGridViewColumn[] { colNaoAlocadoNome, colNaoAlocadoDuracao, colNaoAlocadoPrioridade });
            gridNaoAlocados.Location = new Point(9, 695);
            gridNaoAlocados.Margin = new Padding(3, 4, 3, 4);
            gridNaoAlocados.Name = "gridNaoAlocados";
            gridNaoAlocados.ReadOnly = true;
            gridNaoAlocados.RowHeadersVisible = false;
            gridNaoAlocados.RowHeadersWidth = 51;
            gridNaoAlocados.Size = new Size(949, 200);
            gridNaoAlocados.TabIndex = 6;
            //
            // colNaoAlocadoNome
            //
            colNaoAlocadoNome.HeaderText = "Paciente";
            colNaoAlocadoNome.MinimumWidth = 6;
            colNaoAlocadoNome.Name = "colNaoAlocadoNome";
            colNaoAlocadoNome.ReadOnly = true;
            //
            // colNaoAlocadoDuracao
            //
            colNaoAlocadoDuracao.HeaderText = "Duração (min)";
            colNaoAlocadoDuracao.MinimumWidth = 6;
            colNaoAlocadoDuracao.Name = "colNaoAlocadoDuracao";
            colNaoAlocadoDuracao.ReadOnly = true;
            //
            // colNaoAlocadoPrioridade
            //
            colNaoAlocadoPrioridade.HeaderText = "Prioridade";
            colNaoAlocadoPrioridade.MinimumWidth = 6;
            colNaoAlocadoPrioridade.Name = "colNaoAlocadoPrioridade";
            colNaoAlocadoPrioridade.ReadOnly = true;
            // 
            // btnMostrarEncaixe
            // 
            btnMostrarEncaixe.Location = new Point(11, 939);
            btnMostrarEncaixe.Margin = new Padding(3, 4, 3, 4);
            btnMostrarEncaixe.Name = "btnMostrarEncaixe";
            btnMostrarEncaixe.Size = new Size(169, 27);
            btnMostrarEncaixe.TabIndex = 7;
            btnMostrarEncaixe.Text = "Adicionar Encaixe";
            btnMostrarEncaixe.UseVisualStyleBackColor = true;
            // 
            // chkRespeitarHoraAtualEncaixe
            // 
            chkRespeitarHoraAtualEncaixe.AutoSize = true;
            chkRespeitarHoraAtualEncaixe.Location = new Point(468, 1006);
            chkRespeitarHoraAtualEncaixe.Name = "chkRespeitarHoraAtualEncaixe";
            chkRespeitarHoraAtualEncaixe.Size = new Size(282, 24);
            chkRespeitarHoraAtualEncaixe.TabIndex = 8;
            chkRespeitarHoraAtualEncaixe.Text = "Respeitar hora atual (horários futuros)";
            chkRespeitarHoraAtualEncaixe.UseVisualStyleBackColor = true;
            // 
            // btnCancelarEncaixe
            // 
            btnCancelarEncaixe.Location = new Point(9, 938);
            btnCancelarEncaixe.Margin = new Padding(3, 4, 3, 4);
            btnCancelarEncaixe.Name = "btnCancelarEncaixe";
            btnCancelarEncaixe.Size = new Size(171, 28);
            btnCancelarEncaixe.TabIndex = 9;
            btnCancelarEncaixe.Text = "Cancelar";
            btnCancelarEncaixe.UseVisualStyleBackColor = true;
            // 
            // AgendaDetalhesControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(panelPrincipal);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AgendaDetalhesControl";
            Size = new Size(994, 1067);
            panelPrincipal.ResumeLayout(false);
            panelPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuracao).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridMedicos).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridConsultas).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridNaoAlocados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMedicos;
        private System.Windows.Forms.DataGridView gridMedicos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicoNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicoHorarios;
        private System.Windows.Forms.Label lblConsultas;
        private System.Windows.Forms.DataGridView gridConsultas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrioridade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHorario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuracao;
        private System.Windows.Forms.Label lblNaoAlocados;
        private System.Windows.Forms.DataGridView gridNaoAlocados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNaoAlocadoNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNaoAlocadoDuracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNaoAlocadoPrioridade;
        private System.Windows.Forms.Button btnMostrarEncaixe;
        private Button btnEncaixar;
        private Label lblPac;
        private TextBox txtPacienteNome;
        private Label lblDur;
        private NumericUpDown nudDuracao;
        private Label lblPri;
        private ComboBox cmbPrioridade;
        private CheckBox chkRespeitarHoraAtualEncaixe;
        private Button btnCancelarEncaixe;
    }
}
