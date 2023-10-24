import React from "react";
import TitlePage from "../../components/TitlePage";
import { InputGroup, FormControl, Button } from "react-bootstrap";
import { useState } from "react";
import { useNavigate } from "react-router-dom";

const clientes = [
  {
    id: 1,
    nome: "Microsoft",
    responsavel: "Otto",
    contato: "10665544",
    situacao: "Ativo",
  },
  {
    id: 2,
    nome: "Amazon",
    responsavel: "Kevin",
    contato: "97453587",
    situacao: "Ativo",
  },
  {
    id: 3,
    nome: "Google",
    responsavel: "John",
    contato: "12447789",
    situacao: "Ativo",
  },
  {
    id: 4,
    nome: "Facebook",
    responsavel: "Michael",
    contato: "12354569",
    situacao: "Ativo",
  },
  {
    id: 5,
    nome: "Twitter",
    responsavel: "Jack",
    contato: "00226548",
    situacao: "Ativo",
  },
];

export default function ClienteLista() {
  const navigate = useNavigate();  
  const [termoBusca, setTermoBusca] = useState("");
  const handleInputChange = (e) => {
    setTermoBusca(e.target.value);
  };

  const clientesFiltrados = clientes.filter((cliente) => {
    return (
      // cliente.nome.toLocaleLowerCase().indexOf(termoBusca) !== -1 ||
      // cliente.responsavel.toLocaleLowerCase().indexOf(termoBusca) !== - 1 ||
      // cliente.contato.toLocaleLowerCase().indexOf(termoBusca) !== - 1 ||
      // cliente.situacao.toLocaleLowerCase().indexOf(termoBusca) !== - 1
      Object.values(cliente)
        .join(" ")
        .toLowerCase()
        .includes(termoBusca.toLowerCase()) // filtra por todas as colunas do grid
    );
  });
  
  return (
    <>
      <TitlePage title="Cliente Lista">
        <Button variant="outline-secondary" onClick={() => navigate('/cliente/detalhe')}>
          <i className="fas fa-plus me-2"></i>
          Novo Cliente
        </Button>
      </TitlePage>

      <InputGroup className="mb-3 mt-3">
        <InputGroup.Text>Buscar</InputGroup.Text>
        <FormControl
          onChange={handleInputChange}
          placeholder="Buscar por nome do cliente"
        ></FormControl>
      </InputGroup>

      <table className="table table-striped table-hover">
        <thead className="table-dark mt-3">
          <tr>
            <th scope="col">#</th>
            <th scope="col">Nome</th>
            <th scope="col">Responsável</th>
            <th scope="col">Contato</th>
            <th scope="col">Situação</th>
            <th scope="col">Opções</th>
          </tr>
        </thead>
        <tbody>
          {clientesFiltrados.map((cliente) => (
            <tr key={cliente.id}>
              <td>{cliente.id}</td>
              <td>{cliente.nome}</td>
              <td>{cliente.responsavel}</td>
              <td>{cliente.contato}</td>
              <td>{cliente.situacao}</td>
              <td>
                <button className="btn btn-sm btn-outline-primary me-2" 
                        onClick={() => navigate(`/cliente/detalhe/${cliente.id}`)}>
                  <i className="fas fa-user-edit me-2"></i>Editar
                </button>
                <button className="btn btn-sm btn-outline-danger me-2">
                  <i className="fas fa-user-times me-2"></i>Desativar
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}
