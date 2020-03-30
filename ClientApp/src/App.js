import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Validate } from './components/Validate';
import { Counter } from './components/Counter';
import { Login } from './components/Login';
import { Signup } from './components/Signup';
import { test } from './components/test';



import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/validate' component={Validate} />
        <Route path='/login' component={Login} />
            <Route path='/signup' component={Signup} />

            <Route path='/testt' component={test} />


      </Layout>
    );
  }
}
