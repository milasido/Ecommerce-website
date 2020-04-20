import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

export class Confirm extends Component {


    handleOrderHistory() {
        const id = JSON.parse(localStorage.getItem('profile')).CustomerId;
        var itemsPaid = JSON.parse(localStorage.getItem("cart"));
        var history = JSON.parse(localStorage.getItem("ship"));
        history.detail = itemsPaid; // add paid items into history object
        console.log("history to post", history);
        localStorage.setItem("order", JSON.stringify(history));

        axios.post('/api/users/'+ id +'/savehistory', history);
    }




    render() {
        return (
            <div>
                <h1>Confirm your purchase</h1>

                <Link to='/thankyou'>
                    <button onClick={()=>this.handleOrderHistory()}>Purchase</button>
                </Link>
            </div>
        );
    }
}