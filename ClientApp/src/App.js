import React, { Component, Fragment } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Validate } from './components/Validate';
import { Counter } from './components/Counter';
import { Login } from './components/Login';
import { Signup } from './components/Signup';
import { NavMenu } from './components/NavMenu';
import { Cart } from './components/Cart';




import './custom.css'






export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        if (localStorage.getItem('id_token') == null) // no token in local storage
            this.state = { isLogin: false };
        else
            this.state = { isLogin: true };
        this.handleStatus = this.handleStatus.bind(this);
    }
    // handle status logged in or logged out of page
    handleStatus() {
        if (localStorage.getItem('id_token') != null) {
            localStorage.removeItem('id_token');
            this.setState({ isLogin: !this.state.isLogin });
        }
        if (localStorage.getItem('id_token') != null && this.state.isLogin==true) {
            console.log("login work");
            this.setState({ isLogin: !this.state.isLogin });
        }
    }
   
  render () {
      return (
        <Fragment>
        <NavMenu handleStatus={this.handleStatus} isLogin={this.state.isLogin}/>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/validate' component={Validate} />
        <Route path='/login' render={
                props => <Login {...props} handleStatus={this.handleStatus} />
            }/>
        <Route path='/signup' component={Signup} />
         <Route path='/cart' component={Cart} />


        </Fragment>
    );
  }
}
