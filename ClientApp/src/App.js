import React, { Component, Fragment } from 'react';
import { Route } from 'react-router';
import { Home } from './components/Home';
import { Validate } from './components/Validate';
import { Counter } from './components/Counter';
import { Login } from './components/Login';
import { Signup } from './components/Signup';
import { NavMenu } from './components/NavMenu';
import { Cart } from './components/Cart';
import { Account } from './components/Account';
import { Checkout } from './components/Checkout';
import { Confirm } from './components/Confirm';
import { OrderHistory } from './components/OrderHistory';
import "react-notification-alert/dist/animate.css";
import './custom.css'
import axios from 'axios';
import { ThankYou } from './components/ThankYou';
import { OrderDetail } from './components/OrderDetail';
import { ProductDetail } from './components/ProductDetail';


export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        if (localStorage.getItem('id_token') === null) // no token in local storage
            this.state = {
                isLogin: false,
            };
        else
            this.state = {
                isLogin: true,
                cartChange: false
            };
        this.handleLogout = this.handleLogout.bind(this);
        this.handleLogin = this.handleLogin.bind(this);
        this.addToCart = this.addToCart.bind(this);
        this.handleSaveCart = this.handleSaveCart.bind(this);
        this.handleLastLogin = this.handleLastLogin.bind(this);
    }

    addToCart(item) {
        if (this.state.isLogin === true) { // if loggin
            if (localStorage.getItem("cart") !== "[]") {
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
        const id = JSON.parse(localStorage.getItem('profile')).CustomerId;
        axios.post(('/api/users/' + id + '/savecart'), JSON.parse(cartSave));
    }
    //handle lastlogin
    handleLastLogin() {
        const id = JSON.parse(localStorage.getItem('profile')).CustomerId;
        axios.post('/api/users/'+id+'/lastlogin'); // update last login in database
    }

    // handle logout or loggin when click
    handleLogout() {
        if (localStorage.getItem('id_token') !== null) { // if logged in
            this.handleSaveCart(); // update current cart to database when logging out
            this.handleLastLogin();
            localStorage.removeItem('id_token');
            localStorage.removeItem('profile');
            localStorage.removeItem('cart');
            localStorage.removeItem('ship');
            localStorage.removeItem('confirm');
            localStorage.removeItem('PID');
            localStorage.removeItem('OID');
            this.setState({ isLogin: !this.state.isLogin });
        }      
    }

    handleLogin() {
            console.log("login is working");
            this.setState({ isLogin: !this.state.isLogin });
    }

    render() {
        return (
            <Fragment>

                <NavMenu handleLogout={this.handleLogout} isLogin={this.state.isLogin} />

                <Route exact path='/' render={props => <Home {...props} addToCart={this.addToCart} />} />

                <Route path='/counter' component={Counter} />

                <Route path='/validate' component={Validate} />

                <Route path='/login' render={props => <Login {...props} handleLogin={this.handleLogin} />} />
                <Route path='/account' render={props => <Account {...props} isLogin={this.state.isLogin} />} />
                <Route path='/signup' component={Signup} />

                <Route path='/checkout' component={Checkout} />

                <Route path='/cart' render={props => <Cart {...props} isLogin={this.state.isLogin} cartChange={this.state.cartChange} />} />
                <Route path='/thankyou' component={ThankYou} />
                <Route path='/confirm' component={Confirm} />
                <Route path='/history' component={OrderHistory} />
                <Route path='/orderdetail' component={OrderDetail} />
                <Route path='/productdetail' component={ProductDetail} />


            </Fragment>
        );
    }
}
