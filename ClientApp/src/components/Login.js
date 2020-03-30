import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './Login-signup.css'

export class Login extends Component {
    static displayName = Login.name;

    render() {
        return (
            <div class="wrapper fadeInDown">
              <div id="formContent">
                    {/*Tabs Titles*/}
                <h2 class="active"> Sign In </h2>                   
                <Link to="/signup"><h2 className="inactive underlineHover">Sign Up</h2></Link>

                    {/*<!-- Icon -->*/}
                <div class="fadeIn first">
                        <img src="https://cdn1.iconfinder.com/data/icons/essential-21/128/User-512.png" id="icon" alt="User Icon" />
                </div>

                    {/*Login Form*/}
                <form>
                  <input type="email" id="login" class="fadeIn second" name="login" placeholder="Email"/>
                  <input type="password" id="password" class="fadeIn third" name="login" placeholder="Password"/>
                  <input type="submit" class="fadeIn fourth" value="Log In"/>
                </form>

                     {/*Remind Passowrd*/}
                <div id="formFooter">
                  <a class="underlineHover" href="#">Forgot Password?</a>
                </div>

              </div>
            </div>
        );
    }
}
