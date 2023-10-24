import './App.css';
import { Routes, Route } from 'react-router-dom';
import Atividade from "./pages/atividades/Atividade";
import Cliente from './pages/clientes/Cliente';
import ClienteForm from './pages/clientes/ClienteForm';
import Dashboard from './pages/dashboard/Dashboard';
import PageNotFound from './pages/PageNotFound';

export default function App() {
  return (
    <Routes>
      <Route path='/' element={<Dashboard />} />
      <Route path='/atividade/lista' element={<Atividade />} />
      <Route path='/cliente/lista' element={<Cliente />} />
      {/*:id? parâmetro opcional* - abre a rota "/cliente/detalhe/" e "/cliente/detalhe/1" */}
      <Route path='/cliente/detalhe/:id?' element={<ClienteForm />} />
      <Route path='*' element={<PageNotFound />} />
    </Routes>
  );
}