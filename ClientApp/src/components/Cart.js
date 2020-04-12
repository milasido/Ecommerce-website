import React, { Component, Fragment } from 'react';
import { Link } from 'react-router-dom';
import AuthService from './_Services/AuthService';
import CartColumns from './CartData/CartColumns';
import CartItem from './CartData/CartItem';
import CartTotal from './CartData/CartTotal';

import './Cart.css';

export class Cart extends Component {
    constructor(props) {
        super(props)
        this.Auth = new AuthService();
        this.state = {
            isLogin: this.props.isLogin,
            carts: [],
            paid: false
        }
 
    }

    


    /*componentDidMount() {
        window.addEventListener("cart", e => 
            this.setState({items: this.state.items.concat()})
    }*/
    

    render() {
        if (this.state.isLogin == false)
            return (<p1> Please login to see your cart! </p1>)
        else if (this.state.items[0] == null)
            return (<p1> Your cart is empty! </p1>)
        return (
            <Fragment>
                <CartColumns />
                <CartItem/>
                <CartTotal/>
            </Fragment>
        );
    }
}
   