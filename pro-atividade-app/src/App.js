import { useEffect, useState } from 'react';
import './App.css';
import AtividadeForm from './components/AtividadeForm';
import AtividadeLista from './components/AtividadeLista';

function App() {
  const [index, setIndex] = useState(0);
  const [atividades, setAtividades] = useState([]);
  const [atividade, setAtividade] = useState({id: 0});

  useEffect(() => {
    atividades.length <= 0 ? setIndex(1) : setIndex(Math.max.apply(Math, atividades.map(item => item.id)) + 1);
  }, [atividades])

  function addAtividade(ativ) {
    setAtividades([...atividades, { ...ativ, id: index }]);
  }

  function atualizarAtividade(ativ) {
    setAtividades(atividades.map(item => item.id === ativ.id ? ativ : item));
    setAtividade({ id: 0 });
  }

  function cancelarAtividade() {
    setAtividade({ id: 0 });
  }

  function deletarAtividade(id) {
    const atividadesFiltradas = atividades.filter(atividade => atividade.id !== id);
    setAtividades([...atividadesFiltradas]);
  }

  function pegarAtividade(id) {
    const atividade = atividades.filter(atividade => atividade.id === id);
    setAtividade(atividade[0]);
  }

  return (
    <>
      <AtividadeForm addAtividade={addAtividade} atividades={atividades} ativSelecionada={atividade}
        atualizarAtividade={atualizarAtividade} cancelarAtividade={cancelarAtividade}></AtividadeForm>
      <AtividadeLista deletarAtividade={deletarAtividade} pegarAtividade={pegarAtividade}
        atividades={atividades}></AtividadeLista>
    </>
  );
}

export default App;