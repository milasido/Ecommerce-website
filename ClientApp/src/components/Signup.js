import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './Login-signup.css'


export class Signup extends Component {
    static displayName = Signup.name;

    render() {
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
                    <form>
                        <input type="email" id="email" class="fadeIn second" name="signup" placeholder="Email" />
                        <input type="password" id="password" class="fadeIn third" name="signup" placeholder="Password" />
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
