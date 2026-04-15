using AgendamentoHospitalarInteligente.Desktop.Models;

namespace AgendamentoHospitalarInteligente.Desktop.Forms.UserControls
{
    public partial class MedicosListControl : UserControl
    {
        private int? _editandoId;
        private const int TamanhoPagina = 10;
        private int _paginaAtual = 1;
        private int _totalRegistros;

        public MedicosListControl()
        {
            InitializeComponent();

            btnNovo.Click += (_, _) => MostrarFormulario(null);
            btnAddHorario.Click += (_, _) => gridHorarios.Rows.Add(mtbInicio.Text, mtbFim.Text, "X");
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += (_, _) => gbForm.Visible = false;
            grid.CellClick += Grid_CellClick;
            gridHorarios.CellClick += (_, e) =>
            {
                if (e.RowIndex >= 0 && gridHorarios.Columns[e.ColumnIndex].Name == "colHorarioRemover")
                    gridHorarios.Rows.RemoveAt(e.RowIndex);
            };
            btnAnterior.Click += async (_, _) => await CarregarAsync(_paginaAtual - 1);
            btnProxima.Click += async (_, _) => await CarregarAsync(_paginaAtual + 1);

            Load += async (_, _) => await CarregarAsync(1);
        }

        private async Task CarregarAsync(int pagina)
        {
            try
            {
                var resultado = await Program.Api.ObterMedicosAsync(pagina, TamanhoPagina);
                _paginaAtual = pagina;
                _totalRegistros = resultado.TotalRegistros;

                grid.Rows.Clear();
                foreach (var m in resultado.Itens)
                {
                    grid.Rows.Add(m.Id, m.Nome, "Editar", "Excluir");
                    grid.Rows[^1].Tag = m;
                }

                AtualizarPaginacao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar medicos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarPaginacao()
        {
            var totalPaginas = Math.Max(1, (int)Math.Ceiling((double)_totalRegistros / TamanhoPagina));
            btnAnterior.Enabled = _paginaAtual > 1;
            btnProxima.Enabled = _paginaAtual < totalPaginas;
            lblPaginacao.Text = $"Página {_paginaAtual} de {totalPaginas}";
        }

        private void MostrarFormulario(MedicoModeloResponse? medico)
        {
            _editandoId = medico?.Id;
            txtNome.Text = medico?.Nome ?? "";
            gridHorarios.Rows.Clear();
            if (medico != null)
            {
                foreach (var h in medico.HorariosDisponiveis)
                    gridHorarios.Rows.Add(h.Inicio, h.Fim, "X");
            }
            gbForm.Text = medico == null ? "Novo Medico" : $"Editar Medico #{medico.Id}";
            gbForm.Visible = true;
        }

        private async void Grid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var medico = (MedicoModeloResponse)grid.Rows[e.RowIndex].Tag!;

            if (grid.Columns[e.ColumnIndex].Name == "colEditar")
            {
                MostrarFormulario(medico);
            }
            else if (grid.Columns[e.ColumnIndex].Name == "colExcluir")
            {
                if (MessageBox.Show($"Excluir {medico.Nome}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try { await Program.Api.RemoverMedicoAsync(medico.Id); await CarregarAsync(_paginaAtual); }
                    catch (Exception ex) { MessageBox.Show($"Erro: {ex.Message}"); }
                }
            }
        }

        private async void BtnSalvar_Click(object? sender, EventArgs e)
        {
            try
            {
                var horarios = new List<HorarioDto>();
                foreach (DataGridViewRow row in gridHorarios.Rows)
                {
                    horarios.Add(new HorarioDto
                    {
                        Inicio = row.Cells["colHorarioInicio"].Value!.ToString()!,
                        Fim = row.Cells["colHorarioFim"].Value!.ToString()!
                    });
                }

                if (_editandoId.HasValue)
                {
                    await Program.Api.AtualizarMedicoAsync(_editandoId.Value, txtNome.Text.Trim(), horarios);
                }
                else
                {
                    await Program.Api.CriarMedicoAsync(txtNome.Text.Trim(), horarios);
                }

                gbForm.Visible = false;
                await CarregarAsync(_paginaAtual);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
