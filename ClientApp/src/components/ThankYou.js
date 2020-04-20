import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class ThankYou extends Component {

    render() {
        return (
            <div>
                Thank you for your purchase!
                To see you purchase please go to your order history in user account!
                <Link to='/'>
                    <button>Home page</button>
                </Link>
            </div>
        )
    }
}