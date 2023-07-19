// src/App.js
import React from 'react';
import { BrowserRouter as Router, Switch, Route, Redirect } from 'react-router-dom';
import Login from './components/Login';
import VeiculoList from './components/VeiculoList';
import VeiculoForm from './components/VeiculoForm';
import Logout from './components/Logout';

const App = () => {
    const isAuthenticated = !!localStorage.getItem('token'); // Verificar se o usuário está autenticado

    return (
        <Router>
            <div>
                <Switch>
                    <Route exact path="/">
                        {isAuthenticated ? <Redirect to="/veiculos" /> : <Redirect to="/login" />}
                    </Route>
                    <Route path="/login" component={Login} />
                    {isAuthenticated && (
                        <>
                            <Route path="/veiculos" component={VeiculoList} />
                            <Route path="/veiculo/cadastro" component={VeiculoForm} />
                            <Route path="/veiculo/editar/:id" component={VeiculoForm} />
                            <Route path="/logout" component={Logout} />
                        </>
                    )}
                    {/* Redirecionar para a página de login se a rota não existir */}
                    <Route path="*">
                        <Redirect to="/login" />
                    </Route>
                </Switch>
            </div>
        </Router>
    );
};

export default App;
