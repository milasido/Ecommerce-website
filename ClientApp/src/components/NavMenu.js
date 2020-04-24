import React, { Component} from 'react';
import { Collapse, Navbar, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {

    ////////////////////////////////////////////////
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
         <Navbar className="navbar-expand-sm navbar-toggleable-sm navbar-inverse border-bottom box-shadow mb-1" >
                 <Link to={"/"}>     
                    <img id="logo-nav" className="img-fluid img-responsive" src="https://upload.wikimedia.org/wikipedia/commons/e/e9/Flag_of_South_Vietnam.svg" alt="logo" />
                </Link>
                 <NavbarToggler onClick={this.toggleNavbar} className="ml-auto" id="toggler" />

                     
                     <Collapse className="d-sm-inline-flex flex-sm-row-reverse text-light" isOpen={!this.state.collapsed} navbar>
                         <ul className="navbar-nav flex-grow">
                             <NavItem>
                                 <NavLink tag={Link} className="text-light" to="/">Home</NavLink>
                             </NavItem>
                            {/*<NavItem>
                                 <NavLink tag={Link} className="text-dark" to="/validate">validate</NavLink>
                             </NavItem>*/}
                             {this.props.isLogin === false && // if not log in yet
                                 <NavItem>
                             <NavLink tag={Link} className="text-light" to="/login">Login/Register</NavLink>
                                 </NavItem>
                             }
                             {this.props.isLogin === true && //if status is logged in
                                 <NavItem onClick={this.props.handleStatus}>
                             <NavLink tag={Link} className="text-light" to="/">Logout</NavLink>
                                 </NavItem>
                             }
                             {this.props.isLogin === true && //if status is logged in
                                 <NavItem>
                             <NavLink tag={Link} className="text-light" to="/account">Account</NavLink>
                                 </NavItem>
                             }
                         </ul>
                     </Collapse>
                     <Link to="/cart" className="cccard">
                         <button id="cart" type="submit"><i className="glyphicon ml-auto glyphicon-shopping-cart" /> Cart</button>
                     </Link>
             </Navbar>
     );
 }
}
