import React, { Component } from 'react';
import AuthService from './_Services/AuthService';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import axios from 'axios';
import './Checkout.css';
import { Container } from 'reactstrap';
import CartItem from './CartData/CartItem';
import CartTotal from './CartData/CartTotal';
import { Cart } from './Cart';
import { Link } from 'react-router-dom';

export class Checkout extends Component {

    /*    constructor(props) {
            super(props)*/
    state = {
        Name: '', NameError: "",
        Address1: '', Address1Error: "",
        Address2: '', Address2Error: "",
        City: '', CityError: "",
        State: '', StateError: "",
        Zip5: '', Zip5Error: "",
        Zip4: '', Zip4Error: "",
        ValidateResult: {},
        cardname: "", CardNameError: "",
        cartnumber: "", CardNumberError: "",
        expmonth: "", ExpMonthError: "",
        expyear: "", ExpYearError: "",
        cvv: "", CvvError: ""
    }
    /*this.handleChange = this.handleChange.bind(this);
    this.handleValidate = this.handleValidate.bind(this);*/

    handleChange = (event) => {
        this.setState({ [event.target.name]: event.target.value })
    }

    handleClick = () => {
        const isValid = this.handleCheckPay();
        console.log(isValid)
        console.log(this.state.ValidateResult.address1)
        if (isValid && this.state.ValidateResult.address1 !== null) {
            localStorage.setItem("confirm", JSON.stringify(this.state));
            this.props.history.push('/confirm');
        }
    }

    handleCheckShip = () => {
        let NameError = "", Address1Error = "";

        if (!this.state.Name) NameError = "* Name cannot be blank";
        if (!this.state.Address1) Address1Error = "* Address cannot be blank";


        if (NameError || Address1Error) {
            this.setState({ NameError: NameError, Address1Error: Address1Error });
            return false;
        } else {
            this.setState({ NameError: "", Address1Error: "" });
            return true;
        }
    }
    handleCheckPay = () => {
        let CardNameError = "", CardNumberError = "", ExpMonthError = "", ExpYearError = "", CvvError = "";

        if (!this.state.cardname) CardNameError = "* Card Name cannot be blank";
        if (!this.state.cardnumber) CardNumberError = "* Card Number cannot be blank";
        if (!this.state.expmonth) ExpMonthError = "* Exp Month cannot be blank";
        if (!this.state.expyear) ExpYearError = "* Exp Year cannot be blank";
        if (!this.state.cvv) CvvError = "* Cvv cannot be blank";
        if (this.state.cartnumber.match(/^[0-9]+$/) != null) CardNumberError = "* Please put 16 numbers from your card";

        if (CardNameError || CardNumberError || ExpMonthError || ExpYearError || CvvError) {
            this.setState({ CardNameError: CardNameError, CardNumberError: CardNumberError, ExpMonthError: ExpMonthError, ExpYearError: ExpYearError, CvvError: CvvError });
            return false;
        } else {
            this.setState({ CardNameError: "", CardNumberError: "", ExpMonthError: "", ExpYearError: "", CvvError: "" });
            return true;
        }
    }

    //get user info first
    componentDidMount() {
        //get id from profile after login

        const id = JSON.parse(localStorage.getItem("profile")).CustomerId;
        axios.get("/api/users/" + id)
            .then(res => {
                this.setState({ Name: res.data.fullname, Address1: res.data.address1, Address2: res.data.address2, City:res.data.city, State:res.data.state, Zip5:res.data.zip5, Zip4:res.data.zip4 })
            })
            .catch(function (error) {
                console.log('Fetch error: ' + error.message);
            });

    }

    handleValidate = event => {
        event.preventDefault();
        //console.log(this.state) 
        const isValid = this.handleCheckShip();
        if (isValid) {
            axios.post('/api/validate/validate', this.state)
                .then(response => {
                    this.setState({ ValidateResult: response.data });
                    localStorage.setItem("ship", JSON.stringify(response.data));
                    console.log(this.state.ValidateResult)
                })
                .catch(error => {
                    console.log(error)
                })
        }
    };

