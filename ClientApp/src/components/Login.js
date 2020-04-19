import React, { Component, Fragment } from 'react';
import { Link } from 'react-router-dom';
import './Login-signup.css';
import axios from 'axios';
import AuthService from './_Services/AuthService';
import { NavMenu } from './NavMenu';

const initialState = {
    email: '',
    password: '',
    emailError: "",
    passwordError: "",
}

export class Login extends Component {
    constructor(props) {
        super(props);
        this.state = initialState;
        // create new authservice
        this.Auth = new AuthService();
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    //handle login validation
    handleValidate = () => {
        let emailError = "", passwordError = "";
        if (!this.state.email.includes('@')) {
            emailError = "* Invalid email";
        }
        if (!this.state.email) {
            emailError = "* Email cannot be blank";
        }
        if (!this.state.password) {
            passwordError = "* Password cannot be blank";
        }
        if (emailError || passwordError) {
            this.setState({ emailError: emailError, passwordError: passwordError });
            return false;
        } else return true;
    }

    //handle change form events
    handleChange = (event) => {
        this.setState({ [event.target.name]: event.target.value })
    }
    //handle submit form
    handleSubmit = (event) => {
        event.preventDefault();
        const isValid = this.handleValidate();
        // check validation frontend first
        if (isValid) {   
            this.Auth.login(this.state.email, this.state.password)
                .then(res => {
                    this.props.history.push('/');
                    //this.props.handleStatus(); //after login, run to update the login/logout status
                })
                .catch(error => {
                    this.setState({ passwordError: "* " + JSON.parse(error).message });
                })
            this.props.handleStatus();
        }
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

                        <form onSubmit={this.handleSubmit} noValidate>
                            <input
                                onChange={this.handleChange}
                                value={this.state.email} type="email"
                                id="email"
                                class="fadeIn second"
                                name="email"
                                placeholder="Email" />
                            <div style={{ fontSize:12, color: "red" }}>{this.state.emailError}</div>
                            <input
                                onChange={this.handleChange}
                                value={this.state.password}
                                type="password"
                                id="password"
                                class="fadeIn third"
                                name="password"
                                placeholder="Password" />
                            <div style={{ fontSize: 12, color: "red" }}>{this.state.passwordError}</div>
                            <input type="submit" class="fadeIn fourth" value="Log In" />
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
