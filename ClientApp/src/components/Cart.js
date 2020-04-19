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
        this.handleClearCart = this.handleClearCart.bind(this);
        this.handleRemoveItem = this.handleRemoveItem.bind(this);
        this.handleTotal = this.handleTotal.bind(this);
    }   

    handleTotal() {
        
    }

    handleClearCart() {
        // change state carts to be null
        this.setState({ carts: [] })
        // set local storage cart to be empty array
        localStorage.setItem("cart", JSON.stringify([]));  
    }

     
    handleRemoveItem(item) {
        // remove item which has item.id from the carts array
        const newCart = this.state.carts.filter(x => x.producId != item.producId);
        console.log("new cart", newCart);// test newcart
        localStorage.setItem("cart", JSON.stringify(newCart));  //set new cart to local storage
        this.setState({ carts: newCart });
    }

    // cart will be stored on localstorage
    componentDidMount() {
        // convert json string to array of object
        var fixCart = JSON.parse(localStorage.getItem("cart"));
        // merge products in cart by id, add attribute quantity
        var result = [];
        // only if user logged in and cart is not empty in the localstorage
        if (localStorage.getItem("id_token") != null && localStorage.getItem("cart")!="[]") {
            fixCart.forEach(function (a) {
                if (!this[a.productId]) {
                    this[a.productId] = {
                        producId: a.productId,
                        productName: a.productName,
                        productPrice: a.productPrice,
                        productImageUrl: a.productImageUrl,
                        productInformation: a.productInformation,
                        quantity: 0
                    };
                    result.push(this[a.productId]);
                }
                this[a.productId].quantity += a.quantity;
            }, Object.create(null));

            console.log("cartafter", result);

            // set state for new cart after merging
            this.setState({ carts: result });
        }
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
                <CartItem carts={this.state.carts} handleRemoveItem={this.handleRemoveItem}/>
                <CartTotal handleClearCart={this.handleClearCart} carts={this.state.carts}/>
            </Fragment>
        );
    }
}
   