import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import './Login-signup.css'


export class Signup extends Component {
    static displayName = Signup.name;

    state = {
        Email: '',
        Password: ''
    }
    handleChange = (event) => {
        this.setState({ [event.target.name]: event.target.value })
    }
    handleSubmit = event => {
        event.preventDefault();
        console.log(this.state)
        axios.post('/api/Auth/Register', this.state)
            .then(response => {
                console.log(response);
                if (response.status >= 200 && response.status < 300)
                    this.props.history.replace('/login');
            })
            .catch(error => {
                console.log(error)
            })
    };

    render() {
        const { Email, Password } = this.state;
        return (
            <div class="wrapper fadeInDown">
                <div id="formContent">
                    {/*Tabs Titles*/}
                    <Link to="/login"><h2 className="inactive underlineHover" >Sign In</h2></Link>
                    <h2 class="active">Sign Up </h2>

                    {/*<!-- Icon -->*/}
                    <div class="fadeIn first">
                        <img src="https://cdn1.iconfinder.com/data/icons/essential-21/128/User-512.png" id="icon" alt="User Icon" />
                    </div>

                    {/*Login Form*/}
                    <form onSubmit={this.handleSubmit}>
                        <input onChange={this.handleChange} value={Email} type="email" id="email" class="fadeIn second" name="Email" placeholder="Email" />
                        <input onChange={this.handleChange} value={Password} type="password" id="password" class="fadeIn third" name="Password" placeholder="Password" />
                        <input type="password" id="password2" class="fadeIn third" name="signup" placeholder="Confirm Password" />
                        <input type="submit" class="fadeIn fourth" value="Sign Up" />
                    </form>

                    {/*Remind Passowrd*
                    <div id="formFooter">
                        <a class="underlineHover" href="#">Forgot Password?</a>
                    </div>*/}

                </div>
            </div>
        );
    }
}
