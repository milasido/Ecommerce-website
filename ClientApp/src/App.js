import React, { Component, Fragment } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Validate } from './components/Validate';
import { Counter } from './components/Counter';
import { Login } from './components/Login';
import { Signup } from './components/Signup';
import { NavMenu } from './components/NavMenu';




import './custom.css'






export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        if (localStorage.getItem('id_token') == null)
            this.state = { isLogin: false };
        else
            this.state = { isLogin: true };
        this.handleStatus = this.handleStatus.bind(this);
    }

    handleStatus() {
        if (this.state.isLogin == true)
            localStorage.removeItem('id_token');
        if (localStorage.getItem('id_token') == null)
            this.setState({ isLogin: !this.state.isLogin })
    }
   
  render () {
      return (
        <Fragment>
        <NavMenu handleStatus={this.handleStatus} isLogin={this.state.isLogin}/>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/validate' component={Validate} />
        <Route path='/login' component={Login} handleStatus={this.handleStatus} isLogin={this.state.isLogin}/>
        <Route path='/signup' component={Signup} />
        </Fragment>
    );
  }
}
