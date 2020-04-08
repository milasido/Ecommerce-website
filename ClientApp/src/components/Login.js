import React, { Component, Fragment } from 'react';
import { Link } from 'react-router-dom';
import './Login-signup.css';
import axios from 'axios';
import AuthService from './_Services/AuthService';
import { NavMenu } from './NavMenu';

export class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            password: '',
        };
        // create new authservice
        this.Auth = new AuthService();
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);

    }
    handleChange = (event) => {
        this.setState({ [event.target.name]: event.target.value })
    }
    handleSubmit = (event) => {
        event.preventDefault();
        this.Auth.login(this.state.email, this.state.password)
            .then(res => { this.props.history.push('/') })
            .catch(error => {
                alert(error);
            });
        
    }


    render() {
        return (
            <Fragment>
                <div class="wrapper fadeInDown">
                    <div id="formContent">
                        <h2 class="active"> Sign In </h2>
                        <Link to="/signup"><h2 className="inactive underlineHover">Sign Up</h2></Link>

                        <div class="fadeIn first">
                            <img src="https://cdn1.iconfinder.com/data/icons/essential-21/128/User-512.png" id="icon" alt="User Icon" />
                        </div>

                        <form onSubmit={this.handleSubmit}>
                            <input onChange={this.handleChange} value={this.state.email} type="email" id="login" class="fadeIn second" name="email" placeholder="Email" />
                            <input onChange={this.handleChange} value={this.state.password} type="password" id="password" class="fadeIn third" name="password" placeholder="Password" />
                            <input onClick={this.props.handleStatus} type="submit" class="fadeIn fourth" value="Log In" />
                        </form>

                        <div id="formFooter">
                            <a class="underlineHover" href="#">Forgot Password?</a>
                        </div>

                    </div>
                </div>
            </Fragment>
        );
    }
}