    render() {
        const { Name, Address1, Address2, City, State, Zip5, Zip4, cardname, cardnumber, expmonth, expyear, cvv } = this.state;
        const cart = JSON.parse(localStorage.getItem("cart"));
        const sub = cart.reduce((sum, i) => (sum += i.quantity * i.productPrice), 0);
        const tax = sub * 8.5 / 100;
        const total = sub + tax;
        return (
            <div className="row rrr">
                {/*<div className="page-header" style={{ marginLeft: '50px' }}><h1>CHECKOUT INFORMATION</h1></div>*/}
                <div className="col-75 c75">
                    <div className="container ctn">
                        <form onSubmit={this.handleValidate}>

                            <div className="row rrr">
                                <div className="col-50 c50">
                                    <h3>Shipping Address</h3>
                                    <label><i className="fa fa-user"></i> Full Name</label>
                                    <input onChange={this.handleChange} value={Name} defaultValue={Name} type="text1" id="fname" name="Name" placeholder="John M. Doe" />
                                    <div style={{ fontSize: 12, color: "red" }}>{this.state.NameError}</div>
                                    <label><i className="fa fa-address-card-o"></i> Address 1</label>
                                    <input onChange={this.handleChange} value={Address1}  defaultValue={Address1} type="text1" id="adr1" name="Address1" placeholder="542 W. 15th Street" />
                                    <div style={{ fontSize: 12, color: "red" }}>{this.state.Address1Error}</div>
                                    <label><i className="fa fa-address-card-o"></i> Address 2 (optional)</label>
                                    <input onChange={this.handleChange} value={Address2} defaultValue={Address2} type="text1" id="adr2" name="Address2" placeholder="Apt 123" />
                                    <label><i className="fa fa-institution"></i> City</label>
                                    <input onChange={this.handleChange} value={City} defaultValue={City}  type="text1" id="city" name="City" placeholder="New York" />

                                    <div className="row rrr">
                                        <div className="col-50 c50">
                                            <label>State</label>
                                            <input onChange={this.handleChange} value={State} defaultValue={State} type="text1" id="state" name="State" placeholder="NY" />
                                        </div>
                                        <div className="col-50 c50">
                                            <label>Zip 5</label>
                                            <input onChange={this.handleChange} value={Zip5} defaultValue={Zip5} type="text1" id="zip" name="Zip5" placeholder="10001" />
                                        </div>
                                        <div className="col-50 c50">
                                            <label>Zip 4</label>
                                            <input onChange={this.handleChange} value={Zip4} defaultValue={Zip4}  type="text1" id="zip4" name="Zip4" placeholder="1111" />
                                        </div>
                                    </div>
                                </div>

                                <div className="col-50 c50">
                                    <h3>Payment</h3>
                                    <label>Accepted Cards</label>
                                    <div className="icon-container">
                                        <i id="visa" className="fa fa-cc-visa" >   </i>
                                        <i id="amex" className="fa fa-cc-amex" >   </i>
                                        <i id="mastercard" className="fa fa-cc-mastercard" >   </i>
                                        <i id="discover" className="fa fa-cc-discover" >   </i>
                                    </div>
                                    <label>Name on Card</label>
                                    <input onChange={this.handleChange} value={cardname} type="text1" id="cname" name="cardname" placeholder="John More Doe" />
                                    <div style={{ fontSize: 12, color: "red" }}>{this.state.CardNameError}</div>
                                    <label>Credit card number</label>
                                    <input onChange={this.handleChange} value={cardnumber} type="text1" id="ccnum" name="cardnumber" placeholder="1111-2222-3333-4444" />
                                    <div style={{ fontSize: 12, color: "red" }}>{this.state.CardNumberError}</div>
                                    <label>Exp Month</label>
                                    <input onChange={this.handleChange} value={expmonth} type="text1" id="expmonth" name="expmonth" placeholder="September" />
                                    <div style={{ fontSize: 12, color: "red" }}>{this.state.ExpMonthError}</div>
                                    <div className="row rrr">
                                        <div className="col-50 c50">
                                            <label>Exp Year</label>
                                            <input onChange={this.handleChange} value={expyear} type="text1" id="expyear" name="expyear" placeholder="2018" />
                                            <div style={{ fontSize: 12, color: "red" }}>{this.state.ExpYearError}</div>
                                        </div>
                                        <div className="col-50 c50">
                                            <label>CVV</label>
                                            <input onChange={this.handleChange} value={cvv} type="text1" id="cvv" name="cvv" placeholder="352" />
                                            <div style={{ fontSize: 12, color: "red" }}>{this.state.CvvError}</div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <label>
                                <input type="checkbox" checked="checked" name="sameadr" /> Billing address same as billing
                            </label>

                            <button type="submit" className="btn btn-primary">validate</button>

                            {this.state.ValidateResult.address1 != "" && // able to return result
                                <div>
                                    <div className="panel panel-default">
                                        <div className="panel-heading">Your Shipping Address Validated: </div>
                                        <div className="panel-body">
                                            {this.state.ValidateResult.name} <br />
                                            {this.state.ValidateResult.address1} <br />
                                            {this.state.ValidateResult.address2} <br />
                                            {this.state.ValidateResult.city} <br />
                                            {this.state.ValidateResult.state} <br />
                                            {this.state.ValidateResult.zip5}-{this.state.ValidateResult.zip4}
                                        </div>
                                    </div>
                                </div>
                            }
                            {this.state.ValidateResult.address1 == "" && // return null if couldn't validate                              
                                <div style={{ fontSize: 14, color: "red", textAlign: "center" }}><br/>* Cannot validate your address, please type it correcty to continuous check out<br/></div>
                            }


                            {/*<input type="submit" value="Continue to checkout" className="btnnn" />*/}

                            <button style={{textAlign: "center"}} className="btn-block" id="continue-checkout" onClick={() => this.handleClick() }>Continue to checkout</button>

                        </form>
                    </div>
                </div>

                <div className="col-25 ccc">
                    <div className="container">
                        <p2 className="page-header">YOUR CART</p2>
                        <table className="table">
                            <thead>
                                <tr>
                                    <th scope="col">Items</th>
                                    <th scope="col">Quantity</th>
                                    <th scope="col">Price</th>
                                </tr>
                            </thead>
                            <tbody>
                                {cart.map(item => (
                                    <tr>
                                        <td>{item.productName}</td>
                                        <td>{item.quantity}</td>
                                        <td>{item.productPrice}</td>
                                    </tr>
                                ))}
                                <div className="bose-orderDetail__summarySection">
                                    <b className="bose-orderDetail__summarySectionTitle">Order summary:</b>
                                <div className="bose-orderDetail__priceRow">
                                    <span>Subtotal:</span><span>${sub.toFixed(2)}</span>
                                </div>
                                <div className="bose-orderDetail__priceRow">
                                    <span>Shipping:</span><span>FREE</span>
                                </div>
                                <div className="bose-orderDetail__priceRow">
                                    <span>Tax:</span><span>${tax.toFixed(2)}</span>
                                </div>
                                <div className="bose-orderDetail__priceRow">
                                    <span>Total:</span><span>${total.toFixed(2)}</span>
                                </div>
                                </div>
                            </tbody>
                        </table>

                    </div>
                </div>
            </div>

        );
    }
}
