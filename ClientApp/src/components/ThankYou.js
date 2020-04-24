import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class ThankYou extends Component {

    render() {
        return (
            <div>
                        <div className="container" style={{marginTop: '5%'}}>
                <div className="row">
                <div className="jumbotron" style={{boxShadow: '2px 2px 4px #000000'}}>
                    <h1 className="text-center">YOUR ORDER HAS BEEN RECEIVED</h1>
                    <h3 className="text-center">Thank you for your payment, it’s processing</h3>
                    <p className="text-center">Your order # is: KNN20192020</p>
                    <p className="text-center">You can view your order history in your account information. </p>
                    <p className="text-center">If you have any question please contact our service on main website.</p>
                    <center><div className="btn-group" style={{marginTop: '50px'}}>
                    <Link to='/'>
                        <button className="btn btn-lg btn-warning">CONTINUE</button>
                    </Link>
                        
                    </div></center>
                </div>
                </div>
            </div>

                
            </div>
            
        )
    }
}