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
import { Account } from './components/Account';
import { Checkout } from './components/Checkout';



import './custom.css'
import axios from 'axios';



export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        if (localStorage.getItem('id_token') == null) // no token in local storage
            this.state = {
                isLogin: false,
            };
        else
            this.state = {
                isLogin: true,
                cartChange: false
            };
        this.handleStatus = this.handleStatus.bind(this);
        this.addToCart = this.addToCart.bind(this);
        this.handleSaveCart = this.handleSaveCart.bind(this);
    }

    addToCart(item) {
        if (this.state.isLogin == true) { // if loggin
            if (localStorage.getItem("cart") != "[]") {
                var myJsonObject = JSON.parse(item); //change to obj
                myJsonObject.quantity = 1; //add quantity
                myJsonObject = JSON.stringify(myJsonObject); //change back to string
                var items = localStorage.getItem("cart").slice(0, -1).concat(',' + myJsonObject) + "]"; // set as array string
                localStorage.setItem("cart", items); // add array cart to localstorage
            }
            else {
                var myJsonObject = JSON.parse(item); //change to obj
                myJsonObject.quantity = 1; //add quantity
                myJsonObject = "[" + JSON.stringify(myJsonObject) + "]"; //change back to string
                localStorage.setItem("cart", myJsonObject);
            }
        }
    }

    //save cart
    handleSaveCart() {
        const cartSave = localStorage.getItem('cart');
        if (cartSave != "[]") { 
            const id = JSON.parse(localStorage.getItem('profile')).CustomerId;
            axios.post(('/api/users/' + id + '/savecart'), JSON.parse(cartSave))
        }
        else console.log("cart null", cartSave)
    }

    // handle logout or loggin when click
    handleStatus() {
        if (localStorage.getItem('id_token') != null) { // if logged in
            this.handleSaveCart();
            localStorage.removeItem('id_token');
            localStorage.removeItem('profile');
            localStorage.removeItem('cart');
            this.setState({ isLogin: !this.state.isLogin });
        }
        if (localStorage.getItem('id_token') == null) { // if not logged in
            console.log("login is working");
            this.setState({ isLogin: !this.state.isLogin });
        }
    }


  render () {
      return (
          <Fragment>

              <NavMenu handleStatus={this.handleStatus} isLogin={this.state.isLogin} />

              <Route exact path='/' render={props => <Home {...props} addToCart={this.addToCart}/>}/>

              <Route path='/counter' component={Counter} />

              <Route path='/validate' component={Validate} />

              <Route path='/login' render={props => <Login {...props} handleStatus={this.handleStatus} />} />
              <Route path='/account' render={props => <Account {...props} handleStatus={this.handleStatus} isLogin={this.state.isLogin} />} />
              <Route path='/signup' component={Signup} />

              <Route path='/checkout' component={Checkout} />

              <Route path='/cart' render={props => <Cart {...props} isLogin={this.state.isLogin} cartChange={this.state.cartChange}/>} />

        </Fragment>
    );
  }
}
