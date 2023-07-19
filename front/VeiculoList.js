// src/components/VeiculoList.js
import React, { useState, useEffect } from 'react';
import axios from 'axios';

const VeiculoList = () => {
    const [veiculos, setVeiculos] = useState([]);

    useEffect(() => {
        axios.get('/api/veiculos')
            .then((response) => setVeiculos(response.data))
            .catch((error) => console.error('Error fetching veiculos', error));
    }, []);

    return (
        <div>
            <h2>Lista de Veículos</h2>
            <ul>
                {veiculos.map((veiculo) => (
                    <li key={veiculo.id}>
                        <strong>{veiculo.nome}</strong> - {veiculo.marca} {veiculo.modelo}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default VeiculoList;
