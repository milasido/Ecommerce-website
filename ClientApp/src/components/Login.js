import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './Login-signup.css';
import AuthService from './_Services/AuthService';

export class Login extends Component {
    constructor() {
        super();
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.Auth = new AuthService();
    }
    handleChange = (event) => {
        this.setState({[event.target.name]: event.target.value})
    }
    handleSubmit(e) {
        e.preventDefault();
        console.log(this.state);
        this.Auth.login(this.state.email, this.state.password)
            .then(res => {
                this.props.history.replace('/');  
            })
            .catch(err => {
                alert(err);
            })
    }
    /*componentWillMount() {
        if (this.Auth.loggedIn())
            this.props.history.replace('/');
    }*/


    render() {
        return (
            <div class="wrapper fadeInDown">
                <div  id="formContent">
                <h2 class="active"> Sign In </h2>                   
                <Link to="/signup"><h2 className="inactive underlineHover">Sign Up</h2></Link>

                <div class="fadeIn first">
                   <img src="https://cdn1.iconfinder.com/data/icons/essential-21/128/User-512.png" id="icon" alt="User Icon" />
                </div>

                  <form onSubmit={this.handleSubmit}>
                        <input onChange={this.handleChange} type="email" id="login" class="fadeIn second" name="email" placeholder="Email"/>
                        <input onChange={this.handleChange} type="password" id="password" class="fadeIn third" name="password" placeholder="Password"/>
                  <input type="submit" class="fadeIn fourth" value="Log In"/>
                </form>

                <div id="formFooter">
                  <a class="underlineHover" href="#">Forgot Password?</a>
                </div>

              </div>
            </div>
        );
    }
}
