import React, { Component, Fragment } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import logo from '../img/NNP_LOGO.png';
import { Layout } from './Layout';
import './NavMenu.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor() {
        super();

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = { collapsed: true };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    render() {
        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>

                    <Container>
                        <img id="logo-nav" src={logo} alt="logo" />
                        <NavbarToggler onClick={this.toggleNavbar} className="mr-2" id="toggler" />

                        <div class="wrap">
                            <div className="search">
                                <input type="text" className="searchTerm" placeholder="What are you looking for?" />
                                <span><button type="submit" clasNames="searchButton">
                                    <i className="fa fa-search"></i>
                                </button>
                                </span>
                            </div>
                        </div>

                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                            <ul className="navbar-nav flex-grow">
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/validate">validate</NavLink>
                                </NavItem>
                                {this.props.isLogin === false && // if not log in yet
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/login">Login/Register</NavLink>
                                    </NavItem>
                                }
                                {this.props.isLogin === true && //if status is logged in
                                    <NavItem onClick={this.props.handleStatus}>
                                        <NavLink tag={Link} className="text-dark" to="/">Logout</NavLink>
                                    </NavItem>
                                }
                                {this.props.isLogin === true && //if status is logged in
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/account">Account</NavLink>
                                    </NavItem>
                                }
                            </ul>
                        </Collapse>
                        <Link to="/cart">
                            <button id="cart" type="submit"><i class="glyphicon glyphicon-shopping-cart" /> Cart</button>
                        </Link>
                    </Container>
                </Navbar>
            </header >
        );
    }
}
