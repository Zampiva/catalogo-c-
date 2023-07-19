// src/components/Logout.js
import React from 'react';
import { useHistory } from 'react-router-dom';

const Logout = () => {
    const history = useHistory();

    const handleLogout = () => {
        // Remover o token do armazenamento local ao fazer logout
        localStorage.removeItem('token');
        delete axios.defaults.headers.common['Authorization'];
        history.push('/login'); // Redirecionar para a página de login após o logout
    };

    return (
        <div>
            <h2>Logout</h2>
            <button type="button" onClick={handleLogout}>
                Logout
            </button>
        </div>
    );
};

export default Logout;
