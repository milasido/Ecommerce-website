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
        this.handleIncrease = this.handleIncrease.bind(this);
        this.handleDecrease = this.handleDecrease.bind(this);
    }   

    handleIncrease(item){
        const newcart = this.state.carts.slice() //copy cart
        newcart[newcart.findIndex(i => i.productId == item.productId)].quantity++; //increase quantity of the item
        this.setState({ carts: newcart });      
        localStorage.setItem("cart", JSON.stringify(newcart));  //set new cart to local storage
    }
    handleDecrease(item){
        const newcart = this.state.carts.slice() //copy cart
        if (newcart[newcart.findIndex(i => i.productId == item.productId)].quantity > 1) {
            newcart[newcart.findIndex(i => i.productId == item.productId)].quantity--;  //decrease quantity of the item
            this.setState({ carts: newcart });
            localStorage.setItem("cart", JSON.stringify(newcart));  //set new cart to local storage
        }
       /* // if only 1 item left, remove item when decreasing
        if (newcart[newcart.findIndex(i => i.productId == item.productId)].quantity === 1) {
            this.handleRemoveItem(item);
        }*/
    }

    handleClearCart() {
        // change state carts to be null
        this.setState({ carts: [] })
        // set local storage cart to be empty array
        localStorage.setItem("cart", JSON.stringify([]));  
    }

     
    handleRemoveItem(item) {
        // remove item which has item.id from the carts array
        const newCart = this.state.carts.filter(x => x.productId != item.productId);
        console.log("cart after remove", newCart);// test newcart
        localStorage.setItem("cart", JSON.stringify(newCart));  //set new cart to local storage
        this.setState({ carts: newCart });
    }

    // cart will be stored on localstorage
    componentDidMount() {
        // convert json string to array of object
        var fixCart = JSON.parse(localStorage.getItem("cart"));
        // merge products in cart by id, add attribute quantity
        var combined = [];
        // only if user logged in and cart is not empty in the localstorage
        if (localStorage.getItem("id_token") != null && localStorage.getItem("cart") != "[]") {
            fixCart.forEach(function (a) {
                if (!this[a.productId]) {
                    this[a.productId] = {
                        productId: a.productId,
                        productName: a.productName,
                        productPrice: a.productPrice,
                        productImageUrl: a.productImageUrl,
                        productInformation: a.productInformation,
                        quantity: 0
                    };
                    combined.push(this[a.productId]);
                }
                this[a.productId].quantity += a.quantity;
            }, Object.create(null));

            console.log("cart after combined", combined);
            // set new combined cart
            localStorage.setItem("cart", JSON.stringify(combined));
            // set state for new cart after merging
            this.setState({ carts: combined });
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
                <CartItem carts={this.state.carts} handleRemoveItem={this.handleRemoveItem} handleIncrease={this.handleIncrease} handleDecrease={this.handleDecrease}/>
                <CartTotal handleClearCart={this.handleClearCart} carts={this.state.carts}/>
            </Fragment>
        );
    }
}
   