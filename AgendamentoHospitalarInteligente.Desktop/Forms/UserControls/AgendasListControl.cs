namespace AgendamentoHospitalarInteligente.Desktop.Forms.UserControls
{
    public partial class AgendasListControl : UserControl
    {
        private readonly MainForm _main;
        private const int TamanhoPagina = 10;
        private int _paginaAtual = 1;
        private int _totalRegistros;

        public AgendasListControl(MainForm main)
        {
            InitializeComponent();
            _main = main;

            grid.CellClick += Grid_CellClick;
            btnAnterior.Click += async (_, _) => await CarregarAsync(_paginaAtual - 1);
            btnProxima.Click += async (_, _) => await CarregarAsync(_paginaAtual + 1);

            Load += async (_, _) => await CarregarAsync(1);
        }

        private async Task CarregarAsync(int pagina)
        {
            try
            {
                var resultado = await Program.Api.ObterAgendasAsync(pagina, TamanhoPagina);
                _paginaAtual = pagina;
                _totalRegistros = resultado.TotalRegistros;

                grid.Rows.Clear();
                foreach (var agenda in resultado.Itens)
                {
                    grid.Rows.Add($"{agenda.Id} - {agenda.Data:dd/MM/yyyy}", "Detalhes", "Excluir");
                    grid.Rows[^1].Tag = agenda.Id;
                }

                AtualizarPaginacao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar agendas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarPaginacao()
        {
            var totalPaginas = Math.Max(1, (int)Math.Ceiling((double)_totalRegistros / TamanhoPagina));
            btnAnterior.Enabled = _paginaAtual > 1;
            btnProxima.Enabled = _paginaAtual < totalPaginas;
            lblPaginacao.Text = $"Página {_paginaAtual} de {totalPaginas}";
        }

        private async void Grid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var agendaId = (int)grid.Rows[e.RowIndex].Tag!;

            if (grid.Columns[e.ColumnIndex].Name == "colDetalhes")
            {
                _main.NavegarParaDetalhes(agendaId);
            }
            else if (grid.Columns[e.ColumnIndex].Name == "colExcluir")
            {
                var confirma = MessageBox.Show("Deseja excluir esta agenda?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirma == DialogResult.Yes)
                {
                    try
                    {
                        await Program.Api.RemoverAgendaAsync(agendaId);
                        await CarregarAsync(_paginaAtual);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
