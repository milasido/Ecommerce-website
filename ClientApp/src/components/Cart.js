import React, { Component, Fragment } from 'react';
import { Link } from 'react-router-dom';
import AuthService from './_Services/AuthService';
import CartColumns from './CartData/CartColumns';
import EmptyCart from './CartData/EmptyCart';
import CartItem from './CartData/CartItem';
import CartTotal from './CartData/CartTotal';

import './Cart.css';

export class Cart extends Component {
    constructor(props) {
        super(props)
        this.Auth = new AuthService();
    }


    render() {       
        return (
            <Fragment>
                <CartColumns />
                <CartItem/>
                <CartTotal/>
            </Fragment>
        );
    }
}
   