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
            cartChange: this.props.cartChange,
            carts: [],
            paid: false
        }
    }   


    componentDidMount() {
        this.setState({ carts: JSON.parse('['+localStorage.getItem("cart")+']') });
    }

    render() {
        const { carts, paid, isLogin } = this.state;
        console.log(carts);
        if (isLogin == false)
            return (<p1> Please login to see your cart! </p1>)
        else if (carts[0] == null)
            return (<p1> Your cart is empty! </p1>)
        else return (
            <Fragment>
                <CartColumns />
                <CartItem carts={this.state.carts}/>
                <CartTotal/>
            </Fragment>
        );
    }
}
   