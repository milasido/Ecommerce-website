import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import AuthService from './_Services/AuthService';

import './Cart.css';

export class Cart extends Component {

    render() {       
        return (
            <div>
                <Link to="/checkout">
                    <button id="checkout"> check out </button>
                </Link>
            </div>
        );
    }
}
   