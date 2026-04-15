import { NavLink, Route, Routes, Navigate } from 'react-router-dom';
import CriarAgendaPage from './pages/CriarAgendaPage';
import AgendasListPage from './pages/AgendasListPage';
import AgendaDetalhesPage from './pages/AgendaDetalhesPage';
import MedicosListPage from './pages/MedicosListPage';

export default function App() {
  return (
    <div className="app">
      <aside className="sidebar">
        <h1>Agendamento Hospitalar</h1>
        <NavLink to="/criar-agenda" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>
          Gerar Agenda
        </NavLink>
        <NavLink to="/agendas" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>
          Agendas
        </NavLink>
        <NavLink to="/medicos" className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}>
          Médicos
        </NavLink>
      </aside>
      <main className="content">
        <Routes>
          <Route path="/" element={<Navigate to="/criar-agenda" replace />} />
          <Route path="/criar-agenda" element={<CriarAgendaPage />} />
          <Route path="/agendas" element={<AgendasListPage />} />
          <Route path="/agendas/:id" element={<AgendaDetalhesPage />} />
          <Route path="/medicos" element={<MedicosListPage />} />
        </Routes>
      </main>
    </div>
  );
}
