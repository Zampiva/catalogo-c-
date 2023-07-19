// src/components/VeiculoForm.js
import React, { useState } from 'react';
import axios from 'axios';

const VeiculoForm = () => {
    const [nome, setNome] = useState('');
    const [marca, setMarca] = useState('');
    const [modelo, setModelo] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const newVeiculo = {
                nome,
                marca,
                modelo,
            };

            await axios.post('/api/veiculos', newVeiculo);
            // Lógica para redirecionar após criação bem-sucedida, caso necessário
        } catch (error) {
            console.error('Error creating veiculo', error);
        }
    };

    return (
        <div>
            <h2>Cadastro de Veículo</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Nome"
                    value={nome}
                    onChange={(e) => setNome(e.target.value)}
                />
                <input
                    type="text"
                    placeholder="Marca"
                    value={marca}
                    onChange={(e) => setMarca(e.target.value)}
                />
                <input
                    type="text"
                    placeholder="Modelo"
                    value={modelo}
                    onChange={(e) => setModelo(e.target.value)}
                />
                <button type="submit">Criar Veículo</button>
            </form>
        </div>
    );
};

export default VeiculoForm;
