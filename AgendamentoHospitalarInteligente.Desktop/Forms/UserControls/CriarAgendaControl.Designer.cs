namespace AgendamentoHospitalarInteligente.Desktop.Forms.UserControls
{
    partial class CriarAgendaControl
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
            gbMedico = new GroupBox();
            lblModelo = new Label();
            cmbMedicoExistente = new ComboBox();
            gridMedicos = new DataGridView();
            colMedicoInfo = new DataGridViewTextBoxColumn();
            colMedicoRemover = new DataGridViewButtonColumn();
            lblNomeMedico = new Label();
            txtMedicoNome = new TextBox();
            lblHorarioInicio = new Label();
            mtbHorarioInicio = new MaskedTextBox();
            lblHorarioFim = new Label();
            mtbHorarioFim = new MaskedTextBox();
            gridHorariosTemp = new DataGridView();
            colHorarioInicio = new DataGridViewTextBoxColumn();
            colHorarioFim = new DataGridViewTextBoxColumn();
            btnAddHorario = new Button();
            btnAddMedico = new Button();
            gbSolicitacao = new GroupBox();
            lblPacienteNome = new Label();
            txtPacienteNome = new TextBox();
            lblDuracao = new Label();
            nudDuracao = new NumericUpDown();
            gridSolicitacoes = new DataGridView();
            colSolicitacaoInfo = new DataGridViewTextBoxColumn();
            colSolicitacaoDuracao = new DataGridViewTextBoxColumn();
            colSolicitacaoPrioridade = new DataGridViewTextBoxColumn();
            colSolicitacaoRemover = new DataGridViewButtonColumn();
            lblPrioridade = new Label();
            cmbPrioridade = new ComboBox();
            btnAddSolicitacao = new Button();
            btnGerarAgenda = new Button();
            chkRespeitarHoraAtual = new CheckBox();
            panelPrincipal.SuspendLayout();
            gbMedico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridMedicos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridHorariosTemp).BeginInit();
            gbSolicitacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuracao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSolicitacoes).BeginInit();
            SuspendLayout();
            // 
            // panelPrincipal
            // 
            panelPrincipal.AutoScroll = true;
            panelPrincipal.Controls.Add(lblTitulo);
            panelPrincipal.Controls.Add(gbMedico);
            panelPrincipal.Controls.Add(gbSolicitacao);
            panelPrincipal.Controls.Add(btnGerarAgenda);
            panelPrincipal.Controls.Add(chkRespeitarHoraAtual);
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.Location = new Point(0, 0);
            panelPrincipal.Margin = new Padding(3, 4, 3, 4);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Padding = new Padding(6, 7, 6, 7);
            panelPrincipal.Size = new Size(994, 1067);
            panelPrincipal.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(367, 40);
            lblTitulo.Margin = new Padding(0, 0, 0, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(269, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gerar Nova Agenda";
            // 
            // gbMedico
            // 
            gbMedico.Controls.Add(lblModelo);
            gbMedico.Controls.Add(cmbMedicoExistente);
            gbMedico.Controls.Add(gridMedicos);
            gbMedico.Controls.Add(lblNomeMedico);
            gbMedico.Controls.Add(txtMedicoNome);
            gbMedico.Controls.Add(lblHorarioInicio);
            gbMedico.Controls.Add(mtbHorarioInicio);
            gbMedico.Controls.Add(lblHorarioFim);
            gbMedico.Controls.Add(mtbHorarioFim);
            gbMedico.Controls.Add(gridHorariosTemp);
            gbMedico.Controls.Add(btnAddHorario);
            gbMedico.Controls.Add(btnAddMedico);
            gbMedico.Location = new Point(71, 84);
            gbMedico.Margin = new Padding(3, 4, 3, 4);
            gbMedico.Name = "gbMedico";
            gbMedico.Padding = new Padding(3, 4, 3, 4);
            gbMedico.Size = new Size(851, 498);
            gbMedico.TabIndex = 1;
            gbMedico.TabStop = false;
            gbMedico.Text = "Adicionar Medico";
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Location = new Point(17, 33);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(64, 20);
            lblModelo.TabIndex = 0;
            lblModelo.Text = "Modelo:";
            // 
            // cmbMedicoExistente
            // 
            cmbMedicoExistente.DropDownStyle = ComboBoxStyle.DropDown;
            cmbMedicoExistente.Location = new Point(17, 60);
            cmbMedicoExistente.Margin = new Padding(3, 4, 3, 4);
            cmbMedicoExistente.Name = "cmbMedicoExistente";
            cmbMedicoExistente.Size = new Size(228, 28);
            cmbMedicoExistente.TabIndex = 1;
            // 
            // gridMedicos
            // 
            gridMedicos.AllowUserToAddRows = false;
            gridMedicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridMedicos.BackgroundColor = Color.White;
            gridMedicos.ColumnHeadersHeight = 29;
            gridMedicos.Columns.AddRange(new DataGridViewColumn[] { colMedicoInfo, colMedicoRemover });
            gridMedicos.Location = new Point(17, 271);
            gridMedicos.Margin = new Padding(3, 4, 3, 4);
            gridMedicos.Name = "gridMedicos";
            gridMedicos.ReadOnly = true;
            gridMedicos.RowHeadersVisible = false;
            gridMedicos.RowHeadersWidth = 51;
            gridMedicos.Size = new Size(806, 209);
            gridMedicos.TabIndex = 2;
            // 
            // colMedicoInfo
            // 
            colMedicoInfo.HeaderText = "Medico";
            colMedicoInfo.MinimumWidth = 6;
            colMedicoInfo.Name = "colMedicoInfo";
            colMedicoInfo.ReadOnly = true;
            // 
            // colMedicoRemover
            // 
            colMedicoRemover.HeaderText = "Remover";
            colMedicoRemover.MinimumWidth = 6;
            colMedicoRemover.Name = "colMedicoRemover";
            colMedicoRemover.ReadOnly = true;
            colMedicoRemover.Text = "Remover";
            colMedicoRemover.UseColumnTextForButtonValue = true;
            // 
            // lblNomeMedico
            // 
            lblNomeMedico.AutoSize = true;
            lblNomeMedico.Location = new Point(17, 101);
            lblNomeMedico.Name = "lblNomeMedico";
            lblNomeMedico.Size = new Size(53, 20);
            lblNomeMedico.TabIndex = 2;
            lblNomeMedico.Text = "Nome:";
            // 
            // txtMedicoNome
            // 
            txtMedicoNome.Location = new Point(17, 125);
            txtMedicoNome.Margin = new Padding(3, 4, 3, 4);
            txtMedicoNome.Name = "txtMedicoNome";
            txtMedicoNome.PlaceholderText = "Nome do medico";
            txtMedicoNome.Size = new Size(228, 27);
            txtMedicoNome.TabIndex = 3;
            // 
            // lblHorarioInicio
            // 
            lblHorarioInicio.AutoSize = true;
            lblHorarioInicio.Location = new Point(358, 33);
            lblHorarioInicio.Name = "lblHorarioInicio";
            lblHorarioInicio.Size = new Size(103, 20);
            lblHorarioInicio.TabIndex = 4;
            lblHorarioInicio.Text = "Horario Inicio:";
            // 
            // mtbHorarioInicio
            // 
            mtbHorarioInicio.Location = new Point(357, 61);
            mtbHorarioInicio.Margin = new Padding(3, 4, 3, 4);
            mtbHorarioInicio.Mask = "00:00";
            mtbHorarioInicio.Name = "mtbHorarioInicio";
            mtbHorarioInicio.Size = new Size(114, 27);
            mtbHorarioInicio.TabIndex = 5;
            mtbHorarioInicio.Text = "0800";
            // 
            // lblHorarioFim
            // 
            lblHorarioFim.AutoSize = true;
            lblHorarioFim.Location = new Point(357, 101);
            lblHorarioFim.Name = "lblHorarioFim";
            lblHorarioFim.Size = new Size(91, 20);
            lblHorarioFim.TabIndex = 6;
            lblHorarioFim.Text = "Horario Fim:";
            // 
            // mtbHorarioFim
            // 
            mtbHorarioFim.Location = new Point(357, 125);
            mtbHorarioFim.Margin = new Padding(3, 4, 3, 4);
            mtbHorarioFim.Mask = "00:00";
            mtbHorarioFim.Name = "mtbHorarioFim";
            mtbHorarioFim.Size = new Size(114, 27);
            mtbHorarioFim.TabIndex = 7;
            mtbHorarioFim.Text = "1200";
            // 
            // gridHorariosTemp
            // 
            gridHorariosTemp.AllowUserToAddRows = false;
            gridHorariosTemp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridHorariosTemp.BackgroundColor = Color.White;
            gridHorariosTemp.ColumnHeadersHeight = 29;
            gridHorariosTemp.Columns.AddRange(new DataGridViewColumn[] { colHorarioInicio, colHorarioFim });
            gridHorariosTemp.Location = new Point(503, 33);
            gridHorariosTemp.Margin = new Padding(3, 4, 3, 4);
            gridHorariosTemp.Name = "gridHorariosTemp";
            gridHorariosTemp.ReadOnly = true;
            gridHorariosTemp.RowHeadersVisible = false;
            gridHorariosTemp.RowHeadersWidth = 51;
            gridHorariosTemp.Size = new Size(320, 201);
            gridHorariosTemp.TabIndex = 8;
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
            // btnAddHorario
            // 
            btnAddHorario.Location = new Point(357, 187);
            btnAddHorario.Margin = new Padding(3, 4, 3, 4);
            btnAddHorario.Name = "btnAddHorario";
            btnAddHorario.Size = new Size(115, 47);
            btnAddHorario.TabIndex = 9;
            btnAddHorario.Text = "+Horario";
            btnAddHorario.UseVisualStyleBackColor = true;
            // 
            // btnAddMedico
            // 
            btnAddMedico.Location = new Point(16, 187);
            btnAddMedico.Margin = new Padding(3, 4, 3, 4);
            btnAddMedico.Name = "btnAddMedico";
            btnAddMedico.Size = new Size(229, 47);
            btnAddMedico.TabIndex = 10;
            btnAddMedico.Text = "Adicionar Medico";
            btnAddMedico.UseVisualStyleBackColor = true;
            // 
            // gbSolicitacao
            // 
            gbSolicitacao.Controls.Add(lblPacienteNome);
            gbSolicitacao.Controls.Add(txtPacienteNome);
            gbSolicitacao.Controls.Add(lblDuracao);
            gbSolicitacao.Controls.Add(nudDuracao);
            gbSolicitacao.Controls.Add(gridSolicitacoes);
            gbSolicitacao.Controls.Add(lblPrioridade);
            gbSolicitacao.Controls.Add(cmbPrioridade);
            gbSolicitacao.Controls.Add(btnAddSolicitacao);
            gbSolicitacao.Location = new Point(71, 590);
            gbSolicitacao.Margin = new Padding(3, 4, 3, 4);
            gbSolicitacao.Name = "gbSolicitacao";
            gbSolicitacao.Padding = new Padding(3, 4, 3, 4);
            gbSolicitacao.Size = new Size(851, 363);
            gbSolicitacao.TabIndex = 3;
            gbSolicitacao.TabStop = false;
            gbSolicitacao.Text = "Adicionar Paciente/Solicitacao";
            // 
            // lblPacienteNome
            // 
            lblPacienteNome.AutoSize = true;
            lblPacienteNome.Location = new Point(17, 33);
            lblPacienteNome.Name = "lblPacienteNome";
            lblPacienteNome.Size = new Size(67, 20);
            lblPacienteNome.TabIndex = 0;
            lblPacienteNome.Text = "Paciente:";
            // 
            // txtPacienteNome
            // 
            txtPacienteNome.Location = new Point(17, 60);
            txtPacienteNome.Margin = new Padding(3, 4, 3, 4);
            txtPacienteNome.Name = "txtPacienteNome";
            txtPacienteNome.PlaceholderText = "Nome do paciente";
            txtPacienteNome.Size = new Size(228, 27);
            txtPacienteNome.TabIndex = 1;
            // 
            // lblDuracao
            // 
            lblDuracao.AutoSize = true;
            lblDuracao.Location = new Point(263, 33);
            lblDuracao.Name = "lblDuracao";
            lblDuracao.Size = new Size(107, 20);
            lblDuracao.TabIndex = 2;
            lblDuracao.Text = "Duracao (min):";
            // 
            // nudDuracao
            // 
            nudDuracao.Location = new Point(263, 60);
            nudDuracao.Margin = new Padding(3, 4, 3, 4);
            nudDuracao.Maximum = new decimal(new int[] { 480, 0, 0, 0 });
            nudDuracao.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nudDuracao.Name = "nudDuracao";
            nudDuracao.Size = new Size(91, 27);
            nudDuracao.TabIndex = 3;
            nudDuracao.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // gridSolicitacoes
            // 
            gridSolicitacoes.AllowUserToAddRows = false;
            gridSolicitacoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSolicitacoes.BackgroundColor = Color.White;
            gridSolicitacoes.ColumnHeadersHeight = 29;
            gridSolicitacoes.Columns.AddRange(new DataGridViewColumn[] { colSolicitacaoInfo, colSolicitacaoDuracao, colSolicitacaoPrioridade, colSolicitacaoRemover });
            gridSolicitacoes.Location = new Point(17, 156);
            gridSolicitacoes.Margin = new Padding(3, 4, 3, 4);
            gridSolicitacoes.Name = "gridSolicitacoes";
            gridSolicitacoes.ReadOnly = true;
            gridSolicitacoes.RowHeadersVisible = false;
            gridSolicitacoes.RowHeadersWidth = 51;
            gridSolicitacoes.Size = new Size(806, 184);
            gridSolicitacoes.TabIndex = 4;
            // 
            // colSolicitacaoInfo
            // 
            colSolicitacaoInfo.HeaderText = "Paciente";
            colSolicitacaoInfo.MinimumWidth = 6;
            colSolicitacaoInfo.Name = "colSolicitacaoInfo";
            colSolicitacaoInfo.ReadOnly = true;
            // 
            // colSolicitacaoDuracao
            // 
            colSolicitacaoDuracao.HeaderText = "Duracao (min)";
            colSolicitacaoDuracao.MinimumWidth = 6;
            colSolicitacaoDuracao.Name = "colSolicitacaoDuracao";
            colSolicitacaoDuracao.ReadOnly = true;
            // 
            // colSolicitacaoPrioridade
            // 
            colSolicitacaoPrioridade.HeaderText = "Prioridade";
            colSolicitacaoPrioridade.MinimumWidth = 6;
            colSolicitacaoPrioridade.Name = "colSolicitacaoPrioridade";
            colSolicitacaoPrioridade.ReadOnly = true;
            // 
            // colSolicitacaoRemover
            // 
            colSolicitacaoRemover.HeaderText = "Remover";
            colSolicitacaoRemover.MinimumWidth = 6;
            colSolicitacaoRemover.Name = "colSolicitacaoRemover";
            colSolicitacaoRemover.ReadOnly = true;
            colSolicitacaoRemover.Text = "Remover";
            colSolicitacaoRemover.UseColumnTextForButtonValue = true;
            // 
            // lblPrioridade
            // 
            lblPrioridade.AutoSize = true;
            lblPrioridade.Location = new Point(377, 33);
            lblPrioridade.Name = "lblPrioridade";
            lblPrioridade.Size = new Size(81, 20);
            lblPrioridade.TabIndex = 4;
            lblPrioridade.Text = "Prioridade:";
            // 
            // cmbPrioridade
            // 
            cmbPrioridade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrioridade.Location = new Point(377, 60);
            cmbPrioridade.Margin = new Padding(3, 4, 3, 4);
            cmbPrioridade.Name = "cmbPrioridade";
            cmbPrioridade.Size = new Size(137, 28);
            cmbPrioridade.TabIndex = 5;
            // 
            // btnAddSolicitacao
            // 
            btnAddSolicitacao.Location = new Point(537, 53);
            btnAddSolicitacao.Margin = new Padding(3, 4, 3, 4);
            btnAddSolicitacao.Name = "btnAddSolicitacao";
            btnAddSolicitacao.Size = new Size(194, 47);
            btnAddSolicitacao.TabIndex = 6;
            btnAddSolicitacao.Text = "Adicionar Paciente";
            btnAddSolicitacao.UseVisualStyleBackColor = true;
            // 
            // btnGerarAgenda
            // 
            btnGerarAgenda.BackColor = Color.LightGray;
            btnGerarAgenda.Enabled = false;
            btnGerarAgenda.FlatStyle = FlatStyle.Flat;
            btnGerarAgenda.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGerarAgenda.ForeColor = Color.White;
            btnGerarAgenda.Location = new Point(367, 970);
            btnGerarAgenda.Margin = new Padding(0, 13, 0, 0);
            btnGerarAgenda.Name = "btnGerarAgenda";
            btnGerarAgenda.Size = new Size(269, 60);
            btnGerarAgenda.TabIndex = 5;
            btnGerarAgenda.Text = "Gerar Agenda";
            btnGerarAgenda.UseVisualStyleBackColor = false;
            // 
            // chkRespeitarHoraAtual
            // 
            chkRespeitarHoraAtual.AutoSize = true;
            chkRespeitarHoraAtual.Location = new Point(71, 992);
            chkRespeitarHoraAtual.Name = "chkRespeitarHoraAtual";
            chkRespeitarHoraAtual.Size = new Size(282, 24);
            chkRespeitarHoraAtual.TabIndex = 7;
            chkRespeitarHoraAtual.Text = "Respeitar hora atual (horários futuros)";
            chkRespeitarHoraAtual.UseVisualStyleBackColor = true;
            // 
            // CriarAgendaControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(panelPrincipal);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CriarAgendaControl";
            Size = new Size(994, 1067);
            panelPrincipal.ResumeLayout(false);
            panelPrincipal.PerformLayout();
            gbMedico.ResumeLayout(false);
            gbMedico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridMedicos).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridHorariosTemp).EndInit();
            gbSolicitacao.ResumeLayout(false);
            gbSolicitacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuracao).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSolicitacoes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbMedico;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.ComboBox cmbMedicoExistente;
        private System.Windows.Forms.Label lblNomeMedico;
        private System.Windows.Forms.TextBox txtMedicoNome;
        private System.Windows.Forms.Label lblHorarioInicio;
        private System.Windows.Forms.MaskedTextBox mtbHorarioInicio;
        private System.Windows.Forms.Label lblHorarioFim;
        private System.Windows.Forms.MaskedTextBox mtbHorarioFim;
        private System.Windows.Forms.DataGridView gridHorariosTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHorarioInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHorarioFim;
        private System.Windows.Forms.Button btnAddHorario;
        private System.Windows.Forms.Button btnAddMedico;
        private System.Windows.Forms.DataGridView gridMedicos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicoInfo;
        private System.Windows.Forms.DataGridViewButtonColumn colMedicoRemover;
        private System.Windows.Forms.GroupBox gbSolicitacao;
        private System.Windows.Forms.Label lblPacienteNome;
        private System.Windows.Forms.TextBox txtPacienteNome;
        private System.Windows.Forms.Label lblDuracao;
        private System.Windows.Forms.NumericUpDown nudDuracao;
        private System.Windows.Forms.Label lblPrioridade;
        private System.Windows.Forms.ComboBox cmbPrioridade;
        private System.Windows.Forms.Button btnAddSolicitacao;
        private System.Windows.Forms.DataGridView gridSolicitacoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolicitacaoInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolicitacaoDuracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolicitacaoPrioridade;
        private System.Windows.Forms.DataGridViewButtonColumn colSolicitacaoRemover;
        private System.Windows.Forms.Button btnGerarAgenda;
        private System.Windows.Forms.CheckBox chkRespeitarHoraAtual;
    }
}
