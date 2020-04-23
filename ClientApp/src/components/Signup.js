import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import './Login-signup.css'


export class Signup extends Component {
    static displayName = Signup.name;

    state = {
        Email: '',
        Password: '',
        Password2: '',
        emailError: '',
        passwordError: '',
        password2Error:''
    }
    //handle signup validation
    handleValidate = () => {
        let emailError = "", passwordError = "", password2Error = "";
        if (!this.state.Email.includes('@')) {
            emailError = "* Invalid email";
        }
        if (!this.state.Email) {
            emailError = "* Email cannot be blank";
        }
        if (!this.state.Password) {
            passwordError = "* Password cannot be blank";
        }
        if (!this.state.Password2) {
            password2Error = "* Password needs to be confirmed";
        }
        if ((this.state.Password !== this.state.Password2)) {
            password2Error = "* Password does not match!";
        }
        if (emailError || passwordError || password2Error) {
            this.setState({ emailError: emailError, passwordError: passwordError, password2Error: password2Error });
            return false;
        } else {
            this.setState({ emailError: "", passwordError: "", password2Error: "" });
            return true;
        }
    }

    handleChange = (event) => {
        this.setState({ [event.target.name]: event.target.value })
    }

    handleSubmit = event => {
        event.preventDefault();
        const isValid = this.handleValidate();
        // if passing validation from frontend
        if (isValid) {
            axios.post('/api/Auth/Register', this.state)
                // status 200 (good response) direct to login page
                .then(response => { this.props.history.replace('/login'); })
                // bad request catch error and setstate email error
                .catch(error => this.setState({ emailError: error.response.message }))
            }
    };

    render() {
        const { Email, Password, Password2 } = this.state;
        return (
            <div class="wrapper fadeInDown">
                <div id="formContent">
                    <Link to="/login"><h2 className="inactive underlineHover" >Sign In</h2></Link>
                    <h2 class="active">Sign Up </h2>

                    <div class="fadeIn first">
                        <img src="https://cdn1.iconfinder.com/data/icons/essential-21/128/User-512.png" id="icon" alt="User Icon" />
                    </div>

                    <form onSubmit={this.handleSubmit}>
                        <input
                            onChange={this.handleChange}
                            value={Email}
                            type="email" id="email" class="fadeIn second"
                            name="Email" placeholder="Email" />
                        <div style={{ fontSize: 12, color: "red" }}>{this.state.emailError}</div>
                        <input
                            onChange={this.handleChange}
                            value={Password}
                            type="password" id="password" class="fadeIn third"
                            name="Password" placeholder="Password" />
                        <div style={{ fontSize: 12, color: "red" }}>{this.state.passwordError}</div>
                        <input onChange={this.handleChange}
                            value={Password2}
                            type="password" id="password2" class="fadeIn third"
                            name="Password2" placeholder="Confirm Password" />
                        <div style={{ fontSize: 12, color: "red" }}>{this.state.password2Error}</div>
                        <input type="submit" class="fadeIn fourth" value="Sign Up" />
                    </form>
                </div>
            </div>
        );
    }
}
