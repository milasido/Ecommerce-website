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
            items: [],
            paid: false
        }
    }
    componentDidMount() {
        fetch("/api/Home/Products")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        items: result
                    });
                },
                // Note: it's important to handle errors here
                // instead of a catch() block so that we don't swallow
                // exceptions from actual bugs in components.
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }
            )
    }

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
   