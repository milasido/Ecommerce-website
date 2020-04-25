import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './OrderHistory.css';

export class OrderHistory extends Component {

    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            OID: 0,
            history: []
        };
    }


    componentDidMount() {
        const id = JSON.parse(localStorage.getItem('profile')).CustomerId;
        fetch("/api/users/" + id + "/ordershistory")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        history: result
                    });
                    console.log("his", result);
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
        const his = this.state.history;
        return (
            <div className="container">
                    <div>
                        <div class="page-header">
                        <h1>ORDER HISTORY <small>TOTAL ORDERS: {his.length}</small></h1>
                        </div>

                        <div class="flex-col">

                            <div class="order-history-container">
                                <div class="flex-row order-history-header">
                                    <div class="flex-item order-history-header-item order-num">ORDER #</div>
                                    <div class="flex-item order-history-header-item">ORDER DATE</div>
                                    <div class="flex-item order-history-header-item num-of-items"># OF ITEMS</div>
                                    <div class="flex-item order-history-header-item">ORDER TOTAL</div>
                                    <div class="flex-end-cap"></div>
                                </div>
                            </div>
                        {his.map(order => (
                            <Link to='/orderdetail' onClick={()=>localStorage.setItem("OID", order.orderId)}>
                            <div class="order-rows-container">                           
                                <div class="flex-row order-row">
                                    <div class="flex-item order-row-item order-num">NNP20192020{order.orderId}</div>
                                    <div class="flex-item order-row-item">{order.orderDate}</div>
                                    <div class="flex-item order-row-item num-of-items">{order.numberOfItems}</div>
                                    <div class="flex-item order-row-item">{order.orderTotal}</div>
                                    <div class="flex-end-cap"><i class="fa fa-chevron-right" aria-hidden="true"></i></div>
                                </div>
                            </div>
                            </Link>
                        ))}
                        <Link style={{textAlign:"center"}} to="/account">
                            <button  type="button" className="btn btn-success">ACCOUNT</button>
                        </Link>
                        </div>
                    </div>
            </div>
        )
    }
}