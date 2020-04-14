import React, { Component } from 'react';
import AuthService from './_Services/AuthService';
import axios from 'axios';



export class Details extends Component {
    constructor(props) {
        super(props);
    }


    componentDidMount() {
        //get id from profile after login
        if (this.state.isLogin == true) {
            const id = JSON.parse(localStorage.getItem("profile")).CustomerId;
            axios.get("/api/users/" + id)
                .then(res => {
                    this.setState({ user: res.data })
                })
                .catch(function (error) {
                    console.log('Fetch error: ' + error.message);
                });
        }
    }


    render() {
        const user = this.state.user;
        if (this.state.isLogin == false) {
            return <div>Please login to see your account...</div>;
        } else {
            return (
                <div>
                    {user.fullname}<br />
                    {user.email}<br />
                    {user.address1}<br />
                    {user.address2}<br />
                    {user.city}<br />
                    {user.state}<br />
                    {user.zip5}<br />
                    {user.zip4}<br />
                    <button>Order History</button>
                </div>
            );
        }
    }

}