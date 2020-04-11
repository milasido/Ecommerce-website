import React, { Component } from 'react';
import AuthService from './_Services/AuthService';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import './Checkout.css';
import { Container } from 'reactstrap';

export class Checkout extends Component {

    render() {

        return (
            <Container class="row rrr">
                <div class="col-75 c75">
                    <div class="container ctn">
                        <form action="/action_page.php">

                            <div class="row rrr">
                                <div class="col-50 c50">
                                    <h3>Billing Address</h3>
                                    <label for="fname"><i class="fa fa-user"></i> Full Name</label>
                                    <input type="text1" id="fname" name="firstname" placeholder="John M. Doe" />
                                    <label for="email"><i class="fa fa-envelope"></i> Email</label>
                                    <input type="text1" id="email" name="email" placeholder="john@example.com" />
                                    <label for="adr"><i class="fa fa-address-card-o"></i> Address</label>
                                    <input type="text1" id="adr" name="address" placeholder="542 W. 15th Street" />
                                    <label for="city"><i class="fa fa-institution"></i> City</label>
                                    <input type="text1" id="city" name="city" placeholder="New York" />

                                    <div class="row rrr">
                                        <div class="col-50 c50">
                                            <label for="state">State</label>
                                            <input type="text1" id="state" name="state" placeholder="NY" />
                                        </div>
                                        <div class="col-50 c50">
                                            <label for="zip5">Zip 5</label>
                                            <input type="text1" id="zip" name="zip" placeholder="10001" />
                                        </div>
                                        <div class="col-50 c50">
                                            <label for="zip4">Zip 4</label>
                                            <input type="text1" id="zip4" name="zip4" placeholder="1111" />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-50 c50">
                                    <h3>Payment</h3>
                                    <label for="fname">Accepted Cards</label>
                                    <div class="icon-container">
                                        <i id="visa" class="fa fa-cc-visa" >   </i>
                                        <i id="amex" class="fa fa-cc-amex" >   </i>
                                        <i id="mastercard" class="fa fa-cc-mastercard" >   </i>
                                        <i id="discover" class="fa fa-cc-discover" >   </i>
                                    </div>
                                    <label for="cname">Name on Card</label>
                                    <input type="text1" id="cname" name="cardname" placeholder="John More Doe" />
                                    <label for="ccnum">Credit card number</label>
                                    <input type="text1" id="ccnum" name="cardnumber" placeholder="1111-2222-3333-4444" />
                                    <label for="expmonth">Exp Month</label>
                                    <input type="text1" id="expmonth" name="expmonth" placeholder="September" />

                                    <div class="row rrr">
                                        <div class="col-50 c50">
                                            <label for="expyear">Exp Year</label>
                                            <input type="text1" id="expyear" name="expyear" placeholder="2018" />
                                        </div>
                                        <div class="col-50 c50">
                                            <label for="cvv">CVV</label>
                                            <input type="text1" id="cvv" name="cvv" placeholder="352" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <label>
                                <input type="checkbox" checked="checked" name="sameadr" /> Shipping address same as billing
                            </label>
                            <input type="submit" value="Continue to checkout" class="btnnn" />
                        </form>
                    </div>
                </div>

                <div class="col-25 ccc">
                    <div class="container">
                        <h4>Cart
                            <span id="pr" class="price" >
                                <i class="fa fa-shopping-cart"></i>
                                <b>4</b>
                            </span>
                        </h4>
                        <p><a href="#">Product 1</a> <span class="price">$15</span></p>
                        <p><a href="#">Product 2</a> <span class="price">$5</span></p>
                        <p><a href="#">Product 3</a> <span class="price">$8</span></p>
                        <p><a href="#">Product 4</a> <span class="price">$2</span></p>
                        <hr/>
                            <p>Total <span id="pr" class="price" ><b>$30</b></span></p>
                    </div>
                    </div>
            </Container>
            );
        }
    }
