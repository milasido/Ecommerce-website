import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './OrderDetail.css';

export class OrderDetail extends Component {

    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            detail: []
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
                        detail: result
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
        );
    }

    render() {
        //take order from array
        const OID = localStorage.getItem("OID");
        const order = this.state.detail.filter(x => x.orderId == OID);
        console.log("detail", order);
        return (

            <div className="container">
                {order.map(or => (
                    <div>
                    <div className="page-header"><h1>ORDER DETAILS</h1></div>
                    <div className="bose-orderDetail">
                        <p>
                            <span className="bose-orderDetail__headerText"><b>Date:</b> {or.orderDate}</span>
                            <span className="bose-orderDetail__separator" />
                            <span className="bose-orderDetail__headerText"><b>Order number:</b> KNN20192020{or.orderId}</span>
                            <button className="bose-orderDetail__cancelButton">Cancel order</button>
                        </p>
                        <div className="bose-orderDetail__summary">
                            <p className="bose-orderDetail__summarySection">
                                <b className="bose-orderDetail__summarySectionTitle">Payment:</b>
                                Visa<br />
                                {or.cardName}<br/>
                                xxxx-xxxx-xxxx-{or.cardNumber.slice(-4)}
                            </p>

                            <p className="bose-orderDetail__summarySection">
                                <b className="bose-orderDetail__summarySectionTitle">Billing address:</b>
                                    {or.orderName}<br />
                                    {or.orderShipAddress1} {or.orderShipAddress2}<br />
                                    {or.orderShipCity}<br />
                                    {or.orderShipState} {or.orderShipZip5}-{or.orderShipZip4}<br />                              
                            </p>
                            <div className="bose-orderDetail__summarySection">
                                <b className="bose-orderDetail__summarySectionTitle">Order summary:</b>
                                <div className="bose-orderDetail__priceSummary">
                                    <div className="bose-orderDetail__priceRow">
                                            <span>Subtotal:</span><span>${(or.orderTotal-(or.orderTotal*8.5/100)).toFixed(2)}</span>
                                    </div>
                                    <div className="bose-orderDetail__priceRow">
                                        <span>Shipping:</span><span>FREE</span>
                                    </div>
                                    <div className="bose-orderDetail__priceRow">
                                            <span>Tax:</span><span>${(or.orderTotal*8.5/100).toFixed(2)}</span>
                                    </div>
                                    <div className="bose-orderDetail__priceRow">
                                            <span>Total:</span><span>${or.orderTotal.toFixed(2)}</span>
                                    </div>
                                </div>
                            </div>
                            </div>

                            {or.orderDetails.map(item => (
                                <div className="bose-orderDetail__items">
                                    <div className="bose-orderDetail__item">
                                        <div className="bose-orderDetail__itemSection bose-orderDetail__itemSection--product">
                                            <img className="bose-orderDetail__itemImage" src={item.productUrl}/>
                                            <p><b>{item.productName}</b></p>
                                            Black
                                        </div>

                                        <div className="bose-orderDetail__itemSection--status">
                                            <p><b>Quantity:</b></p>
                                            {item.quantity}
                                        </div>

                                        <div className="bose-orderDetail__itemSection--status">
                                            <p><b>Price:</b></p>
                                            ${item.salePrice}
                                        </div>

                                        <div className="bose-orderDetail__itemSection bose-orderDetail__itemSection--status">
                                            <p><b>Status:</b></p>
                                            Processing
                                        </div>

                                        <div className="bose-orderDetail__itemSection">
                                            <b>Shipping address:</b><br />
                                            {or.orderName}<br />
                                            {or.orderShipAddress1} {or.orderShipAddress2}<br />
                                            {or.orderShipCity}<br />
                                            {or.orderShipState} {or.orderShipZip5}-{or.orderShipZip4}<br />  
                                        </div>

                                        <div className="bose-orderDetail__itemSection">                                
                                            <a className="bose-orderDetail__itemAction">Return</a>
                                            <a className="bose-orderDetail__itemAction">Support</a>
                                            <a className="bose-orderDetail__itemAction">Write a review</a>
                                        </div>
                                    </div>
                                </div>
                            ))}
                        </div>
                    </div>
                ))}
            </div>
        );
    }
}